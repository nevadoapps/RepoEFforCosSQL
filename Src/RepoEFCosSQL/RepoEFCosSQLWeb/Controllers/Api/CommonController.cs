using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RepoEFCosSQLWeb.ConfigurationOptions;

namespace RepoEFCosSQLWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ILogger<CommonController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        public CommonController(ILogger<CommonController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject(_appSettings.Value.ConnectionStrings));
        }
    }
}
