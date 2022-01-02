using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class QuotesDBContext : DbContext
    {
        public QuotesDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasData
                (
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "Olucha",
                    LastName = "Boluevna",
                    Identification = true,
                    Balance = 0,
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "Anora",
                    LastName = "holova",
                    Identification = true,
                    Balance = 0,
                }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=quotedb.db");
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Transaction> transactions  { get; set; }

        public QuotesDBContext()
        {
        }

    }
}
