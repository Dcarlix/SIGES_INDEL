using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosRegistro
{
	public class RepositorioActas: IRepositorioActas
	{
		private readonly ApplicationDbContext ContextoDatos;
		private ActasAsignadas actas;
		public RepositorioActas(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(ActasAsignadas actas)
		{
			ContextoDatos.TActasAsignadas.Update(actas);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<ActasAsignadas> Buscar(int? id)
		{
			return actas = await ContextoDatos.TActasAsignadas
								.Include(e => e.Estudiante)
								.Include(e => e.Docente)
								.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(ActasAsignadas actas)
		{
			ContextoDatos.TActasAsignadas.Add(actas);
			await ContextoDatos.SaveChangesAsync();
		}
		public async Task Borrar(ActasAsignadas actas)
		{
			ContextoDatos.TActasAsignadas.Remove(actas);
			await ContextoDatos.SaveChangesAsync();
		}
	}
}
