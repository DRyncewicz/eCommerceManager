using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceManager.API.Controllers.Base;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion(EcmApiVersion.Version1)]
public class BaseController : ControllerBase
{
}