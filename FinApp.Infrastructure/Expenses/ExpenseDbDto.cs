using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinApp.Domain.Expenses.Moneys;
using FinApp.Infrastructure.Expenses.Consumptions;

namespace FinApp.Infrastructure.Expenses
{
    internal class ExpenseDbDto
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime OccuredAt { get; set; }
        public decimal PaidAmount { get; set; }
        public Currency Currency { get; set; }
        public decimal ConsumptionAmount { get; set; }
        public Guid ConsumptionTypeId { get; set; }

        [ForeignKey(nameof(ConsumptionTypeId))]
        public ConsumptionTypeDbDto ConsumptionType { get; set; }
    }
}
