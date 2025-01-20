using Microsoft.AspNetCore.Mvc;
using TestApp.Api.Services;

namespace TestApp.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SumController : ControllerBase
    {
        public SumService _sumService { get; set; }

        public SumController() 
        {
            this._sumService = new SumService();
        }

        [HttpGet(Name = "Sum")]
        public async Task<IActionResult> SumUpAsync()
        {
            try
            {
                var result = await _sumService.SumUpAsync();
                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception exception)
            {
                return await ControllerResponse.CreateExceptionResponse(this, exception);
            }
        }
    }
}
