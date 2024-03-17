using AutoMapper;
using HhGlobal.TotalCostCalculator.API.Dto.PrintItems;
using HhGlobal.TotalCostCalculator.BLL.Models.PrintItems;

namespace HhGlobal.TotalCostCalculator.API.Mappings;

public class PrintItemProfile : Profile
{
    public PrintItemProfile()
    {
        CreateMap<PrintItemDto, PrintItem>();
        CreateMap<PrintItem, PrintItemResultDto>();
    }
}