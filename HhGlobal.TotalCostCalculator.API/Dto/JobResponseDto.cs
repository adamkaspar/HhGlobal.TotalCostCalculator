namespace HhGlobal.TotalCostCalculator.API.Dto;

public class JobResponseDto
{
    public List<PrintItemDto> PrintItems{ get; set; }

    public double Total{ get; set; }
}
