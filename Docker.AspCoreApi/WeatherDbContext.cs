using Microsoft.EntityFrameworkCore;

namespace Docker.AspCoreApi
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Weather> Weathers { get; set; }
    }
}
