using System;
using System.Collections.Generic;
using FinApp.Api.Models;

namespace FinApp.Api.Services
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetExpenses();
        IEnumerable<Expense> GetExpenses(Guid ConsumptionTypeID);
        void AddExpense(Expense expense);
        bool Save();
    }
}
