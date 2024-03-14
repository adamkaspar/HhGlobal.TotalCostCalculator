using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HhGlobal.TotalCostCalculator.BLL.Models;
using HhGlobal.TotalCostCalculator.BLL.Common;

namespace HhGlobal.TotalCostCalculator.BLL.Calculators;

public class ItemCostCalculator : IItemCostCalculator
{
    ILogger<ItemCostCalculator> Logger{ get; }

    Configuration Configuration{ get; }

    public ItemCostCalculator(IOptions<Configuration> configuration, ILogger<ItemCostCalculator> logger) 
    => (Configuration, Logger) = (configuration.Value, logger);

    public async Task CalculateItemCostAsync(PrintItem printItem, bool isExtraMargin, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {    
            Logger.LogDebug($"CalculateItemCostAsync for item {printItem.Name} started.");

            var totalCost = printItem.Cost;            

            //Some items qualify as being sales tax free, whereas, by default, others are not. Sales tax is 7%.            
            if (!printItem.IsExempt)
            {
                totalCost += totalCost * Configuration.SalesTax;

                Logger.LogDebug($"IsExempt for item {printItem.Name} is set. Total item cost incl. {Configuration.SalesTax * 100}% tax is {totalCost}");
            }

            //The base margin is 11% for all jobs, some jobs have an "extra margin" of 5%.
            var margin = isExtraMargin ? Configuration.BaseMargin + Configuration.ExtraMargin : Configuration.BaseMargin;

            Logger.LogDebug($"IsExtraMargin for item {printItem.Name} is {isExtraMargin}. Total item margin is: {margin * 100} %.");

            printItem.Cost = totalCost + printItem.Cost * margin;

            Logger.LogDebug($"CalculateItemCostAsync for item {printItem.Name} finished. Total item cost incl. {margin * 100}% margin + tax is: {printItem.Cost}.");
        }, cancellationToken);
    }
}