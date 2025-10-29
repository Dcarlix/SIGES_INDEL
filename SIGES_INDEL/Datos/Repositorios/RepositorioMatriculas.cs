using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios
{
	public class RepositorioMatriculas : IRepositorioMatriculas
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Matriculas matricula;
		public RepositorioMatriculas(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}
		public async Task<IEnumerable<Matriculas>> Index(string busqueda)
		{
			var query = ContextoDatos.TMatriculas
				   .Include(t => t.Grados)
				   .Include(t => t.Estado)
				   .Include(t => t.Estudiante)
				   .AsNoTracking()
				   .AsQueryable();

			if (!string.IsNullOrEmpty(busqueda))
				query = query.Where(a => a.Estudiante.NIE == busqueda);

			return await query
				.OrderBy(a => a.EstudianteId)
				.ToListAsync();
		}
		public async Task Crear(Matriculas matriculas)
		{
			ContextoDatos.TMatriculas.Add(matriculas);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Actualizar(Matriculas matriculas)
		{
			ContextoDatos.TMatriculas.Update(matriculas);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Matriculas matriculas)
		{
			ContextoDatos.TMatriculas.Remove(matriculas);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Matriculas> Buscar(int? id)
		{
			return matricula = await ContextoDatos.TMatriculas.FindAsync(id);
		}

		
	}
}
