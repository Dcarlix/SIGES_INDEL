using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class ParentescoDataController : Controller
    {
		private readonly IRepositorioParentescoData _Irepositorio;
		string accion = "Parentesco";
		public ParentescoDataController(IRepositorioParentescoData Irepositorio)
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
		public async Task<IActionResult> Crear(Parentesco parentesco)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(parentesco);
				TempData["mensaje"] = accion + " creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(parentesco);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var parentesco = await _Irepositorio.Buscar(id);
			if (parentesco == null)
			{
				return NotFound();
			}
			return View(parentesco);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Parentesco parentesco)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(parentesco);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(parentesco);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var parentesco = await _Irepositorio.Buscar(id);
			if (parentesco == null)
			{
				return NotFound();
			}
			return View(parentesco);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var parentesco = await _Irepositorio.Buscar(id);
			if (parentesco == null)
			{
				return NotFound();
			}
			return View(parentesco);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarParentesco(Parentesco parentesco)
		{
			await _Irepositorio.Borrar(parentesco);
			TempData["mensaje"] = accion + " eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
