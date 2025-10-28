using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioEtniaData
	{
		public Task<IEnumerable> Index();
		public Task Crear(Etnia etnia);
		public Task Actualizar(Etnia etnia);
		public Task<Etnia> Buscar(int? id);
		public Task Borrar(Etnia etnia);
	}
}
