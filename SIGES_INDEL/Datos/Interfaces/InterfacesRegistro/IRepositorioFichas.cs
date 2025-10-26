using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesRegistro
{
	public interface IRepositorioFichas
	{
		public Task Crear(FichasAsignadas fichas);
		public Task Actualizar(FichasAsignadas fichas);
		public Task Borrar(FichasAsignadas fichas);
		public Task<FichasAsignadas> Buscar(int? id);
	}
}
