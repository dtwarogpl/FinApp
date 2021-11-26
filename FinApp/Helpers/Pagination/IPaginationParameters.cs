namespace FinApp.Api.Models
{
    public interface IPaginationParameters
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}
