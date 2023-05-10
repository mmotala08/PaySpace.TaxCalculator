using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxCalculator.DataAccess.Entities;
using TaxCalculator.DataAccess.Interfaces.Repository;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.DataAccess.Repository
{
    public class TaxCalcationTypeRepository : ITaxCalculationTypeRepository
    {
        TaxContext _context;
        IMapper _mapper;
        public TaxCalcationTypeRepository(TaxContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public TaxCalculationTypeModel GetTaxCalculationType(string postalCode)
        {
            var taxType = _context.TaxCalculationType.Where(x => x.PostalCode == postalCode).SingleOrDefault();
            return _mapper.Map<TaxCalculationTypeModel>(taxType);
        }
    }
}
