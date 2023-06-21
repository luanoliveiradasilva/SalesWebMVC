using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Configuration;

namespace app.Data
{
    public class appContext : DbContext
    {
        public appContext(DbContextOptions<appContext> options)
            : base(options)
        {
        }

        public DbSet<app.Models.Departments> Departments { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=SalesWebMVC;uid=root;pwd=root", ServerVersion.Parse("7.0.0"));
        }
    }
}
