using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioMeritosData : IRepositorioMeritosData
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Meritos merito;
		public RepositorioMeritosData(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Meritos merito)
		{
			ContextoDatos.TMeritos.Update(merito);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Meritos merito)
		{
			ContextoDatos.TMeritos.Remove(merito);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Meritos> Buscar(int? id)
		{
			return merito = await ContextoDatos.TMeritos.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Meritos merito)
		{
			ContextoDatos.TMeritos.Add(merito);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TMeritos.AsNoTracking().ToListAsync();
		}
	}
}
