using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TaxCalculator.Web.Services;

namespace TaxCalculator.Web.Pages
{
    public class TaxCalculatorModel : PageModel
    {
        private ITaxCalculatorService _taxCalculatorService;

        public TaxCalculatorModel(ITaxCalculatorService taxCalculatorService)
        {
            _taxCalculatorService = taxCalculatorService;
        }

        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Please enter a 4 character postal code")]
        [BindProperty]
        public string PostalCode { get; set; }

        [Required]
        [Range(1,double.MaxValue)]
        [BindProperty]
        public decimal AnnualIncome { get; set; }
        [BindProperty]
        public decimal? TaxAmount { get; private set; }
        public string ErrorMessage { get; private set; }
        public void OnGet()
        {
        }
        public async Task OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please enter a valid postal code and annual income.";
                return;
            }
            try
            {
                TaxAmount = await _taxCalculatorService.CalculateTaxAsync(PostalCode, AnnualIncome);
            }
            catch(Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}
