using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaxCalculator.Domain.Enums
{
    public enum TaxCalculationTypeEnum
    {
        [Description("Progressive")]
        Progressive = 1,
        [Description("Flat Value")]
        FlatValue = 2,
        [Description("Flat Rate")]
        FlatRate = 3
    }
}
