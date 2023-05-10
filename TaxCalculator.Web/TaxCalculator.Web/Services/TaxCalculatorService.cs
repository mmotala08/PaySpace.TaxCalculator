using System.Text.Json;
using System.Text;

namespace TaxCalculator.Web.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public TaxCalculatorService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            _baseUrl = _configuration["baseUrl"];
        }

        public async Task<decimal?> CalculateTaxAsync(string postalCode, decimal? annualIncome)
        {
            try
            {
                var request = new { PostalCode = postalCode, AnnualIncome = annualIncome };
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_baseUrl}/tax/calculatetax", content);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<decimal>(responseContent);

                return result;
            }
            catch (Exception)
            {
                // TODO log the exception
                throw new Exception("An unexpected error occurred whilst calculating the tax value");
            }
        }
    }
}
