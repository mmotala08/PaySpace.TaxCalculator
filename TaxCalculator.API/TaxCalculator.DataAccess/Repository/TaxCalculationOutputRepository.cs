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
    public class TaxCalculationOutputRepository : ITaxCalculationOutputRepository
    {
        TaxContext _context;
        IMapper _mapper;
        public TaxCalculationOutputRepository(TaxContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TaxCalculationOutputModel> GetAll()
        {
            var outputs = _context.TaxCalculationOutputs.ToList();
            return _mapper.Map<List<TaxCalculationOutputs>, List<TaxCalculationOutputModel>>(outputs);
        }

        public TaxCalculationOutputModel Insert(TaxCalculationOutputModel model)
        {

            TaxCalculationOutputs taxCalculationOutput = _mapper.Map<TaxCalculationOutputs>(model);

            var outputResult = _context.TaxCalculationOutputs.Add(taxCalculationOutput);
            _context.SaveChanges();
            return _mapper.Map<TaxCalculationOutputModel>(outputResult.Entity);

        }
    }
}
