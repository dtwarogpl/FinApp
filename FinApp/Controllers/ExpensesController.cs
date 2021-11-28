using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinApp.Api.Helpers.Pagination;
using FinApp.Api.Models;
using FinApp.Api.Services;
using FinApp.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Api.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _mappingService;

        public ExpensesController(IExpenseRepository expenseRepository, IMapper mapper, IPropertyMappingService mappingService)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _mappingService = mappingService;
        }

        [HttpGet(Name = nameof(GetExpenses))]
        public ActionResult<IEnumerable<ExpenseDto>> GetExpenses([FromQuery] ExpensesResourceParameters expensesResourceParameters)
        {
            if (_mappingService.ValidMappingExistsFor<ExpenseDto, Expense>(expensesResourceParameters.OrderBy))
                return BadRequest();

            var expenses = _expenseRepository.GetExpenses(expensesResourceParameters);

            CreatePaginationMetadata(expensesResourceParameters, expenses).AddTo(Response.Headers);

            return Ok(_mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDto>>(expenses));
        }

        private PaginationMetadata<Expense> CreatePaginationMetadata(ExpensesResourceParameters expensesResourceParameters,
            PagedList<Expense> expenses) =>
            new(expensesResourceParameters, expenses, new ExpensesPaginationUrl(Url, expensesResourceParameters));


        [HttpGet("{id}", Name = nameof(GetExpense))]
        public async Task<ActionResult<Expense>> GetExpense(Guid id)
        {
            var exp = await _expenseRepository.GetExpenseAsync(id);

            if (exp is null)
                return NotFound();

            return Ok(exp);
        }

        //todo: create expense 
        //todo: create expense with consumption
        [HttpPost]
        public async Task<ActionResult<Expense>> CreateExpense(ExpenseForCreationDto forCreation)
        {
            var expense = _mapper.Map<ExpenseForCreationDto, Expense>(forCreation);

            await _expenseRepository.AddExpenseAsync(expense);
            await _expenseRepository.SaveAsync();

            return CreatedAtRoute(nameof(GetExpense), new {id = expense.Id}, expense);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpense(Guid id, ExpenseForUpdateDto expense)
        {
            var expenseFromRepository = await _expenseRepository.GetExpenseAsync(id);

            if (expenseFromRepository is null)
                return NotFound();

            _mapper.Map(expense, expenseFromRepository);

            _expenseRepository.Update(expenseFromRepository);
            await _expenseRepository.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartiallyUpdateExpense(Guid id, JsonPatchDocument<ExpenseForUpdateDto> patchDocument)
        {
            var expenseFromRepository = await _expenseRepository.GetExpenseAsync(id);

            if (expenseFromRepository is null)
                return NotFound();

            var expenseDto = _mapper.Map<Expense, ExpenseForUpdateDto>(expenseFromRepository);
            patchDocument.ApplyTo(expenseDto, ModelState);

            if (!TryValidateModel(expenseDto))
                return ValidationProblem(ModelState);


            _mapper.Map(expenseDto, expenseFromRepository);
            _expenseRepository.Update(expenseFromRepository);
            await _expenseRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpense(Guid id)
        {
            var expenseFromRepository = await _expenseRepository.GetExpenseAsync(id);

            if (expenseFromRepository is null)
                return NotFound();

            _expenseRepository.Delete(expenseFromRepository);
            await _expenseRepository.SaveAsync();
            return NoContent();
        }
    }
}
