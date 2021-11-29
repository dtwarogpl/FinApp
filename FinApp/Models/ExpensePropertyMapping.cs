using System.Collections.Generic;
using FinApp.Api.Helpers.Sorting.PropertyMappings;

namespace FinApp.Api.Models
{
    public class ExpensePropertyMapping : PropertyMapping<ExpenseDto, Expense>
    {
        public ExpensePropertyMapping()
        {
            AddMapping("Id", new PropertyMappingValue(new List<string> {"Id"}));
            AddMapping("Date", new PropertyMappingValue(new List<string> {"OccuredAt"}));
            AddMapping("PaidAmount", new PropertyMappingValue(new List<string> {"PaidAmount"}));
            AddMapping("ConsumptionAmount", new PropertyMappingValue(new List<string> {"ConsumptionAmount"}));
            AddMapping("ConsumptionTypeId", new PropertyMappingValue(new List<string> {"ConsumptionTypeId"}));
        }
    }
}
