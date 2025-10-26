using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioMeritosData
	{
		public Task<IEnumerable> Index();
		public Task Crear(Meritos merito);
		public Task Actualizar(Meritos merito);
		public Task<Meritos> Buscar(int? id);
		public Task Borrar(Meritos merito);
	}
}
