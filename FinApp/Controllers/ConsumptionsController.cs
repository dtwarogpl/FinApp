using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinApp.Api.Models;
using FinApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Api.Controllers
{
    [ApiController]
    [Route("api/consumptions")]
    public class ConsumptionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConsumptionRepository _repository;

        public ConsumptionsController(IConsumptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ConsumptionType>> GetConsumptionTypes() => Ok(_repository.GetConsumptionTypes());

        [HttpGet("{consumptionId}", Name = "GetConsumptionType")]
        public async Task<ActionResult<ConsumptionType>> GetConsumptionType(Guid consumptionId)
        {
            var consumptionType = await _repository.GetConsumptionType(consumptionId);

            if (consumptionType is null)
                return NotFound();

            return Ok(consumptionType);
        }

        [HttpPost]
        public async Task<ActionResult<ConsumptionType>> CreateConsumption(ConsumptionTypeForCreationDto source)
        {
            var consumption = _mapper.Map<ConsumptionTypeForCreationDto, ConsumptionType>(source);
            await _repository.AddConsumptionTypeAsync(consumption);
            await _repository.SaveAsync();

            return CreatedAtRoute("GetConsumptionType", new {consumptionId = consumption.Id}, consumption);
        }

        [HttpPut("{consumptionId}")]
        public async Task<ActionResult> UpdateConsumptionType(Guid consumptionId, ConsumptionTypeForUpdateDto consumptionType)
        {
            var consumptionTypeFromRepo = await _repository.GetConsumptionType(consumptionId);
            if (consumptionTypeFromRepo is null)
                return NotFound();

            _mapper.Map(consumptionType, consumptionTypeFromRepo);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
