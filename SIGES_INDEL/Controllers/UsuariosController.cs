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
			var docentesConCuenta = _context.Users
					   .Where(u => u.DocenteId != null)
					   .Select(u => u.DocenteId)
					   .ToList();

			ViewData["Docentes"] = _context.TDocentes.Where(d => !docentesConCuenta.Contains(d.Id)).ToList();
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Registro(RegistroViewModel modelo)
		{
			ViewData["Docentes"] = _context.TDocentes.ToList();

			var docenteTieneCuenta = _context.Users.Any(u => u.DocenteId == modelo.DocenteId);

			if (docenteTieneCuenta)
			{
				ModelState.AddModelError("DocenteId", "Este docente ya tiene una cuenta registrada.");
				ViewData["Docentes"] = _context.TDocentes
					.Where(d => !_context.Users.Select(u => u.DocenteId).Contains(d.Id))
					.ToList();
				return View(modelo);
			}

			if (!ModelState.IsValid)
			{
				return View(modelo);
			}

			var usuario = new ApplicationUser
			{
				Email = modelo.Email,
				UserName = modelo.Email,
				DocenteId = modelo.DocenteId 
			};

			var resultado = await _userManager.CreateAsync(usuario, modelo.Password);

			if (resultado.Succeeded)
			{
				await _signInManager.SignInAsync(usuario, isPersistent: true);
				return RedirectToAction("Index", "Home");
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

			await _signInManager.SignOutAsync();

			var resultado = await _signInManager.PasswordSignInAsync(
				modelo.Email, modelo.Password, modelo.Recuerdame, lockoutOnFailure: false);

			if (resultado.Succeeded)
			{
				return RedirectToAction("Index", "Home");
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
