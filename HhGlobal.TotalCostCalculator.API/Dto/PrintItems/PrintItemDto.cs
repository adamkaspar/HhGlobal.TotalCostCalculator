using System.ComponentModel.DataAnnotations;

namespace HhGlobal.TotalCostCalculator.API.Dto.PrintItems;

public class PrintItemDto : PrintItemBaseDto
{
    [Required]
    public bool IsExempt { get; set; }
}
