using System;
using FinApp.Common;

namespace FinApp.Domain.Expenses.Consumptions
{
    public record ConsumptionType(Guid Id, string Name, UnitType Unit);
}
