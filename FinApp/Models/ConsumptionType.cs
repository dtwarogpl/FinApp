using System;
using System.ComponentModel.DataAnnotations;

namespace FinApp.Api.Models
{
    public class ConsumptionType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Unit { get; set; }
    }
}
