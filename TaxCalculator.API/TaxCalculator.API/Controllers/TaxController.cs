using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaxCalculator.API.Dto;
using TaxCalculatorServices.Abstractions.Interfaces;

namespace TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxCalculatorService _taxCalculatorService;
        public TaxController(ITaxCalculatorService taxCalculatorService)
        {
            _taxCalculatorService = taxCalculatorService;
        }
        /// <summary>
        /// Calculate Tax
        /// </summary>
        [Produces(typeof(decimal))]
        [HttpPost]
        [Route("CalculateTax")]
        public decimal CalculateTax(CalculateTaxDto dto)
        {
            return _taxCalculatorService.CalculateTax(dto.PostalCode,dto.AnnualIncome);
        }
    }
}
