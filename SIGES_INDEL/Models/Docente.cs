using SIGES_INDEL.Models.Complementos;
using SIGES_INDEL.Models.Registros;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGES_INDEL.Models
{
	public class Docente
	{
		[Key]
		public int Id { get; set; }
		[Display(Name = "NIP")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[StringLength(8, ErrorMessage = "El NIP debe tener 8 Digitos.")]
		public string NIP { get; set; }

		[Display(Name = "Nombre Completo")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string NombreCompleto { get; set; }

		[Display(Name = "Foto de Perfil")]
		public byte[] ImagenDocente { get; set; }

		[Display(Name = "Foto de Perfil")]
		[NotMapped]
		public IFormFile ImagenDocenteArchivo { get; set; }

		//Relacion con tabla Grado Coordinacion
		[Display(Name = "Grado que Coordina * Opcional")]
		public int? GradosId { get; set; }
		[Display(Name = "Grado que Coordina * Opcional")]
		public Grados Grados { get; set; }

	}
}
