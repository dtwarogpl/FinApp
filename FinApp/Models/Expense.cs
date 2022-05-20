using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinApp.Api.Models
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime OccuredAt { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]

        public decimal PaidAmount { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]

        public decimal ConsumptionAmount { get; set; }

        [Required]
        public Guid ConsumptionTypeId { get; set; }
     
    }
}
