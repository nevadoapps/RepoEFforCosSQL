using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RepoEFCosSQLWeb.ConfigurationOptions;
using RepoEFCosSQLWeb.Context;

namespace RepoEFCosSQLWeb.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ILogger<CommonController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly AppDbContext _context;
        public CommonController(ILogger<CommonController> logger, IOptions<AppSettings> appSettings, AppDbContext context)
        {
            _logger = logger;
            _appSettings = appSettings;
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(new
            {
                Provider= _context.Database.ProviderName,
                Data = _context.Players.ToList()
            });
        }
    }
}
