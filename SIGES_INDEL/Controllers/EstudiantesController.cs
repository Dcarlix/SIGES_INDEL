using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models;

namespace SIGES_INDEL.Controllers
{
    public class EstudiantesController : Controller
    {
		private readonly IRepositorioEstudiantes _Irepositorio;
		private readonly IRepositorioUtilidades _IrepositorioUtilidades;

		public EstudiantesController(IRepositorioEstudiantes Irepositorio, IRepositorioUtilidades repositorioUtilidades)
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
			ViewBag.nacionalidades = await _IrepositorioUtilidades.ListarNacionalidades();
			ViewBag.estadoCivil = await _IrepositorioUtilidades.ListarEstadoCivil();
			ViewBag.etnias = await _IrepositorioUtilidades.ListarEtnia();
			ViewBag.parentescos = await _IrepositorioUtilidades.ListarParentesco();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear(Estudiante estudiante)
		{
			if (ModelState.IsValid)
			{
				if (estudiante.ImagenEstudianteArchivo != null && estudiante.ImagenEstudianteArchivo.Length > 0)
				{
					using (var memoryStream = new MemoryStream())
					{
						await estudiante.ImagenEstudianteArchivo.CopyToAsync(memoryStream);
						estudiante.ImagenEstudiante = memoryStream.ToArray();
					}
				}
				await _Irepositorio.Crear(estudiante);
				TempData["mensaje"] = "Estudiante creado correctamente.";
				TempData["tipo"] = "success";
				return RedirectToAction("Crear", "Matriculas", new { id = estudiante.Id });
			}

			ViewBag.nacionalidades = await _IrepositorioUtilidades.ListarNacionalidades();
			ViewBag.estadoCivil = await _IrepositorioUtilidades.ListarEstadoCivil();
			ViewBag.etnias = await _IrepositorioUtilidades.ListarEtnia();
			ViewBag.parentescos = await _IrepositorioUtilidades.ListarParentesco();

			return View(estudiante);
		}

		[HttpGet]
		public async Task<IActionResult> Editar(int? id)
		{
			ViewBag.nacionalidades = await _IrepositorioUtilidades.ListarNacionalidades();
			ViewBag.estadoCivil = await _IrepositorioUtilidades.ListarEstadoCivil();
			ViewBag.etnias = await _IrepositorioUtilidades.ListarEtnia();
			ViewBag.parentescos = await _IrepositorioUtilidades.ListarParentesco();

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
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Estudiante estudiante)
		{
			if (ModelState.IsValid)
			{
				if (estudiante.ImagenEstudianteArchivo != null && estudiante.ImagenEstudianteArchivo.Length > 0)
				{
					using (var memoryStream = new MemoryStream())
					{
						await estudiante.ImagenEstudianteArchivo.CopyToAsync(memoryStream);
						estudiante.ImagenEstudiante = memoryStream.ToArray();
					}
				}
				await _Irepositorio.Actualizar(estudiante);
				TempData["mensaje"] = "Cambios guardados con éxito.";
				TempData["tipo"] = "success";
				return RedirectToAction(nameof(Index));
			}

			ViewBag.nacionalidades = await _IrepositorioUtilidades.ListarNacionalidades();
			ViewBag.estadoCivil = await _IrepositorioUtilidades.ListarEstadoCivil();
			ViewBag.etnias = await _IrepositorioUtilidades.ListarEtnia();
			ViewBag.parentescos = await _IrepositorioUtilidades.ListarParentesco();

			return View(estudiante);
		}

		[HttpGet]
		public async Task<IActionResult> Detalle(int? id)
		{
			ViewBag.nacionalidades = await _IrepositorioUtilidades.ListarNacionalidades();
			ViewBag.estadoCivil = await _IrepositorioUtilidades.ListarEstadoCivil();
			ViewBag.etnias = await _IrepositorioUtilidades.ListarEtnia();
			ViewBag.parentescos = await _IrepositorioUtilidades.ListarParentesco();
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

		[HttpGet]
		public async Task<IActionResult> Borrar(int? id)
		{
			ViewBag.nacionalidades = await _IrepositorioUtilidades.ListarNacionalidades();
			ViewBag.estadoCivil = await _IrepositorioUtilidades.ListarEstadoCivil();
			ViewBag.etnias = await _IrepositorioUtilidades.ListarEtnia();
			ViewBag.parentescos = await _IrepositorioUtilidades.ListarParentesco();

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
		[HttpPost, ActionName("Borrar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> BorrarCliente(Estudiante estudiante)
		{

			var confirmacion = await _Irepositorio.Confirmacion(estudiante.Id);

			if (confirmacion.Matriculas.Any())
			{
				TempData["tipo"] = "warning";
				TempData["mensaje"] = "No se puede eliminar este estudiante porque tiene matrículas registradas.";
				return RedirectToAction(nameof(Index));
			}
			if (estudiante == null)
			{
				return View();
			}

			await _Irepositorio.Borrar(estudiante);
			TempData["mensaje"] = "Estudiante eliminado correctamente.";
			TempData["tipo"] = "warning";
			return RedirectToAction(nameof(Index));
		}


	}
}
