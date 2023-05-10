using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculatorServices.Abstractions.Interfaces
{
    public interface ITaxCalculatorService
    {
       decimal CalculateTax(string postalCode, decimal annualIncome);
    }
}
