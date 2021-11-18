using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinApp.Api.DbContexts;
using FinApp.Api.Models;
using FinApp.Controllers;

namespace FinApp.Api.Services
{
    public class ConsumptionRepository : IConsumptionRepository
    {
        private readonly ExpensesDbContext _context;

        public ConsumptionRepository(ExpensesDbContext context) => _context = context;
        public Task<ConsumptionType> GetConsumptionType(Guid id) => throw new NotImplementedException();

        public async Task AddConsumptionTypeAsync(ConsumptionType consumptionType)
        {
            consumptionType.Id = Guid.NewGuid();
            await _context.ConsumptionTypes.AddAsync(consumptionType);
        }

        public Task SaveAsync() => _context.SaveChangesAsync();

        IEnumerable<ConsumptionType> IConsumptionRepository.GetConsumptionTypes() => _context.ConsumptionTypes;

        public IEnumerable<ConsumptionType> GetConsumptionTypes() => _context.ConsumptionTypes;
    }
}
