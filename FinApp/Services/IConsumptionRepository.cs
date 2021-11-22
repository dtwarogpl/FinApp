using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinApp.Api.Models;

namespace FinApp.Controllers
{
    public interface IConsumptionRepository
    {
        //todo: IAsyncEnumerable??
        IEnumerable<ConsumptionType> GetConsumptionTypes();

        Task<ConsumptionType> GetConsumptionType(Guid id);

        Task AddConsumptionTypeAsync(ConsumptionType consumptionType);

        Task SaveAsync();
        void Update(ConsumptionType consumptionType);
    }
}
