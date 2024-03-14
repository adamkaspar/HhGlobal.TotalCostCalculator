using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using HhGlobal.TotalCostCalculator.API.Dto;
using HhGlobal.TotalCostCalculator.BLL.Services;
using HhGlobal.TotalCostCalculator.BLL.Models;

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
    [HttpPost("/Calculate")]
    public async Task<ActionResult<JobResultDto>> CalculateCost(JobDto jobDto, CancellationToken cancellationToken)
    {
        var job = Mapper.Map<Job>(jobDto);
        var jobResult = await TotalCostCalculatorService.CalculateTotalCostAsync(job, cancellationToken);

        var result = Mapper.Map<JobResultDto>(jobResult);

        return Ok(result);
    }
}
