using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class DiscapacidadesDataController : Controller
    {
		private readonly IRepositorioDiscapacidadesData _Irepositorio;
		string accion = "Discapacidad";
		public DiscapacidadesDataController(IRepositorioDiscapacidadesData Irepositorio)
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
		public async Task<IActionResult> Crear(Discapacidades discapacidades)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(discapacidades);
				TempData["mensaje"] = accion + " creada correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(discapacidades);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var discapacidades = await _Irepositorio.Buscar(id);
			if (discapacidades == null)
			{
				return NotFound();
			}
			return View(discapacidades);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Discapacidades discapacidades)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(discapacidades);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(discapacidades);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var discapacidades = await _Irepositorio.Buscar(id);
			if (discapacidades == null)
			{
				return NotFound();
			}
			return View(discapacidades);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var discapacidades = await _Irepositorio.Buscar(id);
			if (discapacidades == null)
			{
				return NotFound();
			}
			return View(discapacidades);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarDiscapacidades(Discapacidades discapacidades)
		{
			await _Irepositorio.Borrar(discapacidades);
			TempData["mensaje"] = accion + " eliminada correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
