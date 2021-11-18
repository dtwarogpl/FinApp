using System;
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

        public ExpensesController(IExpenseRepository expenseRepository) => _expenseRepository = expenseRepository;

        [HttpGet]
        public ActionResult<Expense> GetExpenses([FromQuery] string consumptionId)
        {
            if (string.IsNullOrEmpty(consumptionId))
                Ok(_expenseRepository.GetExpenses());

            if (Guid.TryParse(consumptionId, out var result))
                return Ok(_expenseRepository.GetExpenses(result));

            return NotFound();
        }
    }
}
