# Deploying this Chat CoPilot application to Azure

This document details how to deploy this project's required resources to your Azure subscription. 

## Things to know

- This documentation is based on the [original deployment instructions](https://github.com/microsoft/chat-copilot/blob/main/scripts/deploy/README.md) for the reference Chat CoPilot application, which has been customized and extended in this project. For more information about additional deployment and configuration options for the Chat CoPilot application, see the original [Chat CoPilot GitHub repository](https://github.com/microsoft/chat-copilot).
- Access to Azure OpenAI is currently limited as we navigate high demand, upcoming product improvements, and Microsoft’s commitment to responsible AI.
  For more details and information on applying for access, go [here](https://learn.microsoft.com/azure/cognitive-services/openai/overview?ocid=AID3051475#how-do-i-get-access-to-azure-openai).
  For regional availability of Azure OpenAI, see the [availability map](https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=cognitive-services).
- With the limited availability of Azure OpenAI, consider sharing an Azure OpenAI instance across multiple resources.

- `F1` and `D1` SKUs for the App Service Plans are not currently supported for this deployment in order to support private networking.

- Chat Copilot deployments use Azure Active Directory for authentication. All endpoints (except `/healthz` and `/authInfo`) require authentication to access.

# Configure your environment

Before you get started, make sure you have the following requirements in place:

- [Azure AD Tenant](https://learn.microsoft.com/azure/active-directory/develop/quickstart-create-new-tenant)
- Azure CLI (i.e., az) (if you already installed Azure CLI, make sure to update your installation to the latest version)
  - Windows, go to https://aka.ms/installazurecliwindows
  - Linux, run "`curl -L https://aka.ms/InstallAzureCli | bash`"

## App registrations (identity)

You will need two Azure Active Directory (AAD) application registrations -- one for the frontend web app and one for the backend API.

> For details on creating an application registration, go [here](https://learn.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app).

> NOTE: Other account types can be used to allow multitenant and personal Microsoft accounts to use your application if you desire. Doing so may result in more users and therefore higher costs.

### Frontend app registration

- Select `Single-page application (SPA)` as platform type, and set the redirect URI to `http://localhost:3000`
- Select `Accounts in this organizational directory only ({YOUR TENANT} only - Single tenant)` as supported account types.
- Make a note of the `Application (client) ID` from the Azure Portal for use in the `Deploy Frontend` step below.

### Backend app registration

- Do not set a redirect URI
- Select `Accounts in this organizational directory only ({YOUR TENANT} only - Single tenant)` as supported account types.
- Make a note of the `Application (client) ID` from the Azure Portal for use in the `Deploy Azure infrastructure` step below.

### Linking the frontend to the backend

1. Expose an API within the backend app registration

   1. Select _Expose an API_ from the menu

   2. Add an _Application ID URI_

      1. This will generate an `api://` URI

      2. Click _Save_ to store the generated URI

   3. Add a scope for `access_as_user`

      1. Click _Add scope_

      2. Set _Scope name_ to `access_as_user`

      3. Set _Who can consent_ to _Admins and users_

      4. Set _Admin consent display name_ and _User consent display name_ to `Access Chat Copilot as a user`

      5. Set _Admin consent description_ and _User consent description_ to `Allows the accesses to the Chat Copilot web API as a user`

   4. Add the web app frontend as an authorized client application

      1. Click _Add a client application_

      2. For _Client ID_, enter the frontend's application (client) ID

      3. Check the checkbox under _Authorized scopes_

      4. Click _Add application_

2. Add permissions to web app frontend to access web api as user

   1. Open app registration for web app frontend

   2. Go to _API Permissions_

   3. Click _Add a permission_

   4. Select the tab _APIs my organization uses_

   5. Choose the app registration representing the web api backend

   6. Select permissions `access_as_user`

   7. Click _Add permissions_

# Deploy Azure Infrastructure

The examples below assume you are using an existing Azure OpenAI resource. See the notes following each command for using OpenAI or creating a new Azure OpenAI resource.

## PowerShell

```powershell
./deploy-azure.ps1 -Subscription {YOUR_SUBSCRIPTION_ID} -DeploymentName {YOUR_DEPLOYMENT_NAME} -AIService AzureOpenAI -AIApiKey {YOUR_AI_KEY} -AIEndpoint {YOUR_AZURE_OPENAI_ENDPOINT} -BackendClientId {YOUR_BACKEND_APPLICATION_ID} -FrontendClientId {YOUR_FRONTEND_APPLICATION_ID} -TenantId {YOUR_TENANT_ID}
```

- Choose a `-DeploymentName` that is meaningful to you.
   - Used as a prefix for deployed resources
   - Used when deploying packaged code to the web services in future steps
- To use an existing Azure OpenAI resource, set `-AIService` to `AzureOpenAI` and include `-AIApiKey` and `-AIEndpoint`.
- To deploy a new Azure OpenAI resource, omit `-AIApiKey` and `-AIEndpoint`.
- To use an an OpenAI account, set `-AIService` to `OpenAI` and include `-AIApiKey`.

The following resources will be deployed in your resource group:

# Deploy Application and DataAPI

To deploy theWebAPI and DataAPI applications, first package them, then deploy them to the Azure App Service created above.

## PowerShell

```powershell
./package-webapi.ps1

./deploy-webapi.ps1 -Subscription {YOUR_SUBSCRIPTION_ID} -ResourceGroupName {YOUR_RESOURCE_GROUP_NAME} -DeploymentName {YOUR_DEPLOYMENT_NAME}
```

```powershell
./package-dataapi.ps1

./deploy-dataapi.ps1 -Subscription {YOUR_SUBSCRIPTION_ID} -ResourceGroupName {YOUR_RESOURCE_GROUP_NAME} -DeploymentName {YOUR_DEPLOYMENT_NAME}
```

# Appendix

## Using custom web frontends to access your deployment

Make sure to include your frontend's URL as an allowed origin in your deployment's CORS settings. Otherwise, web browsers will refuse to let JavaScript make calls to your deployment.

To do this, go on the Azure portal, select your Semantic Kernel App Service, then click on "CORS" under the "API" section of the resource menu on the left of the page.
This will get you to the CORS page where you can add your allowed hosts.

### PowerShell

```powershell
$webApiName = $(az deployment group show --name {DEPLOYMENT_NAME} --resource-group {YOUR_RESOURCE_GROUP_NAME} --output json | ConvertFrom-Json).properties.outputs.webapiName.value

az webapp cors add --name $webapiName --resource-group $ResourceGroupName --subscription $Subscription --allowed-origins YOUR_FRONTEND_URL
```
