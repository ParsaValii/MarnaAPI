using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarnaDomain
{
    public class MarnaDbContextFactory : IDesignTimeDbContextFactory<MarnaDbContext>
    {
        public MarnaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MarnaDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=MarnaDb;Integrated Security=True;TrustServerCertificate=True;");

            return new MarnaDbContext(optionsBuilder.Options);
        }
    }
}
