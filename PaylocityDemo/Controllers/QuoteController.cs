using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaylocityDemo.Services;
using PaylocityDemo.ViewModels;

namespace PaylocityDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        public readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        // POST: Quote
        [Authorize(Policy = "ApiKeyPolicy")]
        [HttpPost]
        public object Post([FromBody] EmployeeViewModel value)
        {
            if (ModelState.IsValid)
            {
                var data = _quoteService.CalculateBenefits(value);
                return data;
            }

            return new { response = "error" };
        }
    }
}
