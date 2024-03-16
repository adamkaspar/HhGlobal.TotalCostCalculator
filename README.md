# TotalCostCalculator

TotalCostCalculator is a .NET 8 project, that process jobs with items and returns computed margin and tax for a whole job.
Whole solution is divided into 3 projetcs:
```
├── TotalCostCalculator.sln
│   ├── TotalCostCalculator.API.csproj
│   ├── TotalCostCalculator.BLL.csproj
│   ├── TotalCostCalculator.Tests.csproj
└── .gitignore
```
### TotalCostCalculator.API

This project contains basic controller for starting the whole job computation and basic double json converter.

### TotalCostCalculator.BLL

This project contains whole computational logic. Entry poin is TotalCostCalculatorService, that calls Calculator class. 
This class then computes final price with tax and margin for given job.

### TotalCostCalculator.Tests

Tests project contains unit and integration tests, that covers basic scenarios.

## Installation

TotalCostCalculator runs on .NET 8, so .NET 8 runtime is necessary to [install](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

## Usage

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
