using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioNacionalidadesData : IRepositorioNacionalidadesData
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Nacionalidades nacionalidad;
		public RepositorioNacionalidadesData(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Nacionalidades nacionalidades)
		{
			ContextoDatos.TNacionalidades.Update(nacionalidades);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Nacionalidades nacionalidades)
		{
			ContextoDatos.TNacionalidades.Remove(nacionalidades);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Nacionalidades> Buscar(int? id)
		{
			return nacionalidad = await ContextoDatos.TNacionalidades.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Nacionalidades nacionalidades)
		{
			ContextoDatos.TNacionalidades.Add(nacionalidades);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TNacionalidades.AsNoTracking().ToListAsync();
		}
	}
}
