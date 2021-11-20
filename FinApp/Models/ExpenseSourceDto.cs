using System;
using System.ComponentModel.DataAnnotations;

namespace FinApp.Api.Models
{
    public class ExpenseSourceDto
    {
        [Required]
        public DateTime OccuredAt { get; set; }

        [Required]
        public decimal PaidAmount { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        public decimal ConsumptionAmount { get; set; }

        [Required]
        public Guid ConsumptionTypeId { get; set; }
    }
}
