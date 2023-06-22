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

        public DbSet<app.Models.Department> Departments { get; set; }

        public DbSet<app.Models.Seller> Sellers { get; set; }
        public DbSet<app.Models.SalesRecord> SalesRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=SalesWebMVC;uid=root;pwd=root", ServerVersion.Parse("7.0.0"));
        }

        public void ConfigureService(IServiceCollection service)
        {
            service.AddScoped<SeedingService>();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, SeedingService seeding)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seeding.Seed();
            }
            else
            {

                app.UseExceptionHandler("/Home/Error")
                        .UseHsts();
            }
        }
    }
}
