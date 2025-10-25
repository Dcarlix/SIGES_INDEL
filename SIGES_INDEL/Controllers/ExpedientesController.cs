using Microsoft.AspNetCore.Mvc;
using SIGES_INDEL.Datos.Interfaces;

namespace SIGES_INDEL.Controllers
{
    public class ExpedientesController : Controller
    {
		private readonly IRepositorioExpedientes _Irepositorio;
		private readonly IRepositorioUtilidades _IrepositorioUtilidades;

		public ExpedientesController(IRepositorioExpedientes Irepositorio, IRepositorioUtilidades repositorioUtilidades)
		{
			_Irepositorio = Irepositorio;
			_IrepositorioUtilidades = repositorioUtilidades;
		}
		public async Task<IActionResult> Index(int id)
		{
			var estudiante = await _Irepositorio.Index(id);
			if (estudiante == null)
			{
				return NotFound();
			}
			return View(estudiante);
		}
	}
}
