using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioEstadoData
	{
		public Task<IEnumerable> Index();
		public Task Crear(Estado estado);
		public Task Actualizar(Estado estado);
		public Task<Estado> Buscar(int? id);
		public Task Borrar(Estado estado);
	}
}
