using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioParentescoData : IRepositorioParentescoData
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Parentesco parentesco;
		public RepositorioParentescoData(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Parentesco parentesco)
		{
			ContextoDatos.TParentescos.Update(parentesco);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Parentesco parentesco)
		{
			ContextoDatos.TParentescos.Remove(parentesco);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Parentesco> Buscar(int? id)
		{
			return parentesco = await ContextoDatos.TParentescos.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Parentesco parentesco)
		{
			ContextoDatos.TParentescos.Add(parentesco);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TParentescos.AsNoTracking().ToListAsync();
		}
	}
}
