using SIGES_INDEL.Models.Complementos;
using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models
{
	public class Matriculas
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Fecha de Matricula")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public DateOnly FechaMatricula { get; set; }

		//Relacion con tabla Estudiantes
		[Display(Name = "NIE")]
		public int EstudianteId { get; set; }
		[Display(Name = "NIE")]
		public Estudiante Estudiante { get; set; }

		//Relacion con tabla Grados
		[Display(Name = "Grado Actual")]
		public int GradoId { get; set; }
		[Display(Name = "Grado Actual")]
		public Grados Grados { get; set; }

		//Relacion con tabla Estado
		[Display(Name = "Estado")]
		public int EstadoId { get; set; }
		[Display(Name = "Estado")]
		public Estado Estado { get; set; }

		[Display(Name = "Fecha en la que se Graduo el alumno")]
		public DateOnly FechaEgresion { get; set; }
	}
}
