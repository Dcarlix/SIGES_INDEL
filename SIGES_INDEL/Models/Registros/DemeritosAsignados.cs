using SIGES_INDEL.Models.Complementos;
using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Registros
{
	public class DemeritosAsignados
	{
		[Key]
		[Display(Name = "Registro de Demerito")]
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

		//Relacion con tabla Demeritos
		[Display(Name = "Tipo de demerito")]
		public int DemeritosId { get; set; }
		[Display(Name = "Tipo de Demerito")]
		public Demeritos Demeritos { get; set; }

		[Display(Name = "Comentarios")]
		public string Comentarios { get; set; }
	}
}
