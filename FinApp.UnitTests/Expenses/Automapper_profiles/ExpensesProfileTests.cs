using AutoMapper;
using FinApp.Infrastructure.Expenses.Automapper_profiles;
using NUnit.Framework;

namespace FinApp.UnitTests.Expenses.Automapper_profiles
{
    [TestFixture]
    public class ExpensesProfileTests
    {
        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ExpensesProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
