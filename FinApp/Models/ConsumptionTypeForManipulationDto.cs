using System.ComponentModel.DataAnnotations;
using FinApp.Api.ValidationRules;

namespace FinApp.Api.Models
{
    [CounsumptionUnitHasToBeDifferentFromName(ErrorMessage = "The provided unit should be different from the name")]
    public abstract class ConsumptionTypeForManipulationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Unit { get; set; }
    }
}
