using SIGES_INDEL.Models;
using SIGES_INDEL.Models.Registros;

namespace SIGES_INDEL.Datos.Interfaces.InterfacesRegistro
{
	public interface IRepositorioMeritos
	{
		public Task Crear(MeritosAsignados meritos);
		public Task Actualizar(MeritosAsignados meritos);
		public Task Borrar(MeritosAsignados meritos);
		public Task<MeritosAsignados> Buscar(int? id);
	}
}
