# Homework assignment for Backend Integration Developer

This application is the back-end part of a Lottery game app, where the front-end generates lottery draws and submits it via an API.

[![Pre-merge tests](https://github.com/mgelei/backend-integration-lab/actions/workflows/pr-tests.yml/badge.svg?event=pull_request)](https://github.com/mgelei/backend-integration-lab/actions/workflows/pr-tests.yml)

### Features
* REST API to store lottery draws and retrieve the list of all previous entries
* Uses ASP.NET 7 Web API with Entity Framework Core
* Unit tests with xUnit, Moq and FluentAssertions that are run against all pull requests
* Migrations run on app startup, with a design-time context factory for scaffolding controllers
* Data validation for number uniqueness, range and quantity with a custom validator 
* DB primary keys are not exposed to API consumers
* Numbers are sorted in ascending order before being stored in the DB

### Usage
* Clone the repository
* Provide the connection string for a SQL Server / Azure SQL database anywhere it can be picked up by ConfigurationManager
  * In development mode, the easiest way is to use user secrets
* Restore, build and run the project
  * In development mode, you can use the Swagger UI to try the API endpoints