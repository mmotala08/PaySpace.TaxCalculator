using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.DataAccess.Interfaces.Repository
{
    public interface ITaxCalculationTypeRepository
    {
        public TaxCalculationTypeModel GetTaxCalculationType(string postalCode);
    }
}
