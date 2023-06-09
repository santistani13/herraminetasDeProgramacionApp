using EquiposDeFutbol.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEquiposDeFutbol.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcEquiposDeFutbolContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcEquiposDeFutbolContext") ?? throw new InvalidOperationException("Connection string 'MvcEquiposDeFutbolContext' not found.")));

// Add services to the container.
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MvcEquiposDeFutbolContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEquipoService, EquipoService>();
builder.Services.AddScoped<ILigaService, LigaService>();


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
    pattern: "{controller=EquiposDeFutbol}/{action=Index}/{id?}");

app.MapRazorPages();


app.Run();
