using Microsoft.Extensions.Logging.Abstractions;
using PaylocityDemo.Services;
using System.Linq;
using Xunit;

namespace PaylocityDemo.Tests
{
    public class QuoteServiceTest
    {
        private readonly QuoteService _quoteService;

        public QuoteServiceTest()
        {
            _quoteService = new QuoteService(new NullLogger<QuoteService>());
        }

        [Fact]
        public void CanCalculateBenefitsForEmployeeNoDependents()
        {
            var result = _quoteService.CalculateBenefits(new ViewModels.EmployeeViewModel { Dependents = new string[] { }, FullName = "Jon Snow" });
            Assert.NotNull(result);
            Assert.NotNull(result.Items);
            Assert.Equal(3, result.Items.Count);

            var totalCost = result.Items.SingleOrDefault(x => x.Caption == "Total Cost");
            Assert.NotNull(totalCost);
            Assert.Equal("$1,000", totalCost.Amount);
        }

        [Fact]
        public void CanCalculateBenefitsForEmployeeNoDependentsAndNameStartsWithA()
        {
            var result = _quoteService.CalculateBenefits(new ViewModels.EmployeeViewModel { Dependents = new string[] { }, FullName = "Arya Stark" });
            Assert.NotNull(result);
            Assert.NotNull(result.Items);
            Assert.Equal(4, result.Items.Count);

            var totalCost = result.Items.SingleOrDefault(x => x.Caption == "Total Cost");
            Assert.NotNull(totalCost);
            Assert.Equal("$900", totalCost.Amount);
        }
    }
}
