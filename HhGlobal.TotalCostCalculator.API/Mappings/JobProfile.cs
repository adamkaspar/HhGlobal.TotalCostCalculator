using AutoMapper;
using HhGlobal.TotalCostCalculator.API.Dto;
using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.API.Mappings;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<JobDto, Job>();
        CreateMap<JobResult, JobResultDto>();
    }
}
