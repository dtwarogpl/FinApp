using FinApp.Domain.Expenses;
using FinApp.Domain.Expenses.Consumptions;
using FinApp.Domain.Expenses.Moneys;
using FluentAssertions;
using NUnit.Framework;

namespace FinApp.UnitTests.Expenses
{
    [TestFixture]
    public class UnitPriceTests
    {
        private readonly Money _paid = new(10, Currency.Usd);
        private readonly Consumption _consumed = new(5, UnitType.Liters);

        [Test]
        public void UnitPrice_Should_Calculate_Price()
        {
            var unitPrice = new UnitPrice(_paid, _consumed);
            // Assert
            unitPrice.Price.Amount.Should().Be(_paid.Amount / _consumed.Amount);
        }

        [Test]
        public void UnitPrice_Should_PerseveCurrency()
        {
            var unitPrice = new UnitPrice(_paid, _consumed);
            unitPrice.Price.Currency.Should().Be(_paid.Currency);
        }

        [Test]
        public void UnitPrice_Should_HaveSigleUnitConsumption()
        {
            var unitPrice = new UnitPrice(_paid, _consumed);
            unitPrice.Consumption.Amount.Should().Be(1);
        }

        [Test]
        public void UnitPrice_Should_PerseveConsumptionUnit()
        {
            var unitPrice = new UnitPrice(_paid, _consumed);
            unitPrice.Consumption.Unit.Should().Be(_consumed.Unit);
        }
    }
}
