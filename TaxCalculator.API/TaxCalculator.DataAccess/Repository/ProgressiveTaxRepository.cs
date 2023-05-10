using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxCalculator.DataAccess.Entities;
using TaxCalculator.Domain.Interfaces.Repository;
using TaxCalculator.Domain.Models;

namespace TaxCalculator.DataAccess.Repository
{
    public class ProgressiveTaxRepository : IProgressiveTaxRepository
    {
        private readonly TaxContext _context;
        private readonly IMapper _mapper;
        public ProgressiveTaxRepository(TaxContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProgressiveTaxModel> GetProgressiveTaxTable()
        {
            var progressiveTaxTable = _context.ProgressiveTax.OrderBy(x=>x.LowerBound).ToList();
            return _mapper.Map<List<ProgressiveTaxModel>>(progressiveTaxTable);
        }
    }
}
