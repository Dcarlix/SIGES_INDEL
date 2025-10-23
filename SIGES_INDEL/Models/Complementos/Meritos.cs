using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Meritos
	{
		[Key]
		[Display(Name = "Codigo de Merito")]
		public int Id { get; set; }

		[Display(Name = "Merito")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Merito { get; set; }
	}
}
