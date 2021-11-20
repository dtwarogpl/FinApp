using System.ComponentModel.DataAnnotations;
using FinApp.Api.Models;

namespace FinApp.Api.ValidationRules
{
    public class CounsumptionUnitHasToBeDifferentFromName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var consumptionType = (ConsumptionTypeSourceDto) validationContext.ObjectInstance;

            return consumptionType.Name == consumptionType.Unit
                ? new ValidationResult(ErrorMessage, new[] {nameof(ConsumptionTypeSourceDto)})
                : ValidationResult.Success;
        }
    }
}
