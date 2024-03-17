using System.Text.Json.Serialization;
using System.Text.Json;

namespace HhGlobal.TotalCostCalculator.API.Converters;


public class DoubleJsonConverter : JsonConverter<double>
{
    IConfiguration Configuration{ get; }

    public DoubleJsonConverter(IConfiguration configuration) => Configuration = configuration;

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