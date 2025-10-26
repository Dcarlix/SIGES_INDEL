using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Datos.Repositorios;
using SIGES_INDEL.Datos.Repositorios.RepositoriosDatos;
using SIGES_INDEL.Datos.Repositorios.RepositoriosRegistro;
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
builder.Services.AddScoped<IRepositorioMeritos, RepositorioMeritos>();
builder.Services.AddScoped<IRepositorioDemeritos, RepositorioDemeritos>();
builder.Services.AddScoped<IRepositorioFichas, RepositorioFichas>();
builder.Services.AddScoped<IRepositorioActas, RepositorioActas>();
builder.Services.AddScoped<IRepositorioGrados, RepositorioGrados>();
builder.Services.AddScoped<IRepositorioMeritosData, RepositorioMeritosData>();
builder.Services.AddScoped<IRepositorioDemeritosData, RepositorioDemeritosData>();


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

using (var scope = app.Services.CreateScope())
{
	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
	string adminRole = "Administrador";
	if (!await roleManager.RoleExistsAsync(adminRole))
	{
		await roleManager.CreateAsync(new IdentityRole(adminRole));
	}
	string adminEmail = "admin@correo.com";
	string adminPassword = "Admin123*";
	var adminUser = await userManager.FindByEmailAsync(adminEmail);
	if (adminUser == null)
	{
		adminUser = new ApplicationUser
		{
			UserName = adminEmail,
			Email = adminEmail,
			EmailConfirmed = true
		};
		var result = await userManager.CreateAsync(adminUser, adminPassword);
		if (result.Succeeded)
		{
			await userManager.AddToRoleAsync(adminUser, adminRole);
		}
	}
}

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
