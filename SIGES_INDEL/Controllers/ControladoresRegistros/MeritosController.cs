using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Models;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Controllers.ControladoresRegistros
{
    public class MeritosController : Controller
    {
		private readonly IRepositorioMeritos _Irepositorio;
		private readonly IRepositorioUtilidades _IrepositorioUtilidades;

		public MeritosController(IRepositorioMeritos Irepositorio, IRepositorioUtilidades repositorioUtilidades)
		{
			_Irepositorio = Irepositorio;
			_IrepositorioUtilidades = repositorioUtilidades;
		}

		[HttpGet]
		public async Task<IActionResult> Crear(int id)
		{
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(id);
			ViewBag.meritos = await _IrepositorioUtilidades.ListarMeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(MeritosAsignados meritosAsignado)
		{
			if (ModelState.IsValid)
			{
				meritosAsignado.Id = 0;
				await _Irepositorio.Crear(meritosAsignado);
				TempData["mensaje"] = "Merito Agregado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index","Expedientes", new { id = meritosAsignado.EstudianteId });
			}

			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(meritosAsignado.EstudianteId);
			ViewBag.meritos = await _IrepositorioUtilidades.ListarMeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(meritosAsignado);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var meritosAsignado = await _Irepositorio.Buscar(id);
			if (meritosAsignado == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(meritosAsignado.EstudianteId);
			ViewBag.meritos = await _IrepositorioUtilidades.ListarMeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(meritosAsignado);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(MeritosAsignados meritosAsignado)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(meritosAsignado);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index", "Expedientes", new { id = meritosAsignado.EstudianteId });
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(meritosAsignado.EstudianteId);
			ViewBag.meritos = await _IrepositorioUtilidades.ListarMeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(meritosAsignado);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int id)
		{
			var meritosAsignado = await _Irepositorio.Buscar(id);
			if (meritosAsignado == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(meritosAsignado.EstudianteId);
			ViewBag.meritos = await _IrepositorioUtilidades.ListarMeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();
			return View(meritosAsignado);
		}


		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var meritosAsignado = await _Irepositorio.Buscar(id);
			if (meritosAsignado == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(meritosAsignado.EstudianteId);
			ViewBag.meritos = await _IrepositorioUtilidades.ListarMeritos();
			ViewBag.docentes = await _IrepositorioUtilidades.ListarDocentes();

			return View(meritosAsignado);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarMeritoAsignado(MeritosAsignados meritosAsignado)
		{
			if (meritosAsignado == null)
			{
				return View();
			}

			await _Irepositorio.Borrar(meritosAsignado);
			TempData["mensaje"] = "Merito Eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction("Index", "Expedientes", new { id = meritosAsignado.EstudianteId });
		}

	}
}
