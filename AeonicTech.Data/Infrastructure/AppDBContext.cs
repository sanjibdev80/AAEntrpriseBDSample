using System;
using AeonicTech.Model.DBO;
using Microsoft.EntityFrameworkCore;

namespace AeonicTech.Data.Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options)
            : base(options)
        {
            //this.ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Office> Office { get; set; }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

    }
}
