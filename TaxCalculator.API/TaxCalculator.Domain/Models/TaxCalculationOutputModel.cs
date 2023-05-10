using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Domain.Models
{
    public class TaxCalculationOutputModel
    {
        public int TaxCalculationOutputId { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal TaxValue { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
