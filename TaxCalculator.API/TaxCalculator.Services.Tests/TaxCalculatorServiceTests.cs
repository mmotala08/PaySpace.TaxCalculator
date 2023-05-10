using Moq;
using TaxCalculator.BusinessLogic.Factories.Interfaces;
using TaxCalculator.BusinessLogic.Strategies.Interfaces;
using TaxCalculator.DataAccess.Interfaces.Repository;
using TaxCalculator.Domain.Enums;
using TaxCalculator.Domain.Models;
using TaxCalculator.Services.Services;

namespace TaxCalculator.Services.Tests
{
    [TestFixture]
    public class TaxCalculatorServiceTests
    {
        private Mock<ITaxCalculationTypeRepository> _taxCalculationTypeRepositoryMock;
        private Mock<ITaxCalculationStrategyFactory> _taxCalculationStrategyFactoryMock;
        private Mock<ITaxCalculationOutputRepository> _taxCalculationOutputRepositoryMock;
        private TaxCalculatorService _sut;

        [SetUp]
        public void Setup()
        {
            _taxCalculationTypeRepositoryMock = new Mock<ITaxCalculationTypeRepository>();
            _taxCalculationStrategyFactoryMock = new Mock<ITaxCalculationStrategyFactory>();
            _taxCalculationOutputRepositoryMock = new Mock<ITaxCalculationOutputRepository>();
            _sut = new TaxCalculatorService(_taxCalculationStrategyFactoryMock.Object, _taxCalculationTypeRepositoryMock.Object, _taxCalculationOutputRepositoryMock.Object);
        }

        [Test]
        public void CalculateTax_ThrowsArgumentException_WhenTaxCalculationTypeIsNull()
        {
            // Arrange
            _taxCalculationTypeRepositoryMock.Setup(x => x.GetTaxCalculationType("invalidPostalCode")).Returns((TaxCalculationTypeModel)null);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.CalculateTax("invalidPostalCode", 50000m));
        }

        [Test]
        public void CalculateTax_ReturnsTaxCalculated_WhenTaxCalculationTypeIsFound()
        {
            // Arrange
            var taxCalculationType = new TaxCalculationTypeModel { CalculationType = (int)TaxCalculationTypeEnum.FlatRate };
            _taxCalculationTypeRepositoryMock.Setup(x => x.GetTaxCalculationType("validPostalCode")).Returns(taxCalculationType);

            var taxCalculationStrategyMock = new Mock<ITaxCalculationStrategy>();
            taxCalculationStrategyMock.Setup(x => x.CalculateTax(50000m)).Returns(5000m);

            _taxCalculationStrategyFactoryMock.Setup(x => x.GetTaxCalculationStrategy(TaxCalculationTypeEnum.FlatRate)).Returns(taxCalculationStrategyMock.Object);

            // Act
            var result = _sut.CalculateTax("validPostalCode", 50000m);

            // Assert
            Assert.AreEqual(5000m, result);
        }

        [Test]
        public void CalculateTax_InsertsTaxCalculationOutput_WhenTaxCalculationTypeIsFound()
        {
            // Arrange
            var taxCalculationType = new TaxCalculationTypeModel { CalculationType = (int)TaxCalculationTypeEnum.FlatRate };
            _taxCalculationTypeRepositoryMock.Setup(x => x.GetTaxCalculationType("validPostalCode")).Returns(taxCalculationType);

            var taxCalculationStrategyMock = new Mock<ITaxCalculationStrategy>();
            taxCalculationStrategyMock.Setup(x => x.CalculateTax(50000m)).Returns(5000m);

            _taxCalculationStrategyFactoryMock.Setup(x => x.GetTaxCalculationStrategy(TaxCalculationTypeEnum.FlatRate)).Returns(taxCalculationStrategyMock.Object);

            // Act
            _sut.CalculateTax("validPostalCode", 50000m);

            // Assert
            _taxCalculationOutputRepositoryMock.Verify(x => x.Insert(It.IsAny<TaxCalculationOutputModel>()), Times.Once);
        }
    }
}