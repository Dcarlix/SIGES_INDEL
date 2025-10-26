using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Models;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosRegistro
{
	public class RepositorioMeritos : IRepositorioMeritos
	{
		private readonly ApplicationDbContext ContextoDatos;
		private MeritosAsignados meritos;
		public RepositorioMeritos(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(MeritosAsignados meritos)
		{
			ContextoDatos.TMeritosAsignados.Update(meritos);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<MeritosAsignados> Buscar(int? id)
		{
			return meritos = await ContextoDatos.TMeritosAsignados
								.Include(e => e.Estudiante)
								.Include(e => e.Docente)
								.Include(e => e.Meritos)
								.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(MeritosAsignados meritos)
		{
			ContextoDatos.TMeritosAsignados.Add(meritos);
			await ContextoDatos.SaveChangesAsync();
		}
		public async Task Borrar(MeritosAsignados meritos)
		{
			ContextoDatos.TMeritosAsignados.Remove(meritos);
			await ContextoDatos.SaveChangesAsync();
		}
	}
}
