using AutoMapper;
using FinApp.Api.Models;

namespace FinApp.Profiles
{
    public class ConsumptionTypesProfile : Profile
    {
        public ConsumptionTypesProfile()
        {
            CreateMap<ConsumptionTypeSourceDto, ConsumptionType>();
        }
    }
}
