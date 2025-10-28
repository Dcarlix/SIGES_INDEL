using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioDiscapacidadesData
	{
		public Task<IEnumerable> Index();
		public Task Crear(Discapacidades discapacidades);
		public Task Actualizar(Discapacidades discapacidades);
		public Task<Discapacidades> Buscar(int? id);
		public Task Borrar(Discapacidades discapacidades);
	}
}
