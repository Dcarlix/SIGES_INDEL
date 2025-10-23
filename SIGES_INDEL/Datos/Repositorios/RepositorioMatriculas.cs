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
		public async Task<IEnumerable> Index(int busqueda)
		{
			var _matricula = from a in ContextoDatos.TMatriculas select a;
			_matricula = _matricula.OrderBy(a => a.EstudianteId);
			if (busqueda != 0)
			{
				_matricula = _matricula.Where(a => a.EstudianteId == busqueda);
				return await _matricula.AsNoTracking().ToListAsync();
			}
			return await ContextoDatos.TMatriculas.ToListAsync();
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
