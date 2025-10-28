using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioEstadoData : IRepositorioEstadoData
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Estado estado;
		public RepositorioEstadoData(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Estado estado)
		{
			ContextoDatos.TEstados.Update(estado);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Estado estado)
		{
			ContextoDatos.TEstados.Remove(estado);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Estado> Buscar(int? id)
		{
			return estado = await ContextoDatos.TEstados.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Estado estado)
		{
			ContextoDatos.TEstados.Add(estado);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TEstados.AsNoTracking().ToListAsync();
		}
	}
}
