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
            var result = _context.Players.ToList();

            return Ok(new
            {
                Provider= _context.Database.ProviderName,
                Count = result.Count,
                Data = result
            });
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string? id)
        {
            var result = _context.Players.Where(f => f.Id == id).ToList();
            return Ok(new
            {
                Provider = _context.Database.ProviderName,
                Count = result.Count,
                Data = result
            });
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<IActionResult> GeyByEmail(string? email)
        {
            var result = _context.Players.Where(f => f.Email == email).ToList();
            return Ok(new
            {
                Provider = _context.Database.ProviderName,
                Count = result.Count,
                Data = result
            });
        }

        [HttpGet("GetByActive/{active}")]
        public async Task<IActionResult> GetByActive(string active)
        {
            var result = _context.Players.Where(f => f.IsActive == bool.Parse(active)).ToList();
            return Ok(new
            {
                Provider = _context.Database.ProviderName,
                Count = result.Count,
                Data = result
            });
        }
    }
}
