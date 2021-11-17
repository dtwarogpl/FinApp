using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinApp.Api.Models
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime OccuredAt { get; set; }
        public decimal PaidAmount { get; set; }
        public Currency Currency { get; set; }
        public decimal ConsumptionAmount { get; set; }
        public Guid ConsumptionTypeId { get; set; }

        [ForeignKey(nameof(ConsumptionTypeId))]
        public ConsumptionType ConsumptionType { get; set; }
    }
}
