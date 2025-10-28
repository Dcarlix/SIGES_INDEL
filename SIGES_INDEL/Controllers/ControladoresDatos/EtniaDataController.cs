using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class EtniaDataController : Controller
    {
		private readonly IRepositorioEtniaData _Irepositorio;
		string accion = "Etnia";
		public EtniaDataController(IRepositorioEtniaData Irepositorio)
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
		public async Task<IActionResult> Crear(Etnia etnia)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(etnia);
				TempData["mensaje"] = accion + " creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(etnia);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var etnia = await _Irepositorio.Buscar(id);
			if (etnia == null)
			{
				return NotFound();
			}
			return View(etnia);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Etnia etnia)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(etnia);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(etnia);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var etnia = await _Irepositorio.Buscar(id);
			if (etnia == null)
			{
				return NotFound();
			}
			return View(etnia);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var etnia = await _Irepositorio.Buscar(id);
			if (etnia == null)
			{
				return NotFound();
			}
			return View(etnia);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarEtnia(Etnia etnia)
		{
			await _Irepositorio.Borrar(etnia);
			TempData["mensaje"] = accion + " eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
