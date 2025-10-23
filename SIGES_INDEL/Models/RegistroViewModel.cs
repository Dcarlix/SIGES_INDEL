using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models
{
	public class RegistroViewModel
	{
		[Required(ErrorMessage = "El campo {0} es requerido.. ")]
		[EmailAddress(ErrorMessage = "El campo {0} debe de ser un Correo eletrónico valido.. ")]
		public string Email { get; set; }


		[Required(ErrorMessage = "El campo {0} es requerido.. ")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "La Confirmacion de contraseña es requerida")]
		[Compare("Password", ErrorMessage = "La Confirmacion de contraseña es requerida")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirmar contraseña")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Docente Asociado")]
		public int? DocenteId { get; set; }
	}
}
