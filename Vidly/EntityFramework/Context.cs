using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.EntityFramework
{
    public class Context : DbContext
    {
        public Context() : base()
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Movie && (
                        e.State == EntityState.Added));

            foreach (var entityEntry in entries)
            {
                    ((Movie)entityEntry.Entity).DateAdded = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}