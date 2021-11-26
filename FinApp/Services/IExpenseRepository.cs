using System;
using System.Threading.Tasks;
using FinApp.Api.Models;
using FinApp.Helpers;

namespace FinApp.Api.Services
{
    public interface IExpenseRepository
    {
        PagedList<Expense> GetExpenses(ExpensesResourceParameters expensesResourceParameters);
        Task AddExpenseAsync(Expense expense);
        Task<bool> SaveAsync();
        Task<Expense> GetExpenseAsync(Guid id);
        void Update(Expense expense);
        void Delete(Expense expense);
    }
}
