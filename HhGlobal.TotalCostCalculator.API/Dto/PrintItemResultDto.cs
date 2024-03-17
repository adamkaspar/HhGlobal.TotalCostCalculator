using System.ComponentModel.DataAnnotations;

namespace HhGlobal.TotalCostCalculator.API.Dto;

public class PrintItemResultDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public double Cost { get; set; }
}