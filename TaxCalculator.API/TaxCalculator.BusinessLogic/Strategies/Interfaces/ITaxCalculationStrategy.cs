using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.BusinessLogic.Strategies.Interfaces
{
    public interface ITaxCalculationStrategy
    {
        decimal CalculateTax(decimal annualIncome);
    }
}
