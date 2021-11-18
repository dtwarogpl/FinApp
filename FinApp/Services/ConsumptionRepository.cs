using System.Collections.Generic;
using FinApp.Api.DbContexts;
using FinApp.Api.Models;
using FinApp.Controllers;

namespace FinApp.Api.Services
{
    public class ConsumptionRepository : IConsumptionRepository
    {
        private readonly ExpensesDbContext _context;

        public ConsumptionRepository(ExpensesDbContext context) => _context = context;

        public IEnumerable<ConsumptionType> GetConsumptionTypes() => _context.ConsumptionTypes;
    }
}
