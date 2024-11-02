using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Click2Rent.Database
{
    public class Click2RentDbFactory : IDesignTimeDbContextFactory<Click2RentContext>
    {
        public Click2RentContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<Click2RentContext>();
            options
                .UseSqlServer("Server=.;Database=Click2RentDB;Trusted_Connection=True;TrustServerCertificate=True;");
            return new Click2RentContext(options.Options);
        }
    }
}
