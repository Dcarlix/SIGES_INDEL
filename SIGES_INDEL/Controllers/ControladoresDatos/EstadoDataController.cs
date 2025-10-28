using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class EstadoDataController : Controller
    {
		private readonly IRepositorioEstadoData _Irepositorio;
		string accion = "Estado";
		public EstadoDataController(IRepositorioEstadoData Irepositorio)
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
		public async Task<IActionResult> Crear(Estado estado)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(estado);
				TempData["mensaje"] = accion + " creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(estado);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var estado = await _Irepositorio.Buscar(id);
			if (estado == null)
			{
				return NotFound();
			}
			return View(estado);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Estado estado)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(estado);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(estado);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var estado = await _Irepositorio.Buscar(id);
			if (estado == null)
			{
				return NotFound();
			}
			return View(estado);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var estado = await _Irepositorio.Buscar(id);
			if (estado == null)
			{
				return NotFound();
			}
			return View(estado);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarEstado(Estado estado)
		{
			await _Irepositorio.Borrar(estado);
			TempData["mensaje"] = accion + " eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
