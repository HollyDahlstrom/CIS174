/*
 * Program.cs
 * EF Core Web App Lab - ContactsAppDahlstrom
 * 
 * Configures and runs the ASP.NET Core MVC application.
 * - Registers MVC services
 * - Registers Entity Framework Core with SQL Server
 * - Configures routing
 * - Runs the web server
 *
 * Author: Holly Dahlstrom
 * Date: Jan 23, 2026
 * Course: CIS174
 */

using ContactsAppDahlstrom.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Set Contacts page as the default startup page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contacts}/{action=Index}/{id?}");

app.Run();