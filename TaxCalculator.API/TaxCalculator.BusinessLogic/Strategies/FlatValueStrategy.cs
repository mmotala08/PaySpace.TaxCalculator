using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.BusinessLogic.Strategies.Interfaces;

namespace TaxCalculator.BusinessLogic.Strategies
{
    public class FlatValueStrategy : ITaxCalculationStrategy
    {
        public decimal CalculateTax(decimal annualIncome)
        {
            if (annualIncome < 200000)
            {
                return (annualIncome * (5 / 100.0M));
            }
            else
                return 10000;
        }
    }
}
