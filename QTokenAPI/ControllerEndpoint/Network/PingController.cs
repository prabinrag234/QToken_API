using Microsoft.AspNetCore.Mvc;

namespace QTokenAPI.ControllerEndpoint.Network
{
    [ApiController]
    [Route("qtoken")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Status = "Online", Timestamp = DateTime.UtcNow });
        }
    }
}
