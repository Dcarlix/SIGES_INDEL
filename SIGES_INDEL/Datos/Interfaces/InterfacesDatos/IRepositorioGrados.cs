using SIGES_INDEL.Models;
using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioGrados
	{
		public Task<IEnumerable> Index();
		public Task Crear(Grados grado);
		public Task Actualizar(Grados grado);
		public Task<Grados> Buscar(int? id);
		public Task Borrar(Grados grado);
	}
}
