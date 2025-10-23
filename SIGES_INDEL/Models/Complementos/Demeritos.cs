using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Demeritos
	{
		[Key]
		[Display(Name = "Codigo de Demerito")]
		public int Id { get; set; }

		[Display(Name = "Demerito")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Demerito { get; set; }
	}
}
