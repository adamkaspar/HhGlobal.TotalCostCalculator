using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.BLL.Services;

public class TotalCostCalculatorService : ITotalCostCalculatorService
{
    public async Task<JobResult> CalculateTotalCostAsync(Job job, CancellationToken cancellationToken)
    {
        return new JobResult();
    }
}