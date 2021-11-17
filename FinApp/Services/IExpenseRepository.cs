using System.Collections.Generic;
using FinApp.Api.Models;

namespace FinApp.Api.Services
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetExpenses();
        void AddExpense(Expense expense);
        bool Save();
    }
}
