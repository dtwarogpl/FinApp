using System;
using FinApp.Api.Controllers;
using FinApp.Api.Helpers.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Api.Models
{
    public class ExpensesPaginationUrl : PaginationUrl
    {
        public ExpensesPaginationUrl(IUrlHelper urlHelper, ExpensesResourceParameters parameters) : base(urlHelper,
            nameof(ExpensesController.GetExpenses))
        {
            if (parameters.ConsumptionTypeId != Guid.Empty)
                Extend(nameof(parameters.ConsumptionTypeId), parameters.ConsumptionTypeId);

            if (!string.IsNullOrWhiteSpace(parameters.OrderBy))
                Extend(nameof(parameters.OrderBy), parameters.OrderBy);

            if (!string.IsNullOrWhiteSpace(parameters.Fields))
                Extend(nameof(parameters.Fields), parameters.Fields);
        }
    }
}
