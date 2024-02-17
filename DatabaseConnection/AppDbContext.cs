using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Quote> Quotes { get; set; }

    }
}
