using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.DataAccess.Interfaces.Repository;
using TaxCalculator.Services.Services;
using TaxCalculatorServices.Abstractions.Interfaces;

namespace TaxCalculator.Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITaxCalculatorService, TaxCalculatorService>();
        }
    }
}
