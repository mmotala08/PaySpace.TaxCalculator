using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.BusinessLogic.Factories.Interfaces;
using TaxCalculator.DataAccess.Interfaces.Repository;
using TaxCalculator.Domain.Enums;
using TaxCalculator.Domain.Models;
using TaxCalculatorServices.Abstractions.Interfaces;

namespace TaxCalculator.Services.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly ITaxCalculationTypeRepository _taxCalculationTypeRepository;
        private readonly ITaxCalculationStrategyFactory _taxCalculationStrategyFactory;
        private readonly ITaxCalculationOutputRepository _taxCalculationOutputRepository;
        public TaxCalculatorService(ITaxCalculationStrategyFactory taxCalculationStrategyFactory, ITaxCalculationTypeRepository taxCalculationTypeRepository, ITaxCalculationOutputRepository taxCalculationOutputRepository)
        {
            _taxCalculationStrategyFactory = taxCalculationStrategyFactory;
            _taxCalculationTypeRepository = taxCalculationTypeRepository;
            _taxCalculationOutputRepository = taxCalculationOutputRepository;
        }
        public decimal CalculateTax(string postalCode, decimal annualIncome)
        {
            TaxCalculationTypeModel taxCalculationType = _taxCalculationTypeRepository.GetTaxCalculationType(postalCode);
            if (taxCalculationType == null)
                throw new ArgumentException();

            var taxCalculationStrategy = _taxCalculationStrategyFactory.GetTaxCalculationStrategy((TaxCalculationTypeEnum)Enum.Parse(typeof(TaxCalculationTypeEnum), taxCalculationType.CalculationType.ToString()));
            var taxCalculated = taxCalculationStrategy.CalculateTax(annualIncome);

            TaxCalculationOutputModel taxCalculationOutputModel = new TaxCalculationOutputModel()
            {
                PostalCode = postalCode,
                AnnualIncome = annualIncome,
                TaxValue = taxCalculated,
                CreatedDate = DateTime.UtcNow
            };
            
            _taxCalculationOutputRepository.Insert(taxCalculationOutputModel);

            return taxCalculated;
        }
    }
}
