using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.BLL.Calculators;

public class ItemCostCalculator : IItemCostCalculator
{
    public async Task CalculateItemCostAsync(PrintItem printItem, bool isExtraMargin, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {            
            var totalCost = printItem.Cost;            

            //Some items qualify as being sales tax free, whereas, by default, others are not. Sales tax is 7%.            
            if (!printItem.IsExempt)
            {
                var salesTax = 0.07;
                totalCost += printItem.Cost * salesTax;
            }

            //The base margin is 11% for all jobs, some jobs have an "extra margin" of 5%.
            var margin = isExtraMargin ? 0.16 : 0.11;
            totalCost += printItem.Cost * margin;

            printItem.Cost = totalCost;
        }, cancellationToken);
    }
}