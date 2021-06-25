using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AeonicTech.Data.Infrastructure
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=AeonicTechDB; User Id = sa; Password=Asdf@1234;");

            return new AppDBContext(optionsBuilder.Options);
        }
    }

}
