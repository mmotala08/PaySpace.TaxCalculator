using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxCalculator.BusinessLogic.Strategies.Interfaces;
using TaxCalculator.Domain.Interfaces.Repository;

namespace TaxCalculator.BusinessLogic.Strategies
{
    public class ProgressiveStrategy : ITaxCalculationStrategy
    {
        private readonly IProgressiveTaxRepository _progressiveTaxRepository;
        public ProgressiveStrategy(IProgressiveTaxRepository progressiveTaxRepository)
        {
            _progressiveTaxRepository = progressiveTaxRepository;
        }
        public decimal CalculateTax(decimal annualIncome)
        {
            var progressiveTaxTable = _progressiveTaxRepository.GetProgressiveTaxTable().Where(x=>x.LowerBound <= annualIncome);
            decimal tax = 0;
            foreach (var bracket in progressiveTaxTable)
            {
                if ((annualIncome >= bracket.LowerBound && bracket.UpperBound.HasValue && annualIncome <= bracket.UpperBound) || (!bracket.UpperBound.HasValue))
                {
                    tax += (annualIncome - bracket.LowerBound) * (bracket.Rate/100.0M);
                }
                else
                {
                    tax += (bracket.UpperBound.Value - bracket.LowerBound) * (bracket.Rate / 100.0M);
                }
            }
            return tax;
        }
    }
}
