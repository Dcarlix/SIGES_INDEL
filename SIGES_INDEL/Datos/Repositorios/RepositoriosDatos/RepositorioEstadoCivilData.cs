using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioEstadoCivilData : IRepositorioEstadoCivilData
	{
		private readonly ApplicationDbContext ContextoDatos;
		private EstadoCivil estadoCivil;
		public RepositorioEstadoCivilData(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(EstadoCivil estadoCivil)
		{
			ContextoDatos.TEstadoCivil.Update(estadoCivil);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(EstadoCivil estadoCivil)
		{
			ContextoDatos.TEstadoCivil.Remove(estadoCivil);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<EstadoCivil> Buscar(int? id)
		{
			return estadoCivil = await ContextoDatos.TEstadoCivil.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(EstadoCivil estadoCivil)
		{
			ContextoDatos.TEstadoCivil.Add(estadoCivil);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TEstadoCivil.AsNoTracking().ToListAsync();
		}
	}
}
