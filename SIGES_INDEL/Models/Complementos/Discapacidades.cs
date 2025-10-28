using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Discapacidades
	{
		[Key]
		[Display(Name = "Codigo de Demerito")]
		public int Id { get; set; }

		[Display(Name = "Discapacidad")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Discapacidad { get; set; }
	}
}
