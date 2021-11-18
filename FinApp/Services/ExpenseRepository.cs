using System;
using System.Collections.Generic;
using System.Linq;
using FinApp.Api.DbContexts;
using FinApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Api.Services
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpensesDbContext _context;

        public ExpenseRepository(ExpensesDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public IEnumerable<Expense> GetExpenses() => _context.Expenses.Include(x => x.ConsumptionType).ToList();

        public IEnumerable<Expense> GetExpenses(Guid consumptionTypeId)
        {
            return _context.Expenses.AsQueryable().Where(exp => exp.ConsumptionTypeId == consumptionTypeId).Include(x => x.ConsumptionType);
        }

        public void AddExpense(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));


            expense.Id = Guid.NewGuid();

            if (expense.ConsumptionTypeId == Guid.Empty || ConsumptionTypeDoesNotExists(expense.ConsumptionTypeId))
                AddConsumptionType(expense.ConsumptionType);

            _context.Expenses.Add(expense);
        }

        public bool Save() => _context.SaveChanges() >= 0;

        public void AddConsumptionType(ConsumptionType consumptionType)
        {
            if (consumptionType == null)
                throw new ArgumentNullException(nameof(consumptionType));

            consumptionType.Id = Guid.NewGuid();

            _context.ConsumptionTypes.Add(consumptionType);
        }

        public bool ConsumptionTypeExists(Guid ConsumptionTypeId)
        {
            return _context.ConsumptionTypes.Any(x => x.Id == ConsumptionTypeId);
        }

        public bool ConsumptionTypeDoesNotExists(Guid ConsumptionTypeGuid) => !ConsumptionTypeExists(ConsumptionTypeGuid);
    }
}
