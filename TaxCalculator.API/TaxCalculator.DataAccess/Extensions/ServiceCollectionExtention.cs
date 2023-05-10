using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TaxCalculator.DataAccess.Entities;
using TaxCalculator.DataAccess.Interfaces.Repository;
using TaxCalculator.DataAccess.Repository;
using TaxCalculator.Domain.Interfaces.Repository;

namespace TaxCalculator.DataAccess.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataAccessRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<TaxContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ITaxCalculationOutputRepository, TaxCalculationOutputRepository>();
            services.AddTransient<ITaxCalculationTypeRepository, TaxCalcationTypeRepository>();
            services.AddTransient<IProgressiveTaxRepository, ProgressiveTaxRepository>();
        }
    }
}
