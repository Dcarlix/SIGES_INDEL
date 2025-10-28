using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;

namespace SIGES_INDEL.Controllers.ControladoresDatos
{
    public class NacionalidadesDataController : Controller
    {
		private readonly IRepositorioNacionalidadesData _Irepositorio;
		string accion = "Nacionalidad";
		public NacionalidadesDataController(IRepositorioNacionalidadesData Irepositorio)
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
		public async Task<IActionResult> Crear(Nacionalidades nacionalidades)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Crear(nacionalidades);
				TempData["mensaje"] = accion + " creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(nacionalidades);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var nacionalidades = await _Irepositorio.Buscar(id);
			if (nacionalidades == null)
			{
				return NotFound();
			}
			return View(nacionalidades);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Nacionalidades nacionalidades)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(nacionalidades);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			return View(nacionalidades);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var nacionalidades = await _Irepositorio.Buscar(id);
			if (nacionalidades == null)
			{
				return NotFound();
			}
			return View(nacionalidades);
		}

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var nacionalidades = await _Irepositorio.Buscar(id);
			if (nacionalidades == null)
			{
				return NotFound();
			}
			return View(nacionalidades);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarParentesco(Nacionalidades nacionalidades)
		{
			await _Irepositorio.Borrar(nacionalidades);
			TempData["mensaje"] = accion + " eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}
	}
}
