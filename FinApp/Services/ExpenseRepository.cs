using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinApp.Api.DbContexts;
using FinApp.Api.Helpers;
using FinApp.Api.Helpers.Sorting.PropertyMappings;
using FinApp.Api.Models;
using FinApp.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Api.Services
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpensesDbContext _context;
        private readonly IPropertyMappingService _mappingService;

        public ExpenseRepository(ExpensesDbContext context, IPropertyMappingService mappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mappingService = mappingService;
        }

        public PagedList<Expense> GetExpenses(ExpensesResourceParameters expensesResourceParameters)
        {
            var queryableCollection = _context.Expenses.AsQueryable();

            if (expensesResourceParameters.ConsumptionTypeId != Guid.Empty)
                queryableCollection =
                    queryableCollection.Where(exp => exp.ConsumptionTypeId == expensesResourceParameters.ConsumptionTypeId);

            var propertyMapping = _mappingService.GetPropertyMapping<ExpenseDto, Expense>();
            queryableCollection = queryableCollection.ApplySort(expensesResourceParameters.OrderBy, propertyMapping);

            return queryableCollection.ToPagedList(expensesResourceParameters.PageNumber, expensesResourceParameters.PageSize);
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

        public IEnumerable<Expense> GetExpenses(Guid consumptionTypeId)
        {
            return _context.Expenses.AsQueryable().Where(exp => exp.ConsumptionTypeId == consumptionTypeId);
        }

        public void AddExpense(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));


            expense.Id = Guid.NewGuid();

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
