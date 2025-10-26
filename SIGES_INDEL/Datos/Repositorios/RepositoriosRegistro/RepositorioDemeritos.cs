using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosRegistro
{
	public class RepositorioDemeritos : IRepositorioDemeritos
	{
		private readonly ApplicationDbContext ContextoDatos;
		private DemeritosAsignados demeritos;
		public RepositorioDemeritos(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(DemeritosAsignados demeritos)
		{
			ContextoDatos.TDemeritosAsignados.Update(demeritos);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<DemeritosAsignados> Buscar(int? id)
		{
			return demeritos = await ContextoDatos.TDemeritosAsignados
								.Include(e => e.Estudiante)
								.Include(e => e.Docente)
								.Include(e => e.Demeritos)
								.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(DemeritosAsignados demeritos)
		{
			ContextoDatos.TDemeritosAsignados.Add(demeritos);
			await ContextoDatos.SaveChangesAsync();
		}
		public async Task Borrar(DemeritosAsignados demeritos)
		{
			ContextoDatos.TDemeritosAsignados.Remove(demeritos);
			await ContextoDatos.SaveChangesAsync();
		}
	}
}
