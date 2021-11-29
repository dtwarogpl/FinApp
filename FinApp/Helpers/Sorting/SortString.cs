using System;
using System.Collections.Generic;
using System.Linq;
using FinApp.Api.Helpers.Sorting.PropertyMappings;

namespace FinApp.Api.Helpers.Sorting
{
    public record SortString
    {
        private const char SortingSeparator = ',';
        private readonly List<SortingOption> _options = new();
        private readonly IPropertyMaping mappingDictionary;

        public string Value => string.Join(",", GetSortingElements());

        public SortString(string source, IPropertyMaping mappingDictionary)
        {
            this.mappingDictionary = mappingDictionary;

            if (string.IsNullOrWhiteSpace(source))
                return;

            _options = source.Split(SortingSeparator).Reverse().Select(x => new SortingOption(x)).ToList();
        }

        private IEnumerable<string> GetSortingElements()
        {
            foreach (var option in _options)
            {
                var destinationProperties = mappingDictionary.GetByKey(option);

                foreach (var destinationProperty in destinationProperties.DestinationProperties)
                {
                    if (destinationProperties.Revert)
                        option.Reverse();

                    yield return destinationProperty + " " + option.Sorting;
                }
            }
        }

        public bool IsValid(out string message)
        {
            foreach (var opt in _options.Where(opt => !mappingDictionary.IsValidFor(opt)))
            {
                message = $"No mapping provided for property:{opt.Value}";
                return false;
            }

            message = default;
            return true;
        }

        public static implicit operator string(SortString source) => source.Value;

        private record SortingOption
        {
            private const string DescendingShortcut = "desc";
            private const string DescendingValue = "descending";
            private const string AscendingValue = "Ascending";

            private bool _descending;
            public string Value { get; }
            public string Sorting => Ascending ? AscendingValue : DescendingValue;
            private bool Ascending => !_descending;

            public SortingOption(string source)
            {
                var optionsource = source.Trim();
                _descending = optionsource.EndsWith($" {DescendingShortcut}");
                var indexOfSpace = optionsource.IndexOf(" ", StringComparison.Ordinal);
                Value = HasSurfix(indexOfSpace) ? optionsource : RemoveSurfix(optionsource, indexOfSpace);
            }

            public static implicit operator string(SortingOption opt) => opt.Value;
            public static implicit operator SortingOption(string opt) => new(opt);

            private static string RemoveSurfix(string optionsource, int idndexOfFirstSpace) => optionsource.Remove(idndexOfFirstSpace);

            private static bool HasSurfix(int idndexOfFirstSpace) => idndexOfFirstSpace == -1;

            public void Reverse()
            {
                _descending = !_descending;
            }
        }
    }
}
