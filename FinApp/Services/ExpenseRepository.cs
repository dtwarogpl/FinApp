using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task AddExpenseAsync(Expense expense)
        {
            expense.Id = Guid.NewGuid();
            await _context.AddAsync(expense);
        }

        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() >= 0;

        public Task<Expense> GetExpenseAsync(Guid id) => _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);

        public void Update(Expense expense)
        {
            // Handled by reference
        }

        public void Delete(Expense expense)
        {
            _context.Expenses.Remove(expense);
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
