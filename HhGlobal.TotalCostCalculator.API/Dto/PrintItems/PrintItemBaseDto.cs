using System.ComponentModel.DataAnnotations;

namespace HhGlobal.TotalCostCalculator.API.Dto.PrintItems;

public class PrintItemBaseDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public double Cost { get; set; }
}
