using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models.Complementos
{
	public class Genero
	{
		[Key]
		[Display(Name = "Codigo de Genero")]
		public int Id { get; set; }

		[Display(Name = "Genero")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Generos { get; set; }
	}
}
