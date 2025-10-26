using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Controllers.ControladoresRegistros
{
    public class FichasController : Controller
    {
		private readonly IRepositorioFichas _Irepositorio;
		private readonly IRepositorioUtilidades _IrepositorioUtilidades;

		public FichasController(IRepositorioFichas Irepositorio, IRepositorioUtilidades repositorioUtilidades)
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
		public async Task<IActionResult> Crear(FichasAsignadas fichasAsignada)
		{
			if (ModelState.IsValid)
			{
				fichasAsignada.Id = 0;
				await _Irepositorio.Crear(fichasAsignada);
				TempData["mensaje"] = "Ficha Agregada correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index", "Expedientes", new { id = fichasAsignada.EstudianteId });
			}

			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(fichasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(fichasAsignada);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var fichasAsignada = await _Irepositorio.Buscar(id);
			if (fichasAsignada == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(fichasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(fichasAsignada);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(FichasAsignadas fichasAsignada)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(fichasAsignada);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index", "Expedientes", new { id = fichasAsignada.EstudianteId });
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(fichasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(fichasAsignada);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int id)
		{
			var fichasAsignada = await _Irepositorio.Buscar(id);
			if (fichasAsignada == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(fichasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(fichasAsignada);
		}


		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var fichasAsignada = await _Irepositorio.Buscar(id);
			if (fichasAsignada == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(fichasAsignada.EstudianteId);
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(fichasAsignada);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarFichasAsignada(FichasAsignadas fichasAsignada)
		{
			if (fichasAsignada == null)
			{
				return View();
			}

			await _Irepositorio.Borrar(fichasAsignada);
			TempData["mensaje"] = "Ficha Eliminada correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction("Index", "Expedientes", new { id = fichasAsignada.EstudianteId });
		}
	}
}
