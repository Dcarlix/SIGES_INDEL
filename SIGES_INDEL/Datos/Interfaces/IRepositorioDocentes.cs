using SIGES_INDEL.Models;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces
{
	public interface IRepositorioDocentes
	{
		//Contexto Bascio
		public Task<IEnumerable> Index(int busqueda);
		public Task Crear(Docente docente);
		public Task Actualizar(Docente docente);
		public Task<Docente> Buscar(int? id);
		public Task Borrar(Docente docente);

	}
}
