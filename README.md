# Chat Copilot with Structured Customer Sales Data

This project utilizes the [Chat Copilot Sample Application](https://github.com/microsoft/chat-copilot) as a starting point, building out the backend webapi to include plugin functions for fetching structured data via a data OpenAPI endpoint. While the Chat Copilot sample application uses a RAG pattern with unstructured data in AISearch (or similar) to allow you to chat with data in documents, this project enables the connected LLM to answer questions about structured customer sales and asset data.

In addition to the front end [./webapp](./webapp/) and backend [./webapi](./webapi/) from the Chat Copilot sample application, this project adds a backend OpenAPI [./dataapi](./dataapi/) which is registered with the Semantic Kernel agent as an additional plugin that can be used by the LLM to answer questions about customer data. The DataApi is modeled after a few data sets from a Customer Relationship Management (CRM) system containing customer asset and and sales data, but could easily replaced with any OpenAPI with a well documented swagger definition.

References:

- https://github.com/microsoft/chat-copilot

# Setup / Run Instructions

## Run Locally

Utilize the quick-start instructions to run the Chat Copilot Sample Application this project is built on found on the official Chat CoPilot Microsoft Learn [getting started](https://learn.microsoft.com/semantic-kernel/chat-copilot/getting-started) page.

> A copy of these instructions published at the time of cloning can be found [here](/docs/ChatCoPilotQuickStart_May2024.md) in the event that the official getting started page gets signficant updates after the creation of this project.

In short, the instructions should help you to:

1. Clone this repository
2. Setup your local environment with pre-requisites
3. Configure app settings for Azure OpenAI connection
4. Run the backend apis and webapp locally

> NOTE: a new backend DataApi has been added to the Chat CoPilot same application in this project. This will build and run locally with the `Start.ps1` script, but assumes a backend SQL database behind this DataApi. This means the DataApi will run and the backend webapi can call it successfully, but no data will be returned.

For more details about the DataApi, see [./dataapi/README.md](./dataapi/README.md)

## Cloud Deployment

UNDER DEVELOPMENT

- Run script [package-webapi](/scripts/deploy/package-webapi.ps1)
- Run main.bicep in Azure to create the following resources:
  - TO DO

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft
trademarks or logos is subject to and must follow
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
