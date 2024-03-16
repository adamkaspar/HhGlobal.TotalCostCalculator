using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace HhGlobal.TotalCostCalculator.API.Converters;


public class DoubleConverter : JsonConverter<double>
{
    IConfiguration Configuration{ get; }

    public DoubleConverter(IConfiguration configuration) => Configuration = configuration;

    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetDouble();
    }

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        var numOfFractionalDigits = Configuration.GetValue<int>("CostCalculations:NumOfFractionalDigits");

        writer.WriteStringValue(value.ToString($"F{numOfFractionalDigits}"));
    }
}