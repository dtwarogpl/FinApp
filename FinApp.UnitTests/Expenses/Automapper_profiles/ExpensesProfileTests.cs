using System;
using AutoMapper;
using FinApp.Common;
using FinApp.Domain.Expenses;
using FinApp.Domain.Expenses.Consumptions;
using FinApp.Domain.Expenses.Moneys;
using FinApp.Infrastructure.Expenses;
using FinApp.Infrastructure.Expenses.Automapper_profiles;
using FluentAssertions;
using NUnit.Framework;

namespace FinApp.UnitTests.Expenses.Automapper_profiles
{
    [TestFixture]
    public class ExpensesProfileTests
    {
        [SetUp]
        public void Setup()
        {
            Expense = new Expense(Guid.NewGuid(), DateTime.Now, DateTime.Now, new Money(100, Currency.Usd),
                new Consumption(10, new ConsumptionType(Guid.NewGuid(), "consumption", UnitType.CubicMeters)));
        }

        [Test]
        public void AutoMapper_Configuration_Should_BeValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ExpensesProfile>());
            config.AssertConfigurationIsValid();
        }

        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ExpensesProfile>());
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            var result = mapper.Map<Expense, ExpenseDbDto>(Expense);

            result.PaidAmount.Should().Be(Expense.Price.Amount);
            result.Currency.Should().Be(Expense.Price.Currency);

            //todo: how to write tests for AutoMapper profiles?
            //Shall I create object by my own and check all properties one by one?
        }

        private Expense Expense;
    }
}
