using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Parentesco
	{
		[Key]
		[Display(Name = "Codigo de Parentesco")]
		public int Id { get; set; }

		[Display(Name = "Parentesco")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Parentescos { get; set; }
	}
}
