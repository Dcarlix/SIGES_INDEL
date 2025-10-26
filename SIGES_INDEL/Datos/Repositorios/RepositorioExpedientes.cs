using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models;

namespace SIGES_INDEL.Datos.Repositorios
{
	public class RepositorioExpedientes : IRepositorioExpedientes
	{
		private readonly ApplicationDbContext ContextoDatos;
		public RepositorioExpedientes(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task<Estudiante> Index(int id)
		{
			return await ContextoDatos.TEstudiantes
		.Include(e => e.MeritosAsignados)
			.ThenInclude(m => m.Docente)
		.Include(e => e.MeritosAsignados)
			.ThenInclude(m => m.Meritos)
		.Include(e => e.DemeritosAsignados)
			.ThenInclude(d => d.Docente)
		.Include(e => e.DemeritosAsignados)
			.ThenInclude(d => d.Demeritos)
		.Include(e => e.FichasAsignadas)
			.ThenInclude(f => f.Docente)
		.Include(e => e.ActasAsignadas)
			.ThenInclude(a => a.Docente)
		.AsNoTracking()
		.FirstOrDefaultAsync(e => e.Id == id);
		}
	}
}
