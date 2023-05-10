using TaxCalculator.BusinessLogic.Strategies;

namespace TaxCalculator.BusinessLogic.Tests
{
    [TestFixture]
    public class FlatRateStrategyTests
    {
        [TestCase(50000, 8750)]
        [TestCase(100000, 17500)]
        [TestCase(150000, 26250)]
        public void CalculateTax_ReturnsCorrectTax(decimal annualIncome, decimal expectedTax)
        {
            // Arrange
            var strategy = new FlatRateStrategy();

            // Act
            var result = strategy.CalculateTax(annualIncome);

            // Assert
            Assert.AreEqual(expectedTax, result);
        }
    }
}