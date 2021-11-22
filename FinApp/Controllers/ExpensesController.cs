﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetExpenses([FromQuery] Guid consumptionId)
        {
            if (consumptionId == Guid.Empty)
                return Ok(_expenseRepository.GetExpenses());

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
    }
}
