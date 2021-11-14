using System;
using System.Collections.Generic;

namespace FinApp.Domain.Expenses.Services
{
    public interface IExpenseRepository
    {
        IAsyncEnumerable<Expense> GetExpenses();
        void AddExpense(Expense expense);
        void DeleteExpense(Expense author);
        void UpdateExpense(Expense author);
        bool ExpenseExists(Guid expenseId);
        bool Save();
    }
}
