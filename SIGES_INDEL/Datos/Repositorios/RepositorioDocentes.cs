using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios
{
	public class RepositorioDocentes : IRepositorioDocentes
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Docente docente;
		public RepositorioDocentes(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}
		public async Task Actualizar(Docente docente)
		{
			ContextoDatos.TDocentes.Update(docente);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Docente> Buscar(int? id)
		{
			return docente = await ContextoDatos.TDocentes.Include(e => e.Grados).Include(t => t.User).FirstOrDefaultAsync(e => e.Id == id);
		}
		public async Task Borrar(Docente docente)
		{
			ContextoDatos.TDocentes.Remove(docente);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Crear(Docente docente)
		{
			ContextoDatos.TDocentes.Add(docente);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index(string busqueda)
		{
			var _estudiantes = ContextoDatos.TDocentes.Include(e => e.Grados).AsQueryable();

			if (busqueda != null)
			{
				_estudiantes = _estudiantes.Where(e => e.NIP == busqueda).Include(t=>t.Grados);
			}

			return await _estudiantes.AsNoTracking().Include(t => t.Grados).ToListAsync();
		}
	}
}
