# Chat Copilot front end web application

This directory contains the source code for Chat Copilot's frontend web application. The backend web API service component can be found in the [webapi/](../webapi/) directory.

This frontend web application is based on the Chat CoPilot frontend client included in the [Chat Copilot Sample Application](https://github.com/microsoft/chat-copilot) as a starting point. See the [original web application README](https://github.com/microsoft/chat-copilot/tree/main/webapp) for more information. 

### Important Variations and Notes

1. Certain 'educational' features and tabs have been disabled in the web app, including:
    * Plugin setup
    * Profile setup
2. The 'Document' tab in the web app, and the ability to upload discrete documents, has not been disabled in UI, but will not be used or visible to the model with the current configuration of Kernel Memory in the WebAPI.

## Running the Chat Copilot sample
To configure and run the full Chat Copilot application, please view the [main instructions](../README.md#instructions).