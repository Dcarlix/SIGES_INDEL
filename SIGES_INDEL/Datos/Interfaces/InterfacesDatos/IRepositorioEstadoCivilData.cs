using SIGES_INDEL.Models.Complementos;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesDatos
{
	public interface IRepositorioEstadoCivilData
	{
		public Task<IEnumerable> Index();
		public Task Crear(EstadoCivil estadoCivil);
		public Task Actualizar(EstadoCivil estadoCivil);
		public Task<EstadoCivil> Buscar(int? id);
		public Task Borrar(EstadoCivil estadoCivil);
	}
}
