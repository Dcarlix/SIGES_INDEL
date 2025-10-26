using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioDemeritosData
	{
		public Task<IEnumerable> Index();
		public Task Crear(Demeritos demerito);
		public Task Actualizar(Demeritos demerito);
		public Task<Demeritos> Buscar(int? id);
		public Task Borrar(Demeritos demerito);
	}
}
