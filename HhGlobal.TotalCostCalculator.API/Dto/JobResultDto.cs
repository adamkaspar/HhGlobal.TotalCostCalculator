namespace HhGlobal.TotalCostCalculator.API.Dto;

public class JobResultDto
{
    public List<PrintItemResultDto> PrintItems{ get; set; }

    public double Total{ get; set; }
}
