using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HhGlobal.TotalCostCalculator.BLL.Models;
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

    public async Task<JobResult> CalculateTotalCostAsync(Job job, CancellationToken cancellationToken)
    {
        Logger.LogDebug("CalculateTotalCostAsync started.");

        var result = await JobCostCalculator.CalculateJobCostAsync(job, cancellationToken);

        Logger.LogDebug($"CalculateTotalCostAsync finished.");

        return result;
    }
}