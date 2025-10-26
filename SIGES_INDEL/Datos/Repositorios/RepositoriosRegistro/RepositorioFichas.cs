using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces.InterfacesRegistro;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Datos.Repositorios.RepositoriosRegistro
{
	public class RepositorioFichas : IRepositorioFichas
	{
		private readonly ApplicationDbContext ContextoDatos;
		private FichasAsignadas fichas;
		public RepositorioFichas(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(FichasAsignadas fichas)
		{
			ContextoDatos.TFichasAsignadas.Update(fichas);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<FichasAsignadas> Buscar(int? id)
		{
			return fichas = await ContextoDatos.TFichasAsignadas
								.Include(e => e.Estudiante)
								.Include(e => e.Docente)
								.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(FichasAsignadas fichas)
		{
			ContextoDatos.TFichasAsignadas.Add(fichas);
			await ContextoDatos.SaveChangesAsync();
		}
		public async Task Borrar(FichasAsignadas fichas)
		{
			ContextoDatos.TFichasAsignadas.Remove(fichas);
			await ContextoDatos.SaveChangesAsync();
		}
	}
}
