using System.Text;
using Microsoft.AspNetCore.Authentication;
using Portfolio.Context;
using Portfolio.Repositories;
using AuthenticationService = Portfolio.Services.AuthenticationService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<PortfolioRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Portfolio}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
