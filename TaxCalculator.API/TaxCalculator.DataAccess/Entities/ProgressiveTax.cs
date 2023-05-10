using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaxCalculator.DataAccess.Entities
{
    public partial class ProgressiveTax
    {
        public int ProgressiveTaxId { get; set; }
        public decimal Rate { get; set; }
        public decimal LowerBound { get; set; }
        public decimal? UpperBound { get; set; }
    }
}
