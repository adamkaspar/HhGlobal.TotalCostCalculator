using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using HhGlobal.TotalCostCalculator.API.Dto;

namespace HhGlobal.TotalCostCalculator.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TotalCostCalculatorController : ControllerBase
{
    IMapper Mapper { get; }

    public TotalCostCalculatorController(IMapper mapper) => Mapper = mapper;

    [SwaggerOperation(Summary = "Runs job and returns final calculation.")]
    [SwaggerResponse(200)]
    [HttpPost("/Calculate")]
    public async Task<ActionResult<JobResponseDto>> Calculate(JobRequestDto jobRequestDto){
        return Ok();
    }
}
