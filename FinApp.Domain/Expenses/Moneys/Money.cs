using FinApp.Domain.Expenses.Moneys.Services;

namespace FinApp.Domain.Expenses.Moneys
{
    public record Money(decimal Amount, Currency Currency)
    {
        public Money GetAs(Currency currency, ICurrencyConverter converter) => converter.ConvertTo(this, currency);
    }
}
