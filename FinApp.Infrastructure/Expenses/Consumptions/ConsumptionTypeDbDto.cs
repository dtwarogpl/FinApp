using System;
using System.ComponentModel.DataAnnotations;
using FinApp.Common;

namespace FinApp.Infrastructure.Expenses.Consumptions
{
    internal class ConsumptionTypeDbDto
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public UnitType Unit { get; set; }
    }
}
