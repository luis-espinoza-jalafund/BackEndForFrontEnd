using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace BackEndForFrontEnd.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult HandleException(Exception e)
    {
        HttpStatusCode statusCode;
        string message;

        switch (e)
        {
            case ArgumentException argumentException:
                statusCode = HttpStatusCode.BadRequest;
                message = argumentException.Message;
                break;

            case Exception exception:
                statusCode = HttpStatusCode.NotAcceptable;
                message = exception.Message;
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
                break;
        }

        return StatusCode((int)statusCode, new { Error = message });
    }
}
