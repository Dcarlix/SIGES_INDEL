using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioNacionalidadesData
	{
		public Task<IEnumerable> Index();
		public Task Crear(Nacionalidades nacionalidad);
		public Task Actualizar(Nacionalidades nacionalidad);
		public Task<Nacionalidades> Buscar(int? id);
		public Task Borrar(Nacionalidades nacionalidad);
	}
}
