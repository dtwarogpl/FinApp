using System.ComponentModel.DataAnnotations;
using FinApp.Api.Models;

namespace FinApp.Api.ValidationRules
{
    public class CounsumptionUnitHasToBeDifferentFromName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var consumptionType = (ConsumptionTypeForManipulationDto) validationContext.ObjectInstance;

            return consumptionType.Name == consumptionType.Unit
                ? new ValidationResult(ErrorMessage, new[] {nameof(ConsumptionTypeForManipulationDto)})
                : ValidationResult.Success;
        }
    }
}
