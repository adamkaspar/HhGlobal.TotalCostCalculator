using HhGlobal.TotalCostCalculator.BLL.Models.Jobs;

namespace HhGlobal.TotalCostCalculator.BLL.Calculators;

public interface IJobCostCalculator
{
    JobResult CalculateJobCost(Job job);
}