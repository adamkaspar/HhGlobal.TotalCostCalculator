using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.BLL.Services;

public interface ITotalCostCalculatorService
{    
    JobResult CalculateTotalCost(Job job);
}