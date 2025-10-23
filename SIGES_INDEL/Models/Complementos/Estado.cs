using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Estado
	{
		[Key]
		[Display(Name = "Codigo de Estado")]
		public int Id { get; set; }

		[Display(Name = "Estado")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Estados { get; set; }
	}
}
