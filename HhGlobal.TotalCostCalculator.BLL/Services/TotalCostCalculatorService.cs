using HhGlobal.TotalCostCalculator.BLL.Models;
using HhGlobal.TotalCostCalculator.BLL.Calculators;

namespace HhGlobal.TotalCostCalculator.BLL.Services;

public class TotalCostCalculatorService : ITotalCostCalculatorService
{
    IItemCostCalculator ItemCostCalculator { get; }

    public TotalCostCalculatorService(IItemCostCalculator itemCostCalculator) => ItemCostCalculator = itemCostCalculator;

    public async Task<JobResult> CalculateTotalCostAsync(Job job, CancellationToken cancellationToken)
    {
        var tasks = job.PrintItems.Select(printItem => ItemCostCalculator.CalculateItemCostAsync(printItem, job.IsExtraMargin, cancellationToken));

        await Task.WhenAll(tasks);

        var result = new JobResult
        {
            PrintItems = job.PrintItems,
            Total = job.PrintItems.Sum(printItem => printItem.Cost)
        };

        return result;
    }
}