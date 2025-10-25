using SIGES_INDEL.Models;

namespace SIGES_INDEL.Datos.Interfaces
{
	public interface IRepositorioExpedientes
	{
		public Task<Estudiante> Index(int id);
	}
}
