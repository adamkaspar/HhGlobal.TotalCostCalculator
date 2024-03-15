using System.Text.Json.Serialization;
using System.Text.Json;

namespace HhGlobal.TotalCostCalculator.API.Converters;


public class DoubleConverter : JsonConverter<double>
{
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetDouble();
    }

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("0.00"));
    }
}