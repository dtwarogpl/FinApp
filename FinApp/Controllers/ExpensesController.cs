using FinApp.Api.Models;
using FinApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpensesController(IExpenseRepository expenseRepository) => _expenseRepository = expenseRepository;

        [HttpGet]
        public ActionResult<Expense> GetExpenses()
        {
            var expenses = _expenseRepository.GetExpenses();
            return Ok(expenses);
        }
    }
}
