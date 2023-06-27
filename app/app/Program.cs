using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using app.Data;
using System;
using app.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<appContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("appContext"), ServerVersion.Parse("7.0.0") ?? throw new InvalidOperationException("Connection string 'appContext' not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();

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
        var departmentService = scope.ServiceProvider.GetRequiredService<DepartmentService>();

    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var enUS = new CultureInfo("en-US");
var localizationOtions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

app.UseRequestLocalization(localizationOtions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
