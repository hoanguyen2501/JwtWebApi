using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        public BaseApiController()
        {
        }
    }
}