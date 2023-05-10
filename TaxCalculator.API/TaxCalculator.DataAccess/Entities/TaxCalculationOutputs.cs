using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaxCalculator.DataAccess.Entities
{
    public partial class TaxCalculationOutputs
    {
        public int TaxCalculationOutputId { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal TaxValue { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
