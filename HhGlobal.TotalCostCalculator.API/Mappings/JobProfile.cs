using AutoMapper;
using HhGlobal.TotalCostCalculator.API.Dto.Jobs;
using HhGlobal.TotalCostCalculator.BLL.Models.Jobs;

namespace HhGlobal.TotalCostCalculator.API.Mappings;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<JobDto, Job>();
        CreateMap<JobResult, JobResultDto>();
    }
}
