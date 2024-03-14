using System.ComponentModel.DataAnnotations;

namespace HhGlobal.TotalCostCalculator.API.Dto;

public class JobDto
{
    [Required]
    public bool IsExtraMargin{ get; set; }

    [Required]
    public List<PrintItemDto> PrintItems{ get; set; }
}