using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Etnia
	{
		[Key]
		[Display(Name = "Codigo de Etnia")]
		public int Id { get; set; }

		[Display(Name = "Etnia")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Etnias { get; set; }
	}
}
