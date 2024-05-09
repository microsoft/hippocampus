#!/bin/bash

# Deploy Data Api application to Azure

usage() {
    echo "Usage: $0 -d DEPLOYMENT_NAME -s SUBSCRIPTION -rg RESOURCE_GROUP [OPTIONS]"
    echo ""
    echo "Arguments:"
    echo "  -d, --deployment-name DEPLOYMENT_NAME   Name of the deployment from a 'deploy-azure.sh' deployment (mandatory)"
    echo "  -s, --subscription SUBSCRIPTION         Subscription to which to make the deployment (mandatory)"
    echo "  -rg, --resource-group RESOURCE_GROUP    Resource group name from a 'deploy-azure.sh' deployment (mandatory)"
    echo "  -p, --package PACKAGE_FILE_PATH         Path to the package file from a 'package-webapi.sh' run (default: \"./out/webapi.zip\")"
    echo "  -o, --slot DEPLOYMENT_SLOT              Name of the target web app deployment slot"
}

# Parse arguments
while [[ $# -gt 0 ]]; do
    key="$1"
    case $key in
    -d|--deployment-name)
        DEPLOYMENT_NAME="$2"
        shift
        shift
        ;;
    -s|--subscription)
        SUBSCRIPTION="$2"
        shift
        shift
        ;;
    -rg|--resource-group)
        RESOURCE_GROUP="$2"
        shift
        shift
        ;;
    -p|--package)
        PACKAGE_FILE_PATH="$2"
        shift
        shift
        ;;    
    -o|--slot)
        DEPLOYMENT_SLOT="$2"
        shift
        shift
        ;;    
    *)
        echo "Unknown option $1"
        usage
        exit 1
        ;;
    esac
done

# Check mandatory arguments
if [[ -z "$DEPLOYMENT_NAME" ]] || [[ -z "$SUBSCRIPTION" ]] || [[ -z "$RESOURCE_GROUP" ]]; then
    usage
    exit 1
fi

# Set defaults
: "${PACKAGE_FILE_PATH:="$(dirname "$0")/out/dataapi.zip"}"

# Ensure $PACKAGE_FILE_PATH exists
if [[ ! -f "$PACKAGE_FILE_PATH" ]]; then
    echo "Package file '$PACKAGE_FILE_PATH' does not exist. Have you run 'package-dataapi.sh' yet?"
    exit 1
fi

az account show --output none
if [ $? -ne 0 ]; then
    echo "Log into your Azure account"
    az login --use-device-code
fi

az account set -s "$SUBSCRIPTION"

echo "Getting Azure WebApp resource name..."
DEPLOYMENT_JSON=$(az deployment group show --name $DEPLOYMENT_NAME --resource-group $RESOURCE_GROUP --output json)
WEB_API_URL=$(echo $DEPLOYMENT_JSON | jq -r '.properties.outputs.webapiUrl.value')
echo "WEB_API_URL: $WEB_API_URL"
WEB_API_NAME=$(echo $DEPLOYMENT_JSON | jq -r '.properties.outputs.webapiName.value')
echo "WEB_API_NAME: $WEB_API_NAME"
# Remove double quotes
# Ensure $WEB_API_NAME is set
if [[ -z "$WEB_API_NAME" ]]; then
    echo "Could not get Azure WebApp resource name from deployment output."
    exit 1
fi

echo "Configuring Azure WebApp to run from package..."
az webapp config appsettings set --resource-group $RESOURCE_GROUP --name $WEB_API_NAME --settings WEBSITE_RUN_FROM_PACKAGE="1" --output none
if [ $? -ne 0 ]; then
    echo "Could not configure Azure WebApp to run from package."
    exit 1
fi

# Set up deployment command as a string
AZ_WEB_APP_CMD="az webapp deployment source config-zip --resource-group $RESOURCE_GROUP --name $WEB_API_NAME --src $PACKAGE_FILE_PATH"

if [ -n "$DEPLOYMENT_SLOT" ]; then
    AZ_WEB_APP_CMD+=" --slot ${DEPLOYMENT_SLOT}"
    echo "Checking whether slot $DEPLOYMENT_SLOT exists for $WEB_APP_NAME..."
    SLOT_INFO=$(az webapp deployment slot list --resource-group $RESOURCE_GROUP --name $WEB_API_NAME)

    AVAILABLE_SLOTS=$(echo $SLOT_INFO | jq '.[].name')
    SLOT_EXISTS=false

    # Checking if the slot exists
    for SLOT in $(echo "$AVAILABLE_SLOTS" | tr '\n' ' '); do
        if [[ "$SLOT" == "$DEPLOYMENT_SLOT" ]]; then
            SLOT_EXISTS=true
            break
        fi
    done

    if [[ "$SLOT_EXISTS" = false ]]; then 
        echo "Deployment slot ${DEPLOYMENT_SLOT} does not exist, creating..."
        
        az webapp deployment slot create --slot=$DEPLOYMENT_SLOT --resource-group=$RESOURCE_GROUP --name $WEB_API_NAME
    fi
fi

echo "Deploying '$PACKAGE_FILE_PATH' to Azure WebApp '$WEB_API_NAME'..."
eval "$AZ_WEB_APP_CMD"
if [ $? -ne 0 ]; then
    echo "Could not deploy '$PACKAGE_FILE_PATH' to Azure WebApp '$WEB_API_NAME'."
    exit 1
fi

echo "To verify your deployment, go to 'https://$WEB_API_URL/' in your browser."
