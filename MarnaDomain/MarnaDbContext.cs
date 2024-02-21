using MarnaDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarnaDomain
{
    public class MarnaDbContext : DbContext
    {
        public MarnaDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer(
                "Server=localhost;Database=MarnaDb;Integrated Security=True;TrustServerCertificate=True;"
            );
        }
        public MarnaDbContext(DbContextOptions<MarnaDbContext> options) : base(options) { }

        public DbSet<Employee> Employees{ get; set; }
    }
}
