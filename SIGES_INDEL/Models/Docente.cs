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
		public int NIP { get; set; }

		[Display(Name = "Nombre Completo")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string NombreCompleto { get; set; }

		[Display(Name = "Foto de Perfil")]
		public byte[] ImagenDocente { get; set; }

		[Display(Name = "Foto de Perfil")]
		[NotMapped]
		public IFormFile ImagenDocenteArchivo { get; set; }

		//Relacion con tabla Grado Coordinacion
		[Display(Name = "Grado que Coordina")]
		public int GradosId { get; set; }
		[Display(Name = "Grado que Coordina")]
		public Grados Grados { get; set; }

	}
}
