# Customized Chat Copilot backend web API service

This directory contains the source code for the project's backend web API service. The front end web application component can be found in the [webapp/](../webapp/) directory.

This backend web API is based on the WebAPI included in the [Chat Copilot Sample Application](https://github.com/microsoft/chat-copilot) as a starting point. See the [original web API service README](https://github.com/microsoft/chat-copilot/tree/main/webapi) for more infomration. 

### Important Variations and Notes

1. This project adds a custom Semantic Kernel plugin, registered directly in [SemanticKernelExtensions.cs](./Extensions/SemanticKernelExtensions.cs)
2. The backend WebAPI in this project uses .NET 6 rather than .NET 7
3. The included Kernel Memory Service is configured for `InProcess` processing 
4. Additional third party plugins have been disabled
5. Cosmos Chat store is enabled and deployed by default
6. Qdrant Memory Story is disabled by default
7. Azure Cognitive Search Memory store is not enabled
8. Application Insights telemetry is enabled by default
9. Some changes have been made to remove user intent rewrite, chat memory, and prompt overhead

## Running the Chat Copilot sample

To configure and run either the full Chat Copilot application or only the backend API, please view the [main instructions](../README.md#instructions).

