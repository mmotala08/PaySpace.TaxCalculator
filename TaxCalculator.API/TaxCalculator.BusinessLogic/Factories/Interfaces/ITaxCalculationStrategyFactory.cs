using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.BusinessLogic.Strategies.Interfaces;
using TaxCalculator.Domain.Enums;

namespace TaxCalculator.BusinessLogic.Factories.Interfaces
{
    public interface ITaxCalculationStrategyFactory
    {
        ITaxCalculationStrategy GetTaxCalculationStrategy(TaxCalculationTypeEnum taxCalculationTypeEnum);
    }
}
