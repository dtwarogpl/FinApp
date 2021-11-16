using System;
using FinApp.Domain.Expenses.Services;
using FinApp.Infrastructure.Expenses.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinApp.Infrastructure
{
    public static class Registration
    {
        public static IServiceCollection RegisterInfrasturcureDependencies(this IServiceCollection services) =>
            services.AddScoped<IExpenseRepository, ExpenseRepository>().AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
