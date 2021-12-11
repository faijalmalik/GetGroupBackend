using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt ) : base(opt)
        {
            
        }

        public DbSet<Employee> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<Employee>()
        //        .HasMany(p => p.Id)
        //        .WithOne(p=> p.Platform!)
        //        .HasForeignKey(p => p.PlatformId);

        //    modelBuilder
        //        .Entity<Command>()
        //        .HasOne(p => p.Platform)
        //        .WithMany(p => p.Commands)
        //        .HasForeignKey(p =>p.PlatformId);
        //}
    }
}