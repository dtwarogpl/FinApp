namespace FinApp.Domain.Expenses.Moneys.Services
{
    public interface ICurrencyConverter
    {
        public Money ConvertTo(Money source, Currency currency);
    }
}
