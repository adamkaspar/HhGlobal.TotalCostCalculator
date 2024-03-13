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
    [SwaggerResponse(200)]
    [HttpPost("/Calculate")]
    public async Task<ActionResult<JobResponseDto>> CalculateCost(JobRequestDto jobRequestDto, CancellationToken cancellationToken)
    {
        var job = Mapper.Map<Job>(jobRequestDto);
        var jobResult = await TotalCostCalculatorService.CalculateTotalCostAsync(job, cancellationToken);

        var result = Mapper.Map<JobResponseDto>(jobResult);

        return Ok(result);
    }
}
