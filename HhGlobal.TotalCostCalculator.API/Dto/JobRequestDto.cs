namespace HhGlobal.TotalCostCalculator.API.Dto;

public class JobRequestDto
{
    public bool IsExtraMargin{ get; set; }

    public List<PrintItemDto> PrintItems{ get; set; }
}