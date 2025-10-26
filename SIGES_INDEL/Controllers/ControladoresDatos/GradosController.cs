using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class GradosController : Controller
    {
		private readonly IRepositorioGrados _Irepositorio;

		public GradosController(IRepositorioGrados Irepositorio)
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
		public async Task<IActionResult> Crear(Grados grados)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(grados);
				TempData["mensaje"] = "Grado creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(grados);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var grado = await _Irepositorio.Buscar(id);
			if (grado == null)
			{
				return NotFound();
			}
			return View(grado);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Grados grados)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(grados);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(grados);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var grados = await _Irepositorio.Buscar(id);
			if (grados == null)
			{
				return NotFound();
			}
			return View(grados);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var grados = await _Irepositorio.Buscar(id);
			if (grados == null)
			{
				return NotFound();
			}
			return View(grados);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarGrados(Grados grados)
		{
			await _Irepositorio.Borrar(grados);
			TempData["mensaje"] = "Grado eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
