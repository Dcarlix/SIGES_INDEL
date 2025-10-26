using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioGrados : IRepositorioGrados
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Grados grado;
		public RepositorioGrados(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Grados grado)
		{
			ContextoDatos.TGrados.Update(grado);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Grados grado)
		{
			ContextoDatos.TGrados.Remove(grado);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Grados> Buscar(int? id)
		{
			return grado = await ContextoDatos.TGrados.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Grados grado)
		{
			ContextoDatos.TGrados.Add(grado);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TGrados.AsNoTracking().ToListAsync();
		}
	}
}
