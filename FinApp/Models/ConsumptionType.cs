using System;
using System.ComponentModel.DataAnnotations;

namespace FinApp.Api.Models
{
    public class ConsumptionType
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }
    }
}
