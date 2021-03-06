using System;

namespace FinApp.Api.Models
{
    public class ExpensesResourceParameters : IPaginationParameters
    {
        private const int MaxPageSize = 20;
        private int _pageNumber = 1;
        private int _pageSize = 100;
        public Guid ConsumptionTypeId { get; set; }
        public string Fields { get; set; }
        public string OrderBy { get; set; }

        public bool DisablePagination { get; set; }

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
