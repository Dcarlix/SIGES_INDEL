using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Grados
	{
		[Key]
		[Display(Name = "Codigo de Grado")]
		public int Id { get; set; }

		[Display(Name = "Grado")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Grado { get; set; }

		[Display(Name = "Año")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Anno { get; set; }

		[Display(Name = "Sección")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Seccion { get; set; }

		[Display(Name = "Abreviacion")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Abreviacion { get; set; }

		public Docente Docente { get; set; }

	}
}
