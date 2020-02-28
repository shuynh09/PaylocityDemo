using Microsoft.Extensions.Logging;
using PaylocityDemo.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PaylocityDemo.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly ILogger<QuoteService> _logger;

        public QuoteService(ILogger<QuoteService> logger)
        {
            _logger = logger;
        }

        public BenefitViewModel CalculateBenefits(EmployeeViewModel employee)
        {
            _logger.LogInformation($"Calculating benfits for {employee.FullName}");
            const int numberOfPaychecks = 26;
            const int paycheck = 2000;
            var employeeCost = 1000;
            var dependentCost = 500;
            var discountNameStartsWithA = 0.1m;
            var totalCost = employeeCost;

            var items = new List<BenefitViewModel.BenefitItem>();
            items.Add(new BenefitViewModel.BenefitItem
            {
                Header = "Annual Salary",
                Caption = $"{paycheck} x {numberOfPaychecks}",
                Amount = $"{paycheck * numberOfPaychecks:C0}"
            });

            items.Add(new BenefitViewModel.BenefitItem
            {
                Header = "Employee Cost",
                Caption = $"{employeeCost} x 1",
                Amount = $"{employeeCost:C0}"
            });

            if (employee.FullName.ToLower().StartsWith("a"))
            {

                items.Add(new BenefitViewModel.BenefitItem
                {
                    Header = "Employee Discount (name starts with A)",
                    Caption = $"{employeeCost} * {(int)(discountNameStartsWithA * 100)}%",
                    Amount = $"-{employeeCost * discountNameStartsWithA:C0}"
                });

                totalCost -= (int)(employeeCost * discountNameStartsWithA);
            }

            if (employee.Dependents.Length > 0)
            {
                CalculateDependents(employee, dependentCost, discountNameStartsWithA, items, ref totalCost);
            }

            items.Add(new BenefitViewModel.BenefitItem
            {
                Caption = $"Total Cost",
                Amount = $"{totalCost:C0}"
            });

            return new BenefitViewModel
            {
                Items = items
            };
        }

        private static void CalculateDependents(EmployeeViewModel employee, int dependentCost, decimal discountNameStartsWithA, List<BenefitViewModel.BenefitItem> items, ref int totalCost)
        {
            items.Add(new BenefitViewModel.BenefitItem
            {
                Header = "Dependents Cost",
                Caption = $"{dependentCost} * {employee.Dependents.Length}",
                Amount = $"{dependentCost * employee.Dependents.Length:C0}"
            });

            totalCost += dependentCost * employee.Dependents.Length;

            var dependentNamesStartWithACount = employee.Dependents.Count(x => x.ToLower().StartsWith("a"));

            if (dependentNamesStartWithACount > 0)
            {
                items.Add(new BenefitViewModel.BenefitItem
                {
                    Header = "Dependents Discounts (name starts with A)",
                    Caption = $"{dependentCost} * {dependentNamesStartWithACount} * {(int)(discountNameStartsWithA * 100)}%",
                    Amount = $"-{dependentCost * dependentNamesStartWithACount * discountNameStartsWithA:C0}"
                });

                totalCost -= (int)(dependentCost * dependentNamesStartWithACount * discountNameStartsWithA);
            }
        }
    }
}
