using AutoMapper;
using BRQ_B3.Api.ViewModels;
using BRQ_B3.Business.Models;

namespace BRQ_B3.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<CalculoCDB, CDBCalculoViewModel>().ReverseMap();
            CreateMap<CalculoCDB, CDBResultViewModel>().ReverseMap();
        }
    }
}