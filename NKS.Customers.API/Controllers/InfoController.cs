using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NKS.Customers.API.Configuration;

namespace NKS.Customers.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfoController : Controller
    {
        private readonly IOptions<Swagger> _swagger;

        public InfoController(IOptions<Swagger> swagger)
        {
            _swagger = swagger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var assembly = typeof(Startup).Assembly;

            var info = new ApiInfo
            {
                Version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion,
                CreationDate = System.IO.File.GetCreationTime(assembly.Location),
                ApiVersionInfo = _swagger.Value
            };

            return Ok(info);
        }
    }
}
