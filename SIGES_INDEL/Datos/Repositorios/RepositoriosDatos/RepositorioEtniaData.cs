using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioEtniaData : IRepositorioEtniaData
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Etnia etnia;
		public RepositorioEtniaData(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Etnia etnia)
		{
			ContextoDatos.TEtnias.Update(etnia);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Etnia etnia)
		{
			ContextoDatos.TEtnias.Remove(etnia);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Etnia> Buscar(int? id)
		{
			return etnia = await ContextoDatos.TEtnias.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Etnia etnia)
		{
			ContextoDatos.TEtnias.Add(etnia);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TEtnias.AsNoTracking().ToListAsync();
		}
	}
}
