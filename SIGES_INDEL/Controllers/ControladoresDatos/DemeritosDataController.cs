using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class DemeritosDataController : Controller
    {
		private readonly IRepositorioDemeritosData _Irepositorio;

		public DemeritosDataController(IRepositorioDemeritosData Irepositorio)
		{
			_Irepositorio = Irepositorio;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View(await _Irepositorio.Index());
		}

		[HttpGet]
		public async Task<IActionResult> Crear()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(Demeritos demeritos)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(demeritos);
				TempData["mensaje"] = "Demerito creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(demeritos);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var demeritos = await _Irepositorio.Buscar(id);
			if (demeritos == null)
			{
				return NotFound();
			}
			return View(demeritos);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Demeritos demeritos)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(demeritos);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(demeritos);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var demeritos = await _Irepositorio.Buscar(id);
			if (demeritos == null)
			{
				return NotFound();
			}
			return View(demeritos);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var demeritos = await _Irepositorio.Buscar(id);
			if (demeritos == null)
			{
				return NotFound();
			}
			return View(demeritos);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarDemerito(Demeritos demeritos)
		{
			await _Irepositorio.Borrar(demeritos);
			TempData["mensaje"] = "Demerito eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
