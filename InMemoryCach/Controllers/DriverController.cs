using InMemoryCach.Data;
using InMemoryCach.Models;
using InMemoryCach.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryCach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController(AppDbContext dbContext,ICacheService cache) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Driver>> GetDrivers()
        {
            var Cachedrivers = cache.GetData<IEnumerable<Driver>>("driver");
            if (Cachedrivers is not null && Cachedrivers.Any())
                return Ok(Cachedrivers);
            var drivers = dbContext.Drivers.ToList();
            cache.SetData<IEnumerable<Driver>>("driver",drivers,DateTimeOffset.Now.AddMinutes(2));
            return Ok(drivers);
        }
    }
}
