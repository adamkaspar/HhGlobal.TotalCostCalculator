# TotalCostCalculator

TotalCostCalculator is a .NET 8 project, that process jobs with items and returns computed margin and tax for a whole job.
Whole solution is divided into 3 projetcs:
```
├── HhGlobal.TotalCostCalculator.sln
│   ├── HhGlobal.TotalCostCalculator.API.csproj
│   ├── HhGlobal.TotalCostCalculator.BLL.csproj
│   ├── HhGlobal.TotalCostCalculator.Tests.csproj
└── .gitignore
```
### HhGlobal.TotalCostCalculator.API

This project contains basic TotalCostCalculatorController as starting point of the whole job computation, basic double json converter and ExceptionHandlingMiddleware as global place, where all errors are catched and handled. In development mode, there is support for swagger UI. Project supports also configuration of basic tax and margin values in appsettings.json in CostCalculations section.

### HhGlobal.TotalCostCalculator.BLL

BLL project contains whole computational logic. Entry point is TotalCostCalculatorService, that calls JobCostCalculator class. 
This class then process in sequence final price with tax and margin for given job items.

### HhGlobal.TotalCostCalculator.Tests

Tests project contains unit and integration tests, that covers basic test scenarios. xUnit is used as default test framework, Moq is used as mocking library and FluentAssertions is used as assertion framework.

## Installation

TotalCostCalculator runs on .NET 8, so .NET 8 SDK is necessary to [install](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

To run the aplication, do the following steps:

1. open .NET CLI and go to the HhGlobal.TotalCostCalculator.API folder
2. type **dotnet run**
3. project should be built and run after some time
4. by default, project should run on http://localhost:5121
5. Swagger UI is supported in development mode (ASPNETCORE_ENVIRONMENT env. variable is set to Development) as well on http://localhost:5121/swagger

Launch settings and default ports is possible to change in HhGlobal.TotalCostCalculator.API\Properties\launchSettings.json file
## Usage

There is one endpoint reacheable on path: /api/v1/TotalCostCalculator/CalculateTotalCost. This endpoint is possible to call with POST verb. Endpoint accept message in json format structure:

```
{  
  "printItems": [
    {
      "name": "envelopes",
      "cost": 100,
      "isExempt": true
    }
  ],
  "isExtraMargin": true
}
```
Where:

| Property    | Comment |
| --------  | ------- |
| printItems | List of items, that are part of the job.     |
| name    | Name of the item.    |
| cost    | Item cost.    |
| isExempt    | True or false value, that signals, if basic tax is applied on the item price.   |
| isExtraMargin  | True or false value, that signals if extra margin is applied on the job total cost.    |

Endpoint returns json response in json format, with following structure:

```
{
  "printItems": [
    {
      "name": "envelopes",
      "cost": 100,
    }
  ],
  "total": 116
}
```
Where:

| Property    | Comment |
| --------  | ------- |
| printItems | List of items, that are part of the job.     |
| name    | Name of the item.    |
| cost    | Item final cost, when all taxes are applied.    |
| total    | Total price of the job, when all margins are applied.   |

In case of any error, json message with following structure is returned back:

```
{
  "correlationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "statusCode": 500,
  "message": "string"
}
```
Where:

| Property    | Comment |
| --------  | ------- |
| correlationId | Error id. Use this error id to find out more information about error in application log.     |
| statusCode    | Error status code    |
| message    | Basic information about an error.    |

To change application behavior, like tax and margin rates, you can change it in HhGlobal.TotalCostCalculator.API\appsettings.json file in CostCalculations section. You have to re-run the aplication after change.

Application support Swagger UI in development mode on http://localhost:5121/swagger, so it could be tested from this interface as well.

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
