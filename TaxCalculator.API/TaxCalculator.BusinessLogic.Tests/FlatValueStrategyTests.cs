using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.Strategies;

namespace TaxCalculator.BusinessLogic.Tests
{
    [TestFixture]
    public class FlatValueStrategyTests
    {
        [TestCase(100000, 5000)]
        [TestCase(150000, 7500)]
        public void CalculateTax_ReturnsCorrectTax_WhenIncomeLessThan200000(decimal annualIncome,decimal expectedTax)
        {
            // Arrange
            var strategy = new FlatValueStrategy();

            // Act
            decimal result = strategy.CalculateTax(annualIncome);

            // Assert
            Assert.AreEqual(expectedTax, result);
        }

        [Test]
        public void CalculateTax_ReturnsCorrectTax_WhenIncomeGreaterThanOrEqualTo200000()
        {
            // Arrange
            var strategy = new FlatValueStrategy();
            decimal annualIncome = 300000M;

            // Act
            decimal result = strategy.CalculateTax(annualIncome);

            // Assert
            Assert.AreEqual(10000M, result);
        }
    }
}
