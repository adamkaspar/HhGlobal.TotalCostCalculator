using System.Text.Json.Serialization;
using HhGlobal.TotalCostCalculator.API.Dto.PrintItems;

namespace HhGlobal.TotalCostCalculator.API.Dto.Jobs;

public class JobResultDto : JobBaseDto<PrintItemResultDto>
{
    [JsonPropertyOrder(1)]
    public double Total{ get; set; }
}
