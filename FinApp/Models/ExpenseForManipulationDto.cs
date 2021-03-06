using System;
using System.ComponentModel.DataAnnotations;

namespace FinApp.Api.Models
{
    public abstract class ExpenseForManipulationDto
    {
        [Required]
        public DateTime OccuredAt { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal PaidAmount { get; set; }

        [Required]

        public Currency Currency { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal ConsumptionAmount { get; set; }


        [Required]
        public Guid ConsumptionTypeId { get; set; }
    }
}
