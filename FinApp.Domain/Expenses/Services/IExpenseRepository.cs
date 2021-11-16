using System.Collections.Generic;

namespace FinApp.Domain.Expenses.Services
{
    public interface IExpenseRepository
    {
        IAsyncEnumerable<Expense> GetExpenses();
        void AddExpense(Expense expense);
        bool Save();
    }
}
