using SIGES_INDEL.Models.Complementos;
using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Registros
{
	public class MeritosAsignados
	{
		[Key]
		[Display(Name = "Registro de Meritos")]
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

		//Relacion con tabla Meritos
		[Display(Name = "Tipo de merito")]
		public int MeritoId { get; set; }
		[Display(Name = "Tipo de merito")]
		public Meritos Meritos { get; set; }

		[Display(Name = "Comentarios")]
		public string Comentarios { get; set; }
	}
}
