using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Datos.Repositorios;
using SIGES_INDEL.Models;

var builder = WebApplication.CreateBuilder(args);

var politicaUsuariosAutenticados = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews(opciones =>
{
	opciones.Filters.Add(new AuthorizeFilter(politicaUsuariosAutenticados));
});

builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("Cnn")));

builder.Services.AddScoped<IRepositorioEstudiantes, RepositorioEstudiantes>();
builder.Services.AddScoped<IRepositorioUtilidades, RepositorioUtilidades>();
builder.Services.AddScoped<IRepositorioMatriculas, RepositorioMatriculas>();
builder.Services.AddScoped<IRepositorioDocentes, RepositorioDocentes>();
builder.Services.AddScoped<IRepositorioExpedientes, RepositorioExpedientes>();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opciones =>
{
	opciones.SignIn.RequireConfirmedAccount = false;

})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// para usar mis propias vistas y no usar las que me da el framework
builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ExternalScheme, opciones =>
{
	//usar mi propia vista
	opciones.LoginPath = "/Usuarios/Login";
	//para cuando al usuario se le ha negado el acceso
	opciones.AccessDeniedPath = "/Usuarios/Login";
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();


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

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuarios}/{action=Login}/{id?}");

app.Run();
