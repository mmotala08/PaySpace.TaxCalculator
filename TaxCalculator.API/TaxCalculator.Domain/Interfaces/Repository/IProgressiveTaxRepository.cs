using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.Domain.Interfaces.Repository
{
    public interface IProgressiveTaxRepository
    {
        public List<ProgressiveTaxModel> GetProgressiveTaxTable();
    }
}
