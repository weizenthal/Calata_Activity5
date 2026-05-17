using Microsoft.EntityFrameworkCore;
using Calata_Activity4.Models;

namespace Calata_Activity4.Data
{
    public class CalataDbContext : DbContext
    {
        public CalataDbContext(DbContextOptions<CalataDbContext> options)
            : base(options)
        {
        }

        // This explicitly creates the physical database table mapping
        public DbSet<YouTubeVideo> YouTubeVideos { get; set; }
    }
}