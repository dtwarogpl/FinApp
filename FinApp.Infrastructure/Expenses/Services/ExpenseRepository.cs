using System;
using System.Collections.Generic;
using FinApp.Domain.Expenses.Services;

namespace FinApp.Infrastructure.Expenses.Services
{
    internal class ExpenseRepository : IExpenseRepository
    {
        private ExpensesDbContext _context;

        public ExpenseRepository(ExpensesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IAsyncEnumerable<Domain.Expenses.Expense> GetExpenses() => throw new NotImplementedException();

        public void AddExpense(Domain.Expenses.Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));
          
        }

        public bool Save() => throw new NotImplementedException();
    }

    `


}
