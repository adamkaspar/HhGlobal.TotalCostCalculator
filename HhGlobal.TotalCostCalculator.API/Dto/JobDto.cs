namespace HhGlobal.TotalCostCalculator.API.Dto;

public class JobDto
{
    public bool IsExtraMargin{ get; set; }

    public List<PrintItemDto> PrintItems{ get; set; }
}