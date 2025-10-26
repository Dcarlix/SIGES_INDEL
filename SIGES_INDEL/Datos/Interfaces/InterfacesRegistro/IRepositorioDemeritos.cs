using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesRegistro
{
	public interface IRepositorioDemeritos
	{
		public Task Crear(DemeritosAsignados demeritos);
		public Task Actualizar(DemeritosAsignados demeritos);
		public Task Borrar(DemeritosAsignados demeritos);
		public Task<DemeritosAsignados> Buscar(int? id);
	}
}
