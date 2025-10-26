using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesRegistro
{
	public interface IRepositorioActas
	{
		public Task Crear(ActasAsignadas actas);
		public Task Actualizar(ActasAsignadas actas);
		public Task Borrar(ActasAsignadas actas);
		public Task<ActasAsignadas> Buscar(int? id);
	}
}
