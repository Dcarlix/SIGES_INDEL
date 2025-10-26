using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioDemeritosData : IRepositorioDemeritosData
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Demeritos demerito;
		public RepositorioDemeritosData(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Demeritos demerito)
		{
			ContextoDatos.TDemertios.Update(demerito);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Demeritos demerito)
		{
			ContextoDatos.TDemertios.Remove(demerito);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Demeritos> Buscar(int? id)
		{
			return demerito = await ContextoDatos.TDemertios.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Demeritos demerito)
		{
			ContextoDatos.TDemertios.Add(demerito);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TDemertios.AsNoTracking().ToListAsync();
		}
	}
}
