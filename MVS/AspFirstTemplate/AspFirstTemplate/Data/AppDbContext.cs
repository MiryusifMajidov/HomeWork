using AspFirstTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace AspFirstTemplate.Data
{
    public class AppDbContext:DbContext
    {

        private readonly DbContextOptions _options;

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
           
        }

        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<ResponseMessage> ResponseMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
