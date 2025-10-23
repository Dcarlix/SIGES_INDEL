﻿using System.ComponentModel.DataAnnotations;

namespace SIGES_INDEL.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "El campo {0} es requerido.. ")]
		[EmailAddress(ErrorMessage = "El campo {0} debe de ser un Correo eletrónico valido.. ")]
		public string Email { get; set; }

		[Required(ErrorMessage = "El campo {0} es requerido.. ")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Recuerdame")]
		public bool Recuerdame { get; set; }
	}
}
