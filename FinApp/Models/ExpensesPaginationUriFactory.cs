﻿using System;
using FinApp.Api.Controllers;
using FinApp.Api.Helpers.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Api.Models
{
    public class ExpensesPaginationUriFactory : PaginationUriFactory
    {
        public ExpensesPaginationUriFactory(IUrlHelper urlHelper, ExpensesResourceParameters parameters) : base(urlHelper,
            nameof(ExpensesController.GetExpenses))
        {
            if (parameters.ConsumptionTypeId != Guid.Empty)
                Extend(nameof(parameters.ConsumptionTypeId), parameters.ConsumptionTypeId);
        }
    }
}
