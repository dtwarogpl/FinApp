using System;
using FinApp.Domain.Expenses.Consumptions;
using FinApp.Domain.Expenses.Moneys;

namespace FinApp.Domain.Expenses
{
    public class Expense
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; }
        public DateTime OccuredAt { get; }
        public Money Price { get; }
        public Consumption Consumption { get; }

        //todo: I don'tt like so many fields in constructor. Use builder here? What about auto mapping?
        public Expense(Guid id, DateTime createdAt, DateTime occuredAt, Money price, Consumption consumption)
        {
            Id = id;
            CreatedAt = DateTime.Now;
            OccuredAt = occuredAt;
            Price = price ?? throw new ArgumentNullException(nameof(price));
            Consumption = consumption ?? throw new ArgumentNullException(nameof(consumption));
        }

        public UnitPrice GetCostPerUnit() => new(Price, Consumption);
    }
}
