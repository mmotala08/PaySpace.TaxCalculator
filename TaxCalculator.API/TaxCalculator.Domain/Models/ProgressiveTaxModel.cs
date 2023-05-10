using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Domain.Models
{
    public class ProgressiveTaxModel
    {
        public int ProgressiveTaxId { get; set; }
        public decimal Rate { get; set; }
        public decimal LowerBound { get; set; }
        public decimal? UpperBound { get; set; }
    }
}
