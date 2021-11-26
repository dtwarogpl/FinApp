using AutoMapper;
using FinApp.Api.Models;

namespace FinApp.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseForCreationDto, Expense>();
            CreateMap<ExpenseForUpdateDto, Expense>();
            CreateMap<Expense, ExpenseForUpdateDto>();
            CreateMap<Expense, ExpenseDto>();
        }
    }
}
