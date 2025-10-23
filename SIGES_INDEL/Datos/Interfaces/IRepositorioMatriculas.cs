using SIGES_INDEL.Models;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces
{
	public interface IRepositorioMatriculas
	{
		public Task<IEnumerable> Index(int busqueda);
		public Task Crear(Matriculas matriculas);
		public Task Actualizar(Matriculas matriculas);
		public Task<Matriculas> Buscar(int? id);
		public Task Borrar(Matriculas matriculas);
	}
}
