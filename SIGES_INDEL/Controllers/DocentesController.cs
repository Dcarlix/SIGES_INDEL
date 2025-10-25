using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models;

namespace SIGES_INDEL.Controllers
{
    public class DocentesController : Controller
    {
		private readonly IRepositorioDocentes _Irepositorio;
		private readonly IRepositorioUtilidades _IrepositorioUtilidades;

		public DocentesController(IRepositorioDocentes Irepositorio, IRepositorioUtilidades repositorioUtilidades)
		{
			_Irepositorio = Irepositorio;
			_IrepositorioUtilidades = repositorioUtilidades;
		}

		[HttpGet]
		public async Task<IActionResult> Index(int busqueda)
		{
			ViewData["Buscar"] = busqueda;

			return View(await _Irepositorio.Index(busqueda));
		}
		[HttpGet]
		public async Task<IActionResult> Crear()
		{
			ViewBag.grados = await _IrepositorioUtilidades.ListarGrados();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(Docente docente)
		{
			if (ModelState.IsValid)
			{
				if (docente.ImagenDocenteArchivo != null && docente.ImagenDocenteArchivo.Length > 0)
				{
					using (var memoryStream = new MemoryStream())
					{
						await docente.ImagenDocenteArchivo.CopyToAsync(memoryStream);
						docente.ImagenDocente = memoryStream.ToArray();
					}
				}
				await _Irepositorio.Crear(docente);
				TempData["mensaje"] = "Docente creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction("Index");
			}
			ViewBag.grados = await _IrepositorioUtilidades.ListarGrados();
			return View(docente);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			ViewBag.grados = await _IrepositorioUtilidades.ListarGrados();
			if (id == null)
			{
				return NotFound();
			}
			var docente = await _Irepositorio.Buscar(id);
			if (docente == null)
			{
				return NotFound();
			}
			return View(docente);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Docente docente)
		{
			if (ModelState.IsValid)
			{
				if (docente.ImagenDocenteArchivo != null && docente.ImagenDocenteArchivo.Length > 0)
				{
					using (var memoryStream = new MemoryStream())
					{
						await docente.ImagenDocenteArchivo.CopyToAsync(memoryStream);
						docente.ImagenDocente = memoryStream.ToArray();
					}
				}
				await _Irepositorio.Actualizar(docente);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}
			ViewBag.grados = await _IrepositorioUtilidades.ListarGrados();
			return View(docente);
		}
		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			ViewBag.grados = await _IrepositorioUtilidades.ListarGrados();
			if (id == null)
			{
				return NotFound();
			}
			var estudiante = await _Irepositorio.Buscar(id);
			if (estudiante == null)
			{
				return NotFound();
			}
			return View(estudiante);
		}
	}
}
