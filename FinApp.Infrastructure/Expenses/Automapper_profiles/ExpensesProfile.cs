using AutoMapper;
using FinApp.Domain.Expenses;
using FinApp.Domain.Expenses.Consumptions;
using FinApp.Infrastructure.Expenses.Consumptions;

namespace FinApp.Infrastructure.Expenses.Automapper_profiles
{
    public class ExpensesProfile : Profile
    {
        public ExpensesProfile()
        {
            CreateMap<ConsumptionType, ConsumptionTypeDbDto>();

            CreateMap<Expense, ExpenseDbDto>().ForMember(x => x.PaidAmount, opt => opt.MapFrom(source => source.Price.Amount))
                .ForMember(x => x.Currency, opt => opt.MapFrom(source => source.Price.Currency))
                .ForMember(x => x.ConsumptionAmount, opt => opt.MapFrom(source => source.Consumption.Amount))
                .ForMember(x => x.ConsumptionType, opt => opt.MapFrom(source => source.Consumption.Type));
        }
    }
}
git