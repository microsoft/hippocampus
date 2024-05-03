variable "location" {
  description = "Region for the resources"
  default     = "East US2" // Replace with your default location
}

variable "unique_name" {
  description = "Unique name for the resource"
}

provider "azurerm" {
  features {}
}

resource "azurerm_cosmosdb_account" "example" {
  name                = lower(var.unique_name)
  location            = var.location
  resource_group_name = azurerm_resource_group.example.name
  offer_type          = "Standard"
  kind                = "GlobalDocumentDB"

  consistency_policy {
    consistency_level       = "Session"
    max_interval_in_seconds = 10
    max_staleness_prefix    = 200
  }

  geo_location {
    location          = var.location
    failover_priority = 0
  }
}

resource "azurerm_cosmosdb_sql_database" "example" {
  name                = "CopilotChat"
  resource_group_name = azurerm_resource_group.example.name
  account_name        = azurerm_cosmosdb_account.example.name
}

resource "azurerm_cosmosdb_sql_container" "chatmessages" {
  name                = "chatmessages"
  resource_group_name = azurerm_resource_group.example.name
  account_name        = azurerm_cosmosdb_account.example.name
  database_name       = azurerm_cosmosdb_sql_database.example.name

  partition_key_path = "/chatId"
}

resource "azurerm_cosmosdb_sql_container" "chatsessions" {
  name                = "chatsessions"
  resource_group_name = azurerm_resource_group.example.name
  account_name        = azurerm_cosmosdb_account.example.name
  database_name       = azurerm_cosmosdb_sql_database.example.name

  partition_key_path = "/id"
}

resource "azurerm_cosmosdb_sql_container" "chatparticipants" {
  name                = "chatparticipants"
  resource_group_name = azurerm_resource_group.example.name
  account_name        = azurerm_cosmosdb_account.example.name
  database_name       = azurerm_cosmosdb_sql_database.example.name

  partition_key_path = "/userId"
}

resource "azurerm_cosmosdb_sql_container" "chatmemorysources" {
  name                = "chatmemorysources"
  resource_group_name = azurerm_resource_group.example.name
  account_name        = azurerm_cosmosdb_account.example.name
  database_name       = azurerm_cosmosdb_sql_database.example.name

  partition_key_path = "/chatId"
}