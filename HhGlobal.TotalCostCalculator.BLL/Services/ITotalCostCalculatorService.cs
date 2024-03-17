using HhGlobal.TotalCostCalculator.BLL.Models.Jobs;

namespace HhGlobal.TotalCostCalculator.BLL.Services;

public interface ITotalCostCalculatorService
{    
    JobResult CalculateTotalCost(Job job);
}