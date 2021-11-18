using System.Collections.Generic;
using FinApp.Api.Models;

namespace FinApp.Controllers
{
    public interface IConsumptionRepository
    {
        IEnumerable<ConsumptionType> GetConsumptionTypes();
    }
}
