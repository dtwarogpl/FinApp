using FinApp.Domain.Expenses.Consumptions;
using FinApp.Domain.Expenses.Moneys;

namespace FinApp.Domain.Expenses
{
    public record UnitPrice()
    {
        public Money Price { get; }
        public Consumption Consumption { get; }

        public UnitPrice(Money moneyPaid, Consumption consumption) : this()
        {
            var (priceAmount, currency) = moneyPaid;
            var (consumptionAmount, consumptionUnit) = consumption;
            Price = new Money(priceAmount / consumptionAmount, currency);
            Consumption = new Consumption(1, consumptionUnit);
        }
    }
}
