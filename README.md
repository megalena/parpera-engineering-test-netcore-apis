# parpera-engineering-test-netcore-apis
Parpera.TransactionService is RESTful API built as backend engineering test for Parpera.

## Build
Open Parpera.TransactionService.sln in Microsoft Visual Studio and select Build/Build Solution

## Run
Open Parpera.TransactionService.sln in Microsoft Visual Studio and Press F5

## Usage
HTTP Method: Get
URL: https://localhost:44324/api/transactions
Success Response: the list of thransactions ordered by DateTime Descending.

HTTP Method: Patch
URL: https://localhost:44324/api/transactions
Query string params: id=[integer]
Body: status
Success Response: 200
Error Response: 400

## Tests
Open Parpera.TransactionService.sln in Microsoft Visual Studio, right click on the project Parpera.TransactionService.UnitTests and select Run Tests