using System.ComponentModel.DataAnnotations;

namespace HhGlobal.TotalCostCalculator.API.Dto;

public class PrintItemDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public double Cost { get; set; }

    [Required]
    public bool IsExempt { get; set; }
}
