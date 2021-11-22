using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinApp.Api.Models;

namespace FinApp.Api.Services
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetExpenses();
        IEnumerable<Expense> GetExpenses(Guid consumptionTypeId);
        Task AddExpenseAsync(Expense expense);
        Task<bool> SaveAsync();
        Task<Expense> GetExpenseAsync(Guid id);
        void Update(Expense expense);
    }
}
