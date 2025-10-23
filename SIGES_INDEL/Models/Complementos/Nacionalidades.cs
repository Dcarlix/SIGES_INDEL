using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Nacionalidades
	{
		[Key]
		[Display(Name = "Codigo de Nacionalidad")]
		public int Id { get; set; }

		[Display(Name = "Nacionalidad")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Nacionalidad { get; set; }
	}
}
