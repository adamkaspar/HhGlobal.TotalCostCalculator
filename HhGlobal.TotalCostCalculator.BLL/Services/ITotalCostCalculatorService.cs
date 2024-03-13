using System.Threading;
using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.BLL.Services;

public interface ITotalCostCalculatorService
{
    Task<JobResult> CalculateTotalCostAsync(Job job, CancellationToken cancellationToken);
}