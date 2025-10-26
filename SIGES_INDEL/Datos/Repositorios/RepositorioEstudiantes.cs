using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios
{
	public class RepositorioEstudiantes : IRepositorioEstudiantes
	{
		private readonly ApplicationDbContext ContextoDatos;
		private Estudiante estudiante;
		public RepositorioEstudiantes(ApplicationDbContext applicationDbContext)
		{
			ContextoDatos = applicationDbContext;
		}

		public async Task Actualizar(Estudiante estudiante)
		{
			ContextoDatos.TEstudiantes.Update(estudiante);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task Borrar(Estudiante estudiante)
		{
			ContextoDatos.TEstudiantes.Remove(estudiante);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<Estudiante> Buscar(int? id)
		{
			return estudiante = await ContextoDatos.TEstudiantes
								.Include(e => e.Matriculas)
									.ThenInclude(m => m.Grados)
										.ThenInclude(g => g.Docente)
								.Include(e => e.Matriculas)
									.ThenInclude(m => m.Estado)
								.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Crear(Estudiante estudiante)
		{
			ContextoDatos.TEstudiantes.Add(estudiante);
			await ContextoDatos.SaveChangesAsync();
		}

		public async Task<IEnumerable> Index(int busqueda)
		{
			var _estudiantes = ContextoDatos.TEstudiantes
										.Include(e => e.Matriculas)
											.ThenInclude(m => m.Grados)
												.ThenInclude(g => g.Docente)  
										.OrderBy(e => e.NombreCompleto)
										.AsQueryable();

			if (busqueda != 0)
			{
				_estudiantes = _estudiantes.Where(e => e.NIE == busqueda);
			}

			return await _estudiantes.AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable> ListarActas(int NIE)
		{
			return await ContextoDatos.TActasAsignadas.Where(t => t.EstudianteId == NIE).Include(t => t.Estudiante).Include(t => t.Docente).ToListAsync();
		}

		public async Task<IEnumerable> ListarDemeritos(int NIE)
		{
			return await ContextoDatos.TDemeritosAsignados.Where(t => t.EstudianteId == NIE).Include(t => t.Estudiante).Include(t => t.Docente).ToListAsync();
		}

		public async Task<IEnumerable> ListarFichas(int NIE)
		{
			return await ContextoDatos.TFichasAsignadas.Where(t => t.EstudianteId == NIE).Include(t => t.Estudiante).Include(t => t.Docente).ToListAsync();
		}

		public async Task<IEnumerable> ListarMertios(int NIE)
		{
			return await ContextoDatos.TMeritosAsignados.Where(t => t.EstudianteId == NIE).Include(t => t.Estudiante).Include(t => t.Docente).ToListAsync();

		}
	}
}
