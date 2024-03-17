using AutoMapper;
using HhGlobal.TotalCostCalculator.API.Dto;
using HhGlobal.TotalCostCalculator.BLL.Models;

namespace HhGlobal.TotalCostCalculator.API.Mappings;

public class PrintItemProfile : Profile
{
    public PrintItemProfile()
    {
        CreateMap<PrintItemDto, PrintItem>();
        CreateMap<PrintItem, PrintItemResultDto>();
    }
}