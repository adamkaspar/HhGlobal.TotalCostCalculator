using Microsoft.Extensions.Options;
using HhGlobal.TotalCostCalculator.BLL.Models;
using HhGlobal.TotalCostCalculator.BLL.Common;

namespace HhGlobal.TotalCostCalculator.BLL.Calculators;

public class ItemCostCalculator : IItemCostCalculator
{
    Configuration Configuration{ get; }

    public ItemCostCalculator(IOptions<Configuration> configuration) => Configuration = configuration.Value;

    public async Task CalculateItemCostAsync(PrintItem printItem, bool isExtraMargin, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {            
            var totalCost = printItem.Cost;            

            //Some items qualify as being sales tax free, whereas, by default, others are not. Sales tax is 7%.            
            if (!printItem.IsExempt)
            {
                totalCost += printItem.Cost * Configuration.SalesTax;
            }

            //The base margin is 11% for all jobs, some jobs have an "extra margin" of 5%.
            var margin = isExtraMargin ? Configuration.BaseMargin + Configuration.ExtraMargin : Configuration.BaseMargin;
            totalCost += printItem.Cost * margin;

            printItem.Cost = totalCost;
        }, cancellationToken);
    }
}