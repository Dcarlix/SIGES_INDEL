using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class MeritosDataController : Controller
    {
		private readonly IRepositorioMeritosData _Irepositorio;

		public MeritosDataController(IRepositorioMeritosData Irepositorio)
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
		public async Task<IActionResult> Crear(Meritos meritos)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(meritos);
				TempData["mensaje"] = "Merito creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(meritos);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var meritos = await _Irepositorio.Buscar(id);
			if (meritos == null)
			{
				return NotFound();
			}
			return View(meritos);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Meritos meritos)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(meritos);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(meritos);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var meritos = await _Irepositorio.Buscar(id);
			if (meritos == null)
			{
				return NotFound();
			}
			return View(meritos);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var meritos = await _Irepositorio.Buscar(id);
			if (meritos == null)
			{
				return NotFound();
			}
			return View(meritos);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarMerito(Meritos meritos)
		{
			await _Irepositorio.Borrar(meritos);
			TempData["mensaje"] = "Merito eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
