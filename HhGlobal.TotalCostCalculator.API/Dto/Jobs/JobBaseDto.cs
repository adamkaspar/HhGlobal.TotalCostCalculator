using System.ComponentModel.DataAnnotations;

namespace HhGlobal.TotalCostCalculator.API.Dto.Jobs;

public class JobBaseDto<T> where T : class
{
    [Required]    
    public List<T> PrintItems{ get; set; }
}