using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HhGlobal.TotalCostCalculator.BLL.Models.Jobs;
using HhGlobal.TotalCostCalculator.BLL.Models.PrintItems;
using HhGlobal.TotalCostCalculator.BLL.Common;
using HhGlobal.TotalCostCalculator.BLL.Extensions;

namespace HhGlobal.TotalCostCalculator.BLL.Calculators;

public class JobCostCalculator : IJobCostCalculator
{
    ILogger<JobCostCalculator> Logger{ get; }

    Configuration Configuration{ get; }

    public JobCostCalculator(IOptions<Configuration> configuration, ILogger<JobCostCalculator> logger) 
    => (Configuration, Logger) = (configuration.Value, logger);        

    public JobResult CalculateJobCost(Job job)
    {
        Logger.LogDebug("CalculateJobCost started.");

        var totalJobCostWithMargin = job.PrintItems.Sum(printItem => CalculateItemCost(printItem, job.IsExtraMargin));

        ////The final cost is rounded to the nearest even cent.
        var totalJobRoundedCostWithMargin = totalJobCostWithMargin.RoundToNearestEvenValue(Configuration.NumOfFractionalDigits);

        Logger.LogDebug($"CalculateJobCost finished. Total cost: {totalJobRoundedCostWithMargin}");

        var result = new JobResult
        {
            PrintItems = job.PrintItems,
            Total = totalJobRoundedCostWithMargin
        };

        return result;
    }    
    
    private double CalculateItemCost(PrintItem printItem, bool isExtraMargin)
    {
        Logger.LogDebug($"CalculateItemCost for an item: {printItem.Name} started.");

        //Some items qualify as being sales tax free, whereas, by default, others are not. Sales tax is 7%. 
        var taxRate = printItem.IsExempt ? 0 : Configuration.SalesTax;
        //The base margin is 11% for all jobs, some jobs have an "extra margin" of 5%.
        var marginRate = isExtraMargin ? Configuration.BaseMargin + Configuration.ExtraMargin : Configuration.BaseMargin;
                    
        var tax = printItem.Cost * taxRate;

        Logger.LogDebug($"IsExempt for an item: {printItem.Name} is: {printItem.IsExempt}. Tax rate is: {taxRate * 100}% and tax is: {tax}.");

        var margin = printItem.Cost * marginRate;
            
        Logger.LogDebug($"IsExtraMargin for an item: {printItem.Name} is: {isExtraMargin}. Margin rate is: {marginRate * 100}% and margin is: {margin}.");

        var itemCostWithTax = printItem.Cost + tax;
        //Individual items are rounded to the nearest cent.
        printItem.Cost = itemCostWithTax.RoundToNearestValue(Configuration.NumOfFractionalDigits);

        Logger.LogDebug($"CalculateItemCost for an item: {printItem.Name} finished. Total item cost incl. {taxRate * 100}% tax is: {printItem.Cost}.");
            
        //Item cost + margin
        return printItem.Cost + margin;        
    }        
}