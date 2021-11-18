using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinApp.Api.Models;
using FinApp.Api.Services;
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

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetExpenses([FromQuery] Guid consumptionId)
        {
            if (consumptionId == Guid.Empty)
                Ok(_expenseRepository.GetExpenses());

            var expenses = _expenseRepository.GetExpenses(consumptionId);
            return Ok(expenses);

            //return NotFound();
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
        public async Task<ActionResult<Expense>> CreateExpense(ExpenseSourceDto source)
        {
            var expense = _mapper.Map<ExpenseSourceDto, Expense>(source);

            await _expenseRepository.AddExpenseAsync(expense);
            await _expenseRepository.SaveAsync();

            return CreatedAtRoute("GetExpense", new {id = expense.Id}, expense);
        }
    }
}
