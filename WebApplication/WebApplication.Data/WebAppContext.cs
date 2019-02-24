using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication.Data
{
    public class WebAppContext : DbContext
    {
        private readonly string _connectionString;

        public WebAppContext(string connectionString)
        {
            _connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        // public DbSet<T> Ts { get; set; }
    }
}
