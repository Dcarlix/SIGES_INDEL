using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos;
using SIGES_INDEL.Models;

namespace SIGES_INDEL.Controllers
{
    public class UsuariosController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ApplicationDbContext _context;
		public UsuariosController(UserManager<ApplicationUser> userManager,	SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
		}

		[AllowAnonymous]
		public IActionResult Registro()
		{
			ViewData["Docentes"] = _context.TDocentes.ToList(); // para dropdown
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Registro(RegistroViewModel modelo)
		{
			ViewData["Docentes"] = _context.TDocentes.ToList();

			if (!ModelState.IsValid)
			{
				Console.WriteLine("❌ Modelo no válido.");
				return View(modelo);
			}

			var usuario = new ApplicationUser
			{
				Email = modelo.Email,
				UserName = modelo.Email,
				DocenteId = modelo.DocenteId  // puede ser null si no aplica
			};

			var resultado = await _userManager.CreateAsync(usuario, modelo.Password);

			if (resultado.Succeeded)
			{
				Console.WriteLine("✅ Usuario creado correctamente");
				await _signInManager.SignInAsync(usuario, isPersistent: true);
				return RedirectToAction("Index", "Home");
			}

			// 🔥 Mostrar los errores en pantalla y consola
			foreach (var error in resultado.Errors)
			{
				Console.WriteLine($"Error: {error.Description}");
				ModelState.AddModelError(string.Empty, error.Description);
			}

			return View(modelo);
		}

		[AllowAnonymous]
		public IActionResult Login() => View();

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel modelo)
		{
			if (!ModelState.IsValid)
				return View(modelo);

			await _signInManager.SignOutAsync(); // Evita sesiones previas

			var resultado = await _signInManager.PasswordSignInAsync(
				modelo.Email, modelo.Password, modelo.Recuerdame, lockoutOnFailure: false);

			if (resultado.Succeeded)
			{
				Console.WriteLine("✅ Inicio de sesión exitoso");
				return RedirectToAction("Index", "Home"); // cambiá "Menu" por Home si esa es tu vista principal
			}

			if (resultado.IsLockedOut)
				ModelState.AddModelError("", "Cuenta bloqueada por demasiados intentos.");

			ModelState.AddModelError(string.Empty, "Nombre o contraseña incorrectos.");
			return View(modelo);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login", "Usuarios");
		}
	}
}
