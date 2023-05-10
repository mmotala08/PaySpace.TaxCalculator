using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataAccess.Entities;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.DataAccess.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<TaxCalculationOutputModel, TaxCalculationOutputs>().ReverseMap();
            CreateMap<TaxCalculationTypeModel, TaxCalculationType>().ReverseMap();
            CreateMap<ProgressiveTaxModel, ProgressiveTax>().ReverseMap();
        }
    }
}
