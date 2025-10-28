using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesDatos;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosDatos
{
	public class RepositorioDiscapacidadesData : IRepositorioDiscapacidadesData
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Discapacidades discapacidades;
		public RepositorioDiscapacidadesData(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Discapacidades discapacidades)
		{
			ContextoDatos.TDiscapacidades.Update(discapacidades);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Discapacidades discapacidades)
		{
			ContextoDatos.TDiscapacidades.Remove(discapacidades);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Discapacidades> Buscar(int? id)
		{
			return discapacidades = await ContextoDatos.TDiscapacidades.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Discapacidades discapacidades)
		{
			ContextoDatos.TDiscapacidades.Add(discapacidades);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index()
		{
			return await ContextoDatos.TDiscapacidades.AsNoTracking().ToListAsync();
		}
	}
}
