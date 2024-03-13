using AutoMapper;
using HhGlobal.TotalCostCalculator.API.Dto;
using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.API.Mappings;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<JobRequestDto, Job>();
        CreateMap<JobResult, JobResponseDto>();
        CreateMap<PrintItemDto, PrintItem>();
        CreateMap<PrintItem, PrintItemDto>();
    }
}
