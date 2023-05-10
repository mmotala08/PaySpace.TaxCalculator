using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.BusinessLogic.Factories.Interfaces;
using TaxCalculator.BusinessLogic.Strategies;
using TaxCalculator.BusinessLogic.Strategies.Interfaces;
using TaxCalculator.Domain.Enums;
using TaxCalculator.Domain.Interfaces.Repository;

namespace TaxCalculator.BusinessLogic.Factories
{
    public class TaxCalculationStrategyFactory : ITaxCalculationStrategyFactory
    {
        private readonly IProgressiveTaxRepository _progressiveTaxRepository;
        public TaxCalculationStrategyFactory(IProgressiveTaxRepository progressiveTaxRepository)
        {
            _progressiveTaxRepository = progressiveTaxRepository;
        }
        public ITaxCalculationStrategy GetTaxCalculationStrategy(TaxCalculationTypeEnum taxCalculationTypeEnum)
        {
           switch(taxCalculationTypeEnum)
            {
                case TaxCalculationTypeEnum.FlatValue:
                    {
                        return new FlatValueStrategy();
                    }
                case TaxCalculationTypeEnum.FlatRate:
                    {
                        return new FlatRateStrategy();
                    }
                case TaxCalculationTypeEnum.Progressive:
                    {
                        return new ProgressiveStrategy(_progressiveTaxRepository);
                    }
                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }
    }
}
