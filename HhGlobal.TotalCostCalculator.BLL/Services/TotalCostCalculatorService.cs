using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HhGlobal.TotalCostCalculator.BLL.Models.Jobs;
using HhGlobal.TotalCostCalculator.BLL.Calculators;
using HhGlobal.TotalCostCalculator.BLL.Common;

namespace HhGlobal.TotalCostCalculator.BLL.Services;

public class TotalCostCalculatorService : ITotalCostCalculatorService
{
    Configuration Configuration{ get; }

    ILogger<TotalCostCalculatorService> Logger{ get; }

    IJobCostCalculator JobCostCalculator { get; }

    public TotalCostCalculatorService(IOptions<Configuration> configuration, IJobCostCalculator jobCostCalculator, ILogger<TotalCostCalculatorService> logger) 
    => (Configuration, JobCostCalculator, Logger) = (configuration.Value, jobCostCalculator, logger);
    
    public JobResult CalculateTotalCost(Job job){
        Logger.LogDebug("CalculateTotalCost started.");

        var result = JobCostCalculator.CalculateJobCost(job);

        Logger.LogDebug($"CalculateTotalCost finished.");

        return result;
    }
}