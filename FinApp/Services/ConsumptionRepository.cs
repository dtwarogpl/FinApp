using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinApp.Api.DbContexts;
using FinApp.Api.Models;
using FinApp.Controllers;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Api.Services
{
    public class ConsumptionRepository : IConsumptionRepository
    {
        private readonly ExpensesDbContext _context;

        public ConsumptionRepository(ExpensesDbContext context) => _context = context;
        public Task<ConsumptionType> GetConsumptionType(Guid id) => _context.ConsumptionTypes.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddConsumptionTypeAsync(ConsumptionType consumptionType)
        {
            consumptionType.Id = Guid.NewGuid();
            await _context.ConsumptionTypes.AddAsync(consumptionType);
        }

        public Task SaveAsync() => _context.SaveChangesAsync();

        public void Update(ConsumptionType consumptionType)
        {
            // Handled by reference
        }


        public IEnumerable<ConsumptionType> GetConsumptionTypes() => _context.ConsumptionTypes;
    }
}
