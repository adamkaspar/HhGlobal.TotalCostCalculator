using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.BLL.Calculators;

public interface IItemCostCalculator
{
    Task CalculateItemCostAsync(PrintItem printItem, bool isExtraMargin, CancellationToken cancellationToken);
}