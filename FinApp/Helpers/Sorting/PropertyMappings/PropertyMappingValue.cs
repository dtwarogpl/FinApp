using System;
using System.Collections.Generic;

namespace FinApp.Api.Helpers.Sorting.PropertyMappings
{
    public class PropertyMappingValue
    {
        public IEnumerable<string> DestinationProperties { get; }

        public bool Revert { get; }

        public PropertyMappingValue(IEnumerable<string> destinationProperties, bool revert = false)
        {
            DestinationProperties = destinationProperties ?? throw new ArgumentNullException(nameof(destinationProperties));
            Revert = revert;
        }
    }
}
