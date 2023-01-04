using API_BARBEARIA.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BARBEARIA.DAL
{
    public class BarbeariaContext : DbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<Scheduling> scheduling { get; set; }
        public DbSet<Barber> barber { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("BARBEARIA_CONNECTION");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
               .HasIndex(u => u.CPF)
               .IsUnique();

           

            builder.Entity<Scheduling>()
               .Property(p => p.Barber)
               .HasConversion<string>();

        }


    }
}

