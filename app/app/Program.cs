﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using app.Data;
using System;
using app.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<appContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("appContext"), ServerVersion.Parse("7.0.0") ?? throw new InvalidOperationException("Connection string 'appContext' not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    using (var scope = app.Services.CreateScope())
    {
        var seeding = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seeding.Seed();

        var sellerService = scope.ServiceProvider.GetRequiredService<SellerService>();

    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
