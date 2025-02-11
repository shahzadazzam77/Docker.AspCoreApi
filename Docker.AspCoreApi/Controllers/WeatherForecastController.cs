using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Docker.AspCoreApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherDbContext _context;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(WeatherDbContext context, ILogger<WeatherController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Weather
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeathers()
        {
            return await _context.Weathers.ToListAsync();
        }

        // GET: api/Weather/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weather>> GetWeather(int id)
        {
            if (id == 1)
            {
                return StatusCode(401, "UnAuth Error");
            }
            else if (id == 2)
            {
                // Simulate a server error
                return StatusCode(500, "Internal Server Error");
            }
            else if (id == 5 || id == 9 || id >= 12)
            {
                _logger.LogInformation($"error StatusCodes.Status429TooManyRequests");
                return StatusCode(StatusCodes.Status429TooManyRequests, "Rate limit exceeded. Please try again later.");
            }

            var weather = await _context.Weathers.FindAsync(id);
            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // POST: api/Weather
        [HttpPost]
        public async Task<ActionResult<Weather>> PostWeather(Weather weather)
        {
            _context.Weathers.Add(weather);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWeather), new { id = weather.Id }, weather);
        }

        // PUT: api/Weather/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(int id, Weather weather)
        {
            if (id != weather.Id)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Weathers.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Weather/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(int id)
        {
            var weather = await _context.Weathers.FindAsync(id);
            if (weather == null)
            {
                return NotFound();
            }

            _context.Weathers.Remove(weather);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}