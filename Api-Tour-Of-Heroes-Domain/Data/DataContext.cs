using Microsoft.EntityFrameworkCore;
using Api_Tour_Of_Heroes_Domain.Mappers;
using Api_Tour_Of_Heroes_Domain.Entities;

namespace Api_Tour_Of_Heroes_Domain.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        { }

        public DbSet<Hero>? Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HeroMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
