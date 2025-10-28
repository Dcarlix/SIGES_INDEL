using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioParentescoData
	{
		public Task<IEnumerable> Index();
		public Task Crear(Parentesco parentesco);
		public Task Actualizar(Parentesco parentesco);
		public Task<Parentesco> Buscar(int? id);
		public Task Borrar(Parentesco parentesco);
	}
}
