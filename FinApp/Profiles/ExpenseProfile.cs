using AutoMapper;
using FinApp.Api.Models;

namespace FinApp.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseSourceDto, Expense>();
        }
    }
}
