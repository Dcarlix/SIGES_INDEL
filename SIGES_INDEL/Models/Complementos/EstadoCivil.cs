using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class EstadoCivil
	{
		[Key]
		[Display(Name = "Codigo de Estado Civil")]
		public int Id { get; set; }

		[Display(Name = "Estado Civil")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Estado { get; set; }
	}
}
