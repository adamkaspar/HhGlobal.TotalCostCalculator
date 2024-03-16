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

Tests project contains unit and integration tests, that covers basic test scenarios. xUnit is used as default test framework.

## Installation

TotalCostCalculator runs on .NET 8, so .NET 8 runtime is necessary to [install](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).


## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
