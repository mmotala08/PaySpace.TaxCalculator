using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.BusinessLogic.Strategies.Interfaces;

namespace TaxCalculator.BusinessLogic.Strategies
{
    public class FlatRateStrategy : ITaxCalculationStrategy
    {
        public decimal CalculateTax(decimal annualIncome)
        {
            return annualIncome * (17.5M / 100.0M);
        }
    }
}
