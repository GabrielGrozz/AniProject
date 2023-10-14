using AniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AniProject.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
