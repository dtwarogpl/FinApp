using System;

namespace FinApp.Api.Models
{
    public class ExpenseSourceDto
    {
        public DateTime OccuredAt { get; set; }
        public decimal PaidAmount { get; set; }
        public Currency Currency { get; set; }
        public decimal ConsumptionAmount { get; set; }
        public Guid ConsumptionTypeId { get; set; }
    }
}
