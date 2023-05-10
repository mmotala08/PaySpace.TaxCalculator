using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.BusinessLogic.Factories;
using TaxCalculator.BusinessLogic.Factories.Interfaces;

namespace TaxCalculator.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddTransient<ITaxCalculationStrategyFactory, TaxCalculationStrategyFactory>();
        }
    }
}
