using System.ComponentModel.DataAnnotations;
using HhGlobal.TotalCostCalculator.API.Dto.PrintItems;

namespace HhGlobal.TotalCostCalculator.API.Dto.Jobs;

public class JobDto : JobBaseDto<PrintItemDto>
{
    [Required]
    public bool IsExtraMargin{ get; set; }
}