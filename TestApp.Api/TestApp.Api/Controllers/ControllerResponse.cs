using Microsoft.AspNetCore.Mvc;
using TestApp.Api.Domain;

namespace TestApp.Api.Controllers
{
    public static class ControllerResponse
    {
        public static async Task<IActionResult> CreateExceptionResponse(this ControllerBase controller, Exception error)
        {
            var errors = new List<ErrorDomain>();

            var result = new ErrorDomain
            {
                ErrorCode = "00001",
                ErrorType = "Erro interno, tente novamente mais tarde"
            };

            errors.Add(result);

            return await Task.FromResult(controller.BadRequest(new { messages = errors }));
        }
    }
}
