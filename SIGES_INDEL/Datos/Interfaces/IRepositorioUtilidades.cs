using SIGES_INDEL.Models;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces
{
	public interface IRepositorioUtilidades
	{
		public Task<IEnumerable> ListarDemeritos();
		public Task<IEnumerable> ListarEstado();
		public Task<IEnumerable> ListarEstadoCivil();
		public Task<IEnumerable> ListarEtnia();
		public Task<IEnumerable> ListarGrados();
		public Task<IEnumerable> ListarMertios();
		public Task<IEnumerable> ListarNacionalidades();
		public Task<IEnumerable> ListarParentesco();
		public Task<IEnumerable> ListarDocentes();
		public Task<Estudiante> ListarEstudiantes(int estudianteId);
	}
}
