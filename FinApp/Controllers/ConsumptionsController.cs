using System.Collections.Generic;
using FinApp.Api.Models;
using FinApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Api.Controllers
{
    [ApiController]
    [Route("api/consumptions")]
    public class ConsumptionsController : ControllerBase
    {
        private readonly IConsumptionRepository _repository;

        public ConsumptionsController(IConsumptionRepository repository) => _repository = repository;

        [HttpGet]
        public ActionResult<IEnumerable<ConsumptionType>> GetConsumptions() => Ok(_repository.GetConsumptionTypes());
    }
}
