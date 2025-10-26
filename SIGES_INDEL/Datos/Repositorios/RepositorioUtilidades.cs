using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Datos.Interfaces;
using SIGES_INDEL.Models;
using System.Collections;

namespace SIGES_INDEL.Datos.Repositorios
{
	public class RepositorioUtilidades : IRepositorioUtilidades
	{
		private readonly ApplicationDbContext ContextoDatos;

		public RepositorioUtilidades(ApplicationDbContext xContextoDatos)
		{
			ContextoDatos = xContextoDatos;
		}
		public async Task<IEnumerable> ListarDemeritos()
		{
			return await ContextoDatos.TDemertios.ToListAsync();
		}

		public async Task<IEnumerable> ListarEstado()
		{
			return await ContextoDatos.TEstados.ToListAsync();
		}

		public async Task<IEnumerable> ListarEstadoCivil()
		{
			return await ContextoDatos.TEstadoCivil.ToListAsync();
		}

		public async Task<IEnumerable> ListarEtnia()
		{
			return await ContextoDatos.TEtnias.ToListAsync();
		}

		public async Task<IEnumerable> ListarGrados()
		{
			return await ContextoDatos.TGrados.ToListAsync();
		}

		public async Task<IEnumerable> ListarMeritos()
		{
			return await ContextoDatos.TMeritos.ToListAsync();
		}

		public async Task<IEnumerable> ListarNacionalidades()
		{
			return await ContextoDatos.TNacionalidades.ToListAsync();		
		}

		public async Task<IEnumerable> ListarParentesco()
		{
			return await ContextoDatos.TParentescos.ToListAsync();
		}

		public async Task<IEnumerable> ListarDocentes()
		{
			return await ContextoDatos.TDocentes.ToListAsync();
		}

		public async Task<Estudiante> ListarEstudiantes(int id)
		{
			return await ContextoDatos.TEstudiantes.FindAsync(id);
		}
		
	}
}
