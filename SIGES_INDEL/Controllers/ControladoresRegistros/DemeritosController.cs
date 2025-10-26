using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Controllers.ControladoresRegistros
{
    public class DemeritosController : Controller
    {
		private readonly IRepositorioDemeritos _Irepositorio;
		private readonly IRepositorioUtilidades _IrepositorioUtilidades;

		public DemeritosController(IRepositorioDemeritos Irepositorio, IRepositorioUtilidades repositorioUtilidades)
		{
			_Irepositorio = Irepositorio;
			_IrepositorioUtilidades = repositorioUtilidades;
		}

		[HttpGet]
		public async Task<IActionResult> Crear(int id)
		{
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(id);
			ViewBag.demeritos = await _IrepositorioUtilidades.ListarDemeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(DemeritosAsignados demeritosAsignado)
		{
			if (ModelState.IsValid)
			{
				demeritosAsignado.Id = 0;
				await _Irepositorio.Crear(demeritosAsignado);
				TempData["mensaje"] = "Demerito Agregado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index", "Expedientes", new { id = demeritosAsignado.EstudianteId });
			}

			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(demeritosAsignado.EstudianteId);
			ViewBag.demeritos = await _IrepositorioUtilidades.ListarDemeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(demeritosAsignado);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var demeritosAsignado = await _Irepositorio.Buscar(id);
			if (demeritosAsignado == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(demeritosAsignado.EstudianteId);
			ViewBag.demeritos = await _IrepositorioUtilidades.ListarDemeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(demeritosAsignado);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(DemeritosAsignados demeritosAsignado)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(demeritosAsignado);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index", "Expedientes", new { id = demeritosAsignado.EstudianteId });
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(demeritosAsignado.EstudianteId);
			ViewBag.demeritos = await _IrepositorioUtilidades.ListarDemeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(demeritosAsignado);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int id)
		{
			var demeritosAsignado = await _Irepositorio.Buscar(id);
			if (demeritosAsignado == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(demeritosAsignado.EstudianteId);
			ViewBag.demeritos = await _IrepositorioUtilidades.ListarDemeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(demeritosAsignado);
		}


		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var demeritosAsignado = await _Irepositorio.Buscar(id);
			if (demeritosAsignado == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(demeritosAsignado.EstudianteId);
			ViewBag.demeritos = await _IrepositorioUtilidades.ListarDemeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();

			return View(demeritosAsignado);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarDemeritoAsignado(DemeritosAsignados demeritosAsignado)
		{
			if (demeritosAsignado == null)
			{
				return View();
			}
			await _Irepositorio.Borrar(demeritosAsignado);
			TempData["mensaje"] = "Demerito Eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction("Index", "Expedientes", new { id = demeritosAsignado.EstudianteId });
		}
	}
}
