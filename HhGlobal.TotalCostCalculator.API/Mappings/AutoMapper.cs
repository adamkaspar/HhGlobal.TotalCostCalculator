using AutoMapper;
using HhGlobal.TotalCostCalculator.API.Dto;
using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.API.Mappings;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<JobDto, Job>();
        CreateMap<JobResult, JobResultDto>();
        CreateMap<PrintItemDto, PrintItem>().ReverseMap();
    }
}
