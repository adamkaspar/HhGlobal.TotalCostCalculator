using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.BLL.Calculators;

public interface IJobCostCalculator
{
    Task<JobResult> CalculateJobCostAsync(Job job, CancellationToken cancellationToken);
}