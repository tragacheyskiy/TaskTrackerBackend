using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace TaskTrackerBackend.Controllers.Abstractions;

[ApiController, Produces(MediaTypeNames.Application.Json)]
public abstract class BaseController : ControllerBase
{
}
