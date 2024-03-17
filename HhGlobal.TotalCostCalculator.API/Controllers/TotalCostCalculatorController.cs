using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using HhGlobal.TotalCostCalculator.API.Dto.Jobs;
using HhGlobal.TotalCostCalculator.API.Dto.Exceptions;
using HhGlobal.TotalCostCalculator.BLL.Services;
using HhGlobal.TotalCostCalculator.BLL.Models.Jobs;

namespace HhGlobal.TotalCostCalculator.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TotalCostCalculatorController : ControllerBase
{
    ITotalCostCalculatorService TotalCostCalculatorService { get; }

    IMapper Mapper { get; }

    public TotalCostCalculatorController(ITotalCostCalculatorService totalCostCalculatorService, IMapper mapper)
    => (TotalCostCalculatorService, Mapper) = (totalCostCalculatorService, mapper);

    [SwaggerOperation(Summary = "Runs job and returns final calculation.")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ExceptionDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobResultDto))]    
    [HttpPost("CalculateTotalCost")]
    public ActionResult<JobResultDto> CalculateTotalCost(JobDto jobDto)
    {
        var job = Mapper.Map<Job>(jobDto);
        var jobResult = TotalCostCalculatorService.CalculateTotalCost(job);

        var result = Mapper.Map<JobResultDto>(jobResult);

        return Ok(result);
    }
}
