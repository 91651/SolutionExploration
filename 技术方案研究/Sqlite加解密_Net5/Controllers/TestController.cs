using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sqlite加解密_Net5.Data;

namespace Sqlite加解密_Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;
        private readonly AppDbContext _db;
        public TestController(ILogger<TestController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("/data")]
        public async Task GetData()
        {
            var data = await _db.Customers.ToListAsync();
        }

    }
}
