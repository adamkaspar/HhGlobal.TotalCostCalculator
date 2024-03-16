using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.BLL.Calculators;

public interface IJobCostCalculator
{
    JobResult CalculateJobCost(Job job);
}