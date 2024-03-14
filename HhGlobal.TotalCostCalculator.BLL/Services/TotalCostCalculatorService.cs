using Microsoft.Extensions.Logging;
using HhGlobal.TotalCostCalculator.BLL.Models;
using HhGlobal.TotalCostCalculator.BLL.Calculators;

namespace HhGlobal.TotalCostCalculator.BLL.Services;

public class TotalCostCalculatorService : ITotalCostCalculatorService
{
    ILogger<TotalCostCalculatorService> Logger{ get; }

    IItemCostCalculator ItemCostCalculator { get; }

    public TotalCostCalculatorService(IItemCostCalculator itemCostCalculator, ILogger<TotalCostCalculatorService> logger) 
    => (ItemCostCalculator, Logger) = (itemCostCalculator, logger);

    public async Task<JobResult> CalculateTotalCostAsync(Job job, CancellationToken cancellationToken)
    {
        Logger.LogDebug("CalculateTotalCostAsync started.");

        var tasks = job.PrintItems.Select(printItem => ItemCostCalculator.CalculateItemCostAsync(printItem, job.IsExtraMargin, cancellationToken));

        await Task.WhenAll(tasks);

        var totalCost = job.PrintItems.Sum(printItem => printItem.Cost);

        Logger.LogDebug($"CalculateTotalCostAsync finished. Total cost: {totalCost}");

        var result = new JobResult
        {
            PrintItems = job.PrintItems,
            Total = totalCost
        };

        return result;
    }
}