using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;
        public ProgressiveTaxRepository(TaxContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public List<ProgressiveTaxModel> GetProgressiveTaxTable()
        {
            if (!_cache.TryGetValue("progressiveTaxTable", out List<ProgressiveTax> progressiveTaxTable))
            {
                // Cache miss, retrieve items from the data store.
                progressiveTaxTable = _context.ProgressiveTax.OrderBy(x => x.LowerBound).ToList();


                // Add the items to the cache with a sliding expiration of 5 minutes.
                _cache.Set("progressiveTaxTable", progressiveTaxTable, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(24)
                });
            }
            return _mapper.Map<List<ProgressiveTaxModel>>(progressiveTaxTable);
        }
    }
}
