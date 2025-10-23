using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Registros
{
	public class FichasAsignadas
	{
		[Key]
		[Display(Name = "Registro de Ficha")]
		public int Id { get; set; }

		[Display(Name = "Fecha en que se coloca")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public DateOnly FechaRegistro { get; set; }

		//Relacion con tabla Estudainte
		[Display(Name = "NIE Del Alumno")]
		public int EstudianteId { get; set; }
		[Display(Name = "NIE Del Alumno")]
		public Estudiante Estudiante { get; set; }

		//Relacion con tabla Docente
		[Display(Name = "NIP Del Docente")]
		public int DocenteId { get; set; }
		[Display(Name = "NIP Del Docente")]
		public Docente Docente { get; set; }

		[Display(Name = "Ficha")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Ficha { get; set; }

		[Display(Name = "Comentarios")]
		public string Comentarios { get; set; }
	}
}
