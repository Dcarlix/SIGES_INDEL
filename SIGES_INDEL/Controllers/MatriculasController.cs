using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models;

namespace SIGES_INDEL.Controllers
{
    public class MatriculasController : Controller
    {
		private readonly IRepositorioMatriculas _Irepositorio;
		private readonly IRepositorioUtilidades _IrepositorioUtilidades;

		public MatriculasController(IRepositorioMatriculas Irepositorio, IRepositorioUtilidades repositorioUtilidades)
		{
			_Irepositorio = Irepositorio;
			_IrepositorioUtilidades = repositorioUtilidades;
		}
		[HttpGet]
		public async Task<IActionResult> Index(string Buscar)
        {
			ViewData["Buscar"] = Buscar;

			return View(await _Irepositorio.Index(Buscar));
		}

		[HttpGet]
		public async Task<IActionResult> Crear(int id)
		{
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(id);
			ViewBag.estado = await _IrepositorioUtilidades.ListarEstado();
			ViewBag.grado = await _IrepositorioUtilidades.ListarGrados();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(Matriculas matriculas)
		{
			if (ModelState.IsValid)
			{
				matriculas.Id = 0;

				await _Irepositorio.Crear(matriculas);
				TempData["mensaje"] = "Estudiante matriculado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(matriculas.EstudianteId);
			ViewBag.estado = await _IrepositorioUtilidades.ListarEstado();
			ViewBag.grado = await _IrepositorioUtilidades.ListarGrados();

			return View(matriculas);
		}


		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			var matricula = await _Irepositorio.Buscar(id);
			if (matricula == null)
			{
				return NotFound();
			}

			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(matricula.EstudianteId);
			ViewBag.estado = await _IrepositorioUtilidades.ListarEstado();
			ViewBag.grado = await _IrepositorioUtilidades.ListarGrados();

			return View(matricula);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Matriculas matriculas)
		{
			if (ModelState.IsValid)
			{
				await _Irepositorio.Actualizar(matriculas);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}

			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(matriculas.EstudianteId);
			ViewBag.estado = await _IrepositorioUtilidades.ListarEstado();
			ViewBag.grado = await _IrepositorioUtilidades.ListarGrados();

			return View(matriculas);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int id)
		{
			var matriculas = await _Irepositorio.Buscar(id);
			if (matriculas == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(matriculas.EstudianteId);
			ViewBag.estado = await _IrepositorioUtilidades.ListarEstado();
			ViewBag.grado = await _IrepositorioUtilidades.ListarGrados();
			
			return View(matriculas);
		}


		[HttpGet]
		public async Task<IActionResult> Borrar(int id)
		{
			var matricula = await _Irepositorio.Buscar(id);
			if (matricula == null)
			{
				return NotFound();
			}
			ViewBag.estudiante = await _IrepositorioUtilidades.ListarEstudiantes(matricula.EstudianteId);
			ViewBag.estado = await _IrepositorioUtilidades.ListarEstado();
			ViewBag.grado = await _IrepositorioUtilidades.ListarGrados();

			return View(matricula);
		}
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarMatricula(Matriculas matriculas)
		{
			if (matriculas == null)
			{
				return View();
			}

			await _Irepositorio.Borrar(matriculas);
			TempData["mensaje"] = "Matricula Eliminada correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}

	}
}
