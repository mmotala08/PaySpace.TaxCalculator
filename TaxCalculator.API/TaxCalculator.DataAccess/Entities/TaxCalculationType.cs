using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaxCalculator.DataAccess.Entities
{
    public partial class TaxCalculationType
    {
        public int TaxTypeId { get; set; }
        public string PostalCode { get; set; }
        public int CalculationType { get; set; }
    }
}
