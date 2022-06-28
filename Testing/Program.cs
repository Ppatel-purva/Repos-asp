using Microsoft.EntityFrameworkCore;
using Testing.Models;
using Microsoft.Extensions.DependencyInjection;
using Testing.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestingContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("TestingContext")));

builder.Services.AddDbContext<EmployeeContext>(opts =>
opts.UseSqlServer
(builder.Configuration.
GetConnectionString("sqlConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

//app.MigrateDatabase();
app.Run();
