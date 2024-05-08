<#
.SYNOPSIS
Deploy Chat Copilot application to Azure
#>

param(
    [Parameter(Mandatory)]
    [string]
    # Subscription to which to make the deployment
    $Subscription,

    [Parameter(Mandatory)]
    [string]
    # Resource group to which to make the deployment
    $ResourceGroupName,

    [Parameter(Mandatory)]
    [string]
    # Name of the web application deployed in Azure
    $WebAppName,

    [string]
    # Name of the web app deployment slot
    $DeploymentSlot,

    [string]
    $PackageFilePath = "$PSScriptRoot/out/dataapi.zip",

    [switch]
    # Don't attempt to add our URIs in frontend app registration's redirect URIs
    $SkipAppRegistration,

    [switch]
    # Don't attempt to add our URIs in CORS origins for our plugins
    $SkipCorsRegistration
)

# Ensure $PackageFilePath exists
if (!(Test-Path $PackageFilePath)) {
    Write-Error "Package file '$PackageFilePath' does not exist. Have you run 'package-dataapi.ps1' yet?"
    exit 1
}

az account show --output none
if ($LASTEXITCODE -ne 0) {
    Write-Host "Log into your Azure account"
    az login --output none
}

az account set -s $Subscription
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

Write-Host "Getting Azure WebApp resource name..."
# $deployment = $(az deployment group show --name $DeploymentName --resource-group $ResourceGroupName --output json | ConvertFrom-Json)
# $webApiUrl = $deployment.properties.outputs.webapiUrl.value
# $webApiName = $deployment.properties.outputs.webapiName.value
# $pluginNames = $deployment.properties.outputs.pluginNames.value
$webAppInfo = az webapp show --name $WebAppName --resource-group $ResourceGroupName --output json | ConvertFrom-Json
Write-Host $webAppInfo
$webApiUrl = $webAppInfo.defaultHostName
$webApiName = $WebAppName


if ($null -eq $webApiName) {
    Write-Error "Could not get Azure WebApp resource name from deployment output."
    exit 1
}

Write-Host "Azure WebApp name: $webApiName"

Write-Host "Configuring Azure WebApp to run from package..."
az webapp config appsettings set --resource-group $ResourceGroupName --name $webApiName --settings WEBSITE_RUN_FROM_PACKAGE="1" --output none
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

# Set up deployment command as a string
$azWebAppCommand = "az webapp deployment source config-zip --resource-group $ResourceGroupName --name $webApiName --src $PackageFilePath"

# Check if DeploymentSlot parameter was passed
$origins = @("$webApiUrl")
if ($DeploymentSlot) {
    Write-Host "Checking if slot $DeploymentSlot exists for '$webApiName'..."
    $azWebAppCommand += " --slot $DeploymentSlot"
    $slotInfo = az webapp deployment slot list --resource-group $ResourceGroupName --name $webApiName | ConvertFrom-JSON
    $availableSlots = $slotInfo | Select-Object -Property Name
    $origins = $slotInfo | Select-Object -Property defaultHostName
    $slotExists = false

    foreach ($slot in $availableSlots) { 
        if ($slot.name -eq $DeploymentSlot) { 
            # Deployment slot was found we dont need to create it
            $slotExists = true
        } 
    }

    # Web App deployment slot does not exist, create it
    if (!$slotExists) {
        Write-Host "Deployment slot $DeploymentSlot does not exist, creating..."
        az webapp deployment slot create --slot $DeploymentSlot --resource-group $ResourceGroupName --name $webApiName --output none
        $origins = az webapp deployment slot list --resource-group $ResourceGroupName --name $webApiName | ConvertFrom-JSON | Select-Object -Property defaultHostName
    }
}

Write-Host "Deploying '$PackageFilePath' to Azure WebApp '$webApiName'..."

# Invoke the command string
Invoke-Expression $azWebAppCommand
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}


Write-Host "To verify your deployment, go to 'https://$webApiUrl/' in your browser."