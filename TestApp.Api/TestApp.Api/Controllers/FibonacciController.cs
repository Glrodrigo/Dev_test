using Microsoft.AspNetCore.Mvc;
using TestApp.Api.Domain;
using TestApp.Api.Services;

namespace TestApp.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        public FibonacciService _fibonacciService { get; set; }

        public FibonacciController()
        {
            this._fibonacciService = new FibonacciService();
        }

        [HttpPost(Name = "Fibonacci")]
        public async Task<IActionResult> CalculateFibonacciAsync([FromBody] FibonacciParams fibonacciParams)
        {
            try
            {
                var result = await _fibonacciService.CalculateFibonacciAsync(fibonacciParams);
                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception exception)
            {
                return await ControllerResponse.CreateExceptionResponse(this, exception);
            }
        }
    }
}
