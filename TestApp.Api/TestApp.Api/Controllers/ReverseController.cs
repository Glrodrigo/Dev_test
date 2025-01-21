using Microsoft.AspNetCore.Mvc;
using TestApp.Api.Domain;
using TestApp.Api.Services;

namespace TestApp.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReverseController : ControllerBase
    {
        public ReverseService _reverseService { get; set; }

        public ReverseController()
        {
            this._reverseService = new ReverseService();
        }

        [HttpPost(Name = "Reverse")]
        public async Task<IActionResult> ReverseWordAsync([FromBody] ReverseParams reverseParams)
        {
            try
            {
                var result = await _reverseService.ReverseWordAsync(reverseParams);
                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception exception)
            {
                return await ControllerResponse.CreateExceptionResponse(this, exception);
            }
        }
    }
}
