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

        public Expense(Guid id, DateTime createdAt, DateTime occuredAt, Money price, Consumption consumption)
        {
            Id = id;
            CreatedAt = createdAt;
            OccuredAt = occuredAt;
            Price = price;
            Consumption = consumption;
        }

        public UnitPrice GetCostPerUnit() => new(Price, Consumption);
    }
}
