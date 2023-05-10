using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Domain.Models
{
    public class TaxCalculationTypeModel
    {
        public string PostalCode { get; set; }

        public int CalculationType { get; set; }
    }
}
