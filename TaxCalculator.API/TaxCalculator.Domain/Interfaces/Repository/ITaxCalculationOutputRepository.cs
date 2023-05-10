using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.DataAccess.Interfaces.Repository
{
    public interface ITaxCalculationOutputRepository
    {
        public List<TaxCalculationOutputModel> GetAll();
        public TaxCalculationOutputModel Insert(TaxCalculationOutputModel model);
    }
}
