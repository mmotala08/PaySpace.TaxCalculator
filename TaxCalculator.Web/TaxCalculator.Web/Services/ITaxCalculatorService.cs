namespace TaxCalculator.Web.Services
{
    public interface ITaxCalculatorService
    {
        Task<decimal?> CalculateTaxAsync(string postalCode, decimal? annualIncome);
    }
}
