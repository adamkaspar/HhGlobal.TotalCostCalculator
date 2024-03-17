namespace HhGlobal.TotalCostCalculator.BLL.Extensions;

public static class DoubleExtensions
{
    public static double RoundToNearestValue(this double value, int numOfFractionalDigits)
    {
        return Math.Round(value, numOfFractionalDigits);
    }

    public static double RoundToNearestEvenValue(this double value, int numOfFractionalDigits)
    {
        return Math.Round(value, numOfFractionalDigits, MidpointRounding.ToZero);
    }
}