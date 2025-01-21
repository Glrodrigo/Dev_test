using Microsoft.AspNetCore.Mvc;
using TestApp.Api.Services;

namespace TestApp.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class InvoiceSalesController : ControllerBase
    {
        public InvoiceSalesService _invoiceSalesService { get; set; }

        public InvoiceSalesController() 
        { 
            this._invoiceSalesService = new InvoiceSalesService();
        }

        [HttpGet(Name = "InvoiceSales")]
        public async Task<IActionResult> AverageSalesAsync()
        {
            try
            {
                var result = await _invoiceSalesService.AverageSalesAsync();
                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception exception)
            {
                return await ControllerResponse.CreateExceptionResponse(this, exception);
            }
        }
    }
}
