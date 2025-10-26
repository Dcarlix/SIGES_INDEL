using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Controllers.ControladoresRegistros
{
    public class ActasController : Controller
    {
		private readonly IRepositorioActas _Irepositorio;
		private readonly IRepositorioUtilidades _IrepositorioUtilidades;

		public ActasController(IRepositorioActas Irepositorio, IRepositorioUtilidades repositorioUtilidades)
		{
			_Irepositorio = Irepositorio;
			_IrepositorioUtilidades = repositorioUtilidades;
		}

		[HttpGet]
		public async Task<IActionResult> Crear(int id)
		{
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(id);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(ActasAsignadas actasAsignada)
		{
			if (ModelState.IsValid)
			{
				actasAsignada.Id = 0;
				await _Irepositorio.Crear(actasAsignada);
				TempData["mensaje"] = "Acta Agregada correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index", "Expedientes", new { id = actasAsignada.EstudianteId });
			}

			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(actasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(actasAsignada);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var actasAsignada = await _Irepositorio.Buscar(id);
			if (actasAsignada == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(actasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(actasAsignada);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(ActasAsignadas actasAsignada)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(actasAsignada);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index", "Expedientes", new { id = actasAsignada.EstudianteId });
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(actasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(actasAsignada);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int id)
		{
			var actasAsignada = await _Irepositorio.Buscar(id);
			if (actasAsignada == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(actasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(actasAsignada);
		}


		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var actasAsignada = await _Irepositorio.Buscar(id);
			if (actasAsignada == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(actasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(actasAsignada);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarActasAsignada(ActasAsignadas actasAsignada)
		{
			if (actasAsignada == null)
			{
				return View();
			}

			await _Irepositorio.Borrar(actasAsignada);
			TempData["mensaje"] = "Acta Eliminada correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction("Index", "Expedientes", new { id = actasAsignada.EstudianteId });
		}
	}
}
