using Microsoft.AspNetCore.Mvc;
using TestApp.Api.Services;

namespace TestApp.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DistribuitorSalesController : ControllerBase
    {
        public PercentageSalesService _percentageSalesService { get; set; }

        public DistribuitorSalesController()
        {
            this._percentageSalesService = new PercentageSalesService();
        }

        [HttpGet(Name = "PercentageSales")]
        public async Task<IActionResult> PercentageSalesAsync()
        {
            try
            {
                var result = await _percentageSalesService.PercentageSalesAsync();
                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception exception)
            {
                return await ControllerResponse.CreateExceptionResponse(this, exception);
            }
        }
    }
}
