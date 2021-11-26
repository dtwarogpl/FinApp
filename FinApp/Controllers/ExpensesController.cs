using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using FinApp.Api.Helpers;
using FinApp.Api.Models;
using FinApp.Api.Services;
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

        public ExpensesController(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetExpenses")]
        public ActionResult<IEnumerable<ExpenseDto>> GetExpenses([FromQuery] ExpensesResourceParameters expensesResourceParameters)
        {
            var expenses = _expenseRepository.GetExpenses(expensesResourceParameters);

            var previousPageLink = expenses.HasPrevious
                ? CreateExpensesResourceUri(expensesResourceParameters, ResourceUriType.PreviousPage)
                : null;

            var nextPageLink = expenses.HasNext ? CreateExpensesResourceUri(expensesResourceParameters, ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = expenses.TotalCount,
                pageSize = expenses.PageSize,
                currentPage = expenses.CurrentPage,
                totalPages = expenses.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDto>>(expenses));
        }

        private string CreateExpensesResourceUri(ExpensesResourceParameters expensesResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetExpenses", new
                    {
                        pageNumber = expensesResourceParameters.PageNumber - 1,
                        pagesize = expensesResourceParameters.PageSize,
                        expensesResourceParameters.ConsumptionTypeId
                    });
                case ResourceUriType.NextPage:
                    return Url.Link("GetExpenses", new
                    {
                        pageNumber = expensesResourceParameters.PageNumber + 1,
                        pagesize = expensesResourceParameters.PageSize,
                        expensesResourceParameters.ConsumptionTypeId
                    });
                default:
                    return Url.Link("GetExpenses", new
                    {
                        pageNumber = expensesResourceParameters.PageNumber,
                        pagesize = expensesResourceParameters.PageSize,
                        expensesResourceParameters.ConsumptionTypeId
                    });
            }
        }

        [HttpGet("{id}", Name = "GetExpense")]
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

            return CreatedAtRoute("GetExpense", new {id = expense.Id}, expense);
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
