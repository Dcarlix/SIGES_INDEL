using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class EstadoCivilDataController : Controller
    {
		private readonly IRepositorioEstadoCivilData _Irepositorio;
		string accion = "EstadoCivil";
		public EstadoCivilDataController(IRepositorioEstadoCivilData Irepositorio)
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
		public async Task<IActionResult> Crear(EstadoCivil estadoCivil)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(estadoCivil);
				TempData["mensaje"] = accion + " creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(estadoCivil);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var estadoCivil = await _Irepositorio.Buscar(id);
			if (estadoCivil == null)
			{
				return NotFound();
			}
			return View(estadoCivil);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(EstadoCivil estadoCivil)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(estadoCivil);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(estadoCivil);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var estadoCivil = await _Irepositorio.Buscar(id);
			if (estadoCivil == null)
			{
				return NotFound();
			}
			return View(estadoCivil);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var estadoCivil = await _Irepositorio.Buscar(id);
			if (estadoCivil == null)
			{
				return NotFound();
			}
			return View(estadoCivil);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarEstadoCivil(EstadoCivil estadoCivil)
		{
			await _Irepositorio.Borrar(estadoCivil);
			TempData["mensaje"] = accion + " eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
