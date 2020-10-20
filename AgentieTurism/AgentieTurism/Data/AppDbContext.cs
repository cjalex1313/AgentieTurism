using AgentieTurism.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Statiune> Statiuni { get; set; }
        public DbSet<Sejur> Sejururi { get; set; }
        public DbSet<Client> Clienti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statiune>().ToTable("Statiuni");
            modelBuilder.Entity<Sejur>().ToTable("Sejururi");
            modelBuilder.Entity<Client>().ToTable("Clienti");
        }
    }
}
