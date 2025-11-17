using SIGES_INDEL.Models.Complementos;
using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Registros
{
	public class ActasAsignadas
	{
		[Key]
		[Display(Name = "Registro de Acta")]
		public int Id { get; set; }

		[Display(Name = "Fecha en que se coloca")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public DateOnly FechaRegistro { get; set; }

		//Relacion con tabla Estudainte
		[Display(Name = "Nombre del Alumno")]
		public int EstudianteId { get; set; }
		[Display(Name = "Nombre del Alumno")]
		public Estudiante Estudiante { get; set; }

		//Relacion con tabla Docente
		[Display(Name = "Docente que lo Asigna")]
		public int DocenteId { get; set; }
		[Display(Name = "Docente que lo Asigna")]
		public Docente Docente { get; set; }

		[Display(Name = "Acta")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Acta { get; set; }

		[Display(Name = "Comentarios")]
		public string Comentarios { get; set; }
	}
}
