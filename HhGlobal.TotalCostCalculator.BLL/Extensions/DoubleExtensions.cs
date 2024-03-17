namespace HhGlobal.TotalCostCalculator.BLL.Extensions;

public static class DoubleExtensions
{
    public static double RoundToNearestEvenValue(this double value, int numOfFractionalDigits)
    {
        return Double.Round((0.02 / 1.00) * Double.Round(value * (1.00 / 0.02)), numOfFractionalDigits);
    }
}