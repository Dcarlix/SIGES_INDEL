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
		[Display(Name = "Nombre del Alumno")]
		public int EstudianteId { get; set; }
		[Display(Name = "Nombre del Alumno")]
		public Estudiante Estudiante { get; set; }

		//Relacion con tabla Docente
		[Display(Name = "Docente que lo Asigna")]
		public int DocenteId { get; set; }
		[Display(Name = "Docente que lo Asigna")]
		public Docente Docente { get; set; }

		//Relacion con tabla Meritos
		[Display(Name = "Tipo de merito")]
		public int MeritosId { get; set; }
		[Display(Name = "Tipo de merito")]
		public Meritos Meritos { get; set; }

		[Display(Name = "Comentarios")]
		public string Comentarios { get; set; }
	}
}
