using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.Strategies;
using TaxCalculator.Domain.Interfaces.Repository;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.BusinessLogic.Tests
{
    [TestFixture]
    public class ProgressiveStrategyTests
    {
        private Mock<IProgressiveTaxRepository> _mockRepository;
        private ProgressiveStrategy _strategy;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IProgressiveTaxRepository>();
            _strategy = new ProgressiveStrategy(_mockRepository.Object);
        }

        [Test]
        public void CalculateTax_ShouldReturnCorrectTax_WhenIncomeIsWithinBrackets()
        {
            // Arrange
            var taxTable = new List<ProgressiveTaxModel>
        {
            new ProgressiveTaxModel { LowerBound = 0, UpperBound = 10000, Rate = 10 },
            new ProgressiveTaxModel { LowerBound = 10000, UpperBound = 20000, Rate = 15 },
            new ProgressiveTaxModel { LowerBound = 20000, UpperBound = 30000, Rate = 20 },
        };
            _mockRepository.Setup(x => x.GetProgressiveTaxTable()).Returns(taxTable);

            // Act
            var tax = _strategy.CalculateTax(25000);

            // Assert
            Assert.AreEqual(1000M + 1500M + 1000M, tax);
        }

        [Test]
        public void CalculateTax_ShouldReturnCorrectTax_WhenIncomeIsAboveLastBracket()
        {
            // Arrange
            var taxTable = new List<ProgressiveTaxModel>
        {
            new ProgressiveTaxModel { LowerBound = 0, UpperBound = 10000, Rate = 10 },
            new ProgressiveTaxModel { LowerBound = 10000, UpperBound = 20000, Rate = 15 },
            new ProgressiveTaxModel { LowerBound = 20000, UpperBound = 30000, Rate = 20 },
            new ProgressiveTaxModel { LowerBound = 30000, UpperBound = null, Rate = 25 },
        };
            _mockRepository.Setup(x => x.GetProgressiveTaxTable()).Returns(taxTable);

            // Act
            var tax = _strategy.CalculateTax(40000);

            // Assert
            Assert.AreEqual(1000M + 1500M + 2000M + 2500M, tax);
        }

        [Test]
        public void CalculateTax_ShouldReturnCorrectTax_WhenOnlyOneBracketExists()
        {
            // Arrange
            var taxTable = new List<ProgressiveTaxModel>
        {
            new ProgressiveTaxModel { LowerBound = 0, UpperBound = null, Rate = 10 },
        };
            _mockRepository.Setup(x => x.GetProgressiveTaxTable()).Returns(taxTable);

            // Act
            var tax = _strategy.CalculateTax(25000);

            // Assert
            Assert.AreEqual(2500M, tax);
        }
    }
}
