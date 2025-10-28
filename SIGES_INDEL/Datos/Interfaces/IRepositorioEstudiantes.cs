using SIGES_INDEL.Models;
using System.Collections;

namespace SIGES_INDEL.Datos.Interfaces
{
	public interface IRepositorioEstudiantes
	{
		//Contexto Bascio
		public Task<IEnumerable> Index(string busqueda);
		public Task Crear(Estudiante estudiante);
		public Task Actualizar(Estudiante estudiante);
		public Task<Estudiante> Buscar(int? id);
		public Task Borrar(Estudiante estudiante);
		//Listar datos academicos
		public Task<IEnumerable> ListarActas(int NIE);
		public Task<IEnumerable> ListarDemeritos(int NIE);
		public Task<IEnumerable> ListarFichas(int NIE);
		public Task<IEnumerable> ListarMertios(int NIE);
	}
}
