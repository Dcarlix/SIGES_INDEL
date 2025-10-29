using SIGES_INDEL.Models.Complementos;
using SIGES_INDEL.Models.Registros;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace SIGES_INDEL.Models
{
	public class Estudiante
	{
		#region Datos Personales
		[Key]
		public int Id { get; set; }
		
		[Display(Name = "NIE")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[StringLength(8, ErrorMessage = "El NIE debe tener 8 Digitos.")]
		public string NIE { get; set; }

		[Display(Name = "Nombre Completo")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string NombreCompleto { get; set; }

		[Display(Name = "Foto de Perfil *")]
		public byte[] ImagenEstudiante { get; set; }

		[Display(Name = "Foto de Perfil *")]
		[NotMapped]
		public IFormFile ImagenEstudianteArchivo { get; set; }

		[Display(Name = "Fecha de Nacimiento")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public DateOnly FechaNacimiento { get; set; }

		[Display(Name ="Numero Telefonico")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[StringLength(9, MinimumLength = 8, ErrorMessage = "El numero debe ser de 8 Digitos")]
		public string Telefono { get; set; }

		[Display(Name = "Direccion de Vivienda")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string Direccion { get; set; }

		//Relacion con tabla Genero
		[Display(Name = "Genero")]
		public int GeneroId { get; set; }
		[Display(Name = "Genero")]
		public Genero Genero { get; set; }

		//Relacion con tabla Discapacidades
		[Display(Name = "Discapacidades")]
		public int DiscapacidadesId { get; set; }
		[Display(Name = "Discapacidades")]
		public Discapacidades Discapacidades { get; set; }

		[Display(Name = "Trabajo *")]
		public string Trabajo { get; set; }

		//Relacion con tabla Nacionalidades
		[Display(Name = "Nacionalidad")]
		public int NacionalidadId { get; set; }
		[Display(Name = "Nacionalidad")]
		public Nacionalidades Nacionalidad { get; set; }

		//Relacion con tabla Estado Civil
		[Display(Name = "Estado Civil")]
		public int EstadoCivilId { get; set; }
		[Display(Name = "Estado Civil")]
		public EstadoCivil EstadoCivil { get; set; }

		//Relacion con tabla Etnia
		[Display(Name = "Etnia")]
		public int EtniaId { get; set; }
		[Display(Name = "Etnia")]
		public Etnia Etnia { get; set; }
		#endregion

		#region Representante

		[Display(Name = "Nombre Completo Del Representante")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		public string NombreCompletoRepresentante { get; set; }

		[Display(Name = "DUI del Representante (Con guion)")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[StringLength(10, ErrorMessage = "El DUI son 9 numeros y Con el Guion")]
		public string DUI { get; set; }

		[Display(Name = "Numero Telefonico del Representante")]
		[Required(ErrorMessage = "El campo {0} es obligatorio")]
		[StringLength(9, MinimumLength = 8, ErrorMessage = "El numero debe ser de 8 Digitos")]
		public string TelefonoRepresentante { get; set; }

		[Display(Name = "Numero Telefonico de Trabajo del Representante *")]
		[StringLength(9, MinimumLength = 8, ErrorMessage = "El numero debe ser de 8 Digitos")]
		public string TelefonoTrabajoRepresentante { get; set; }

		//Relacion con tabla Parentesco
		[Display(Name = "Tipo de Parentesco")]
		public int ParentescoId { get; set; }
		[Display(Name = "Tipo de Parentesco")]
		public Parentesco Parentesco { get; set; }
		#endregion

		#region Rendimiento Academico

		//Relacion con tabla Demeritos Colocados
		[Display(Name = "Demeritos del alumno")]
		public ICollection<DemeritosAsignados> DemeritosAsignados { get; set; }

		//Relacion con tabla Mertios Colocados
		[Display(Name = "Mertios del alumno")]
		public ICollection<MeritosAsignados> MeritosAsignados { get; set; }

		//Relacion con tabla Fichas Colocadas
		[Display(Name = "Fichas del alumno")]
		public ICollection<FichasAsignadas> FichasAsignadas { get; set; }


		//Relacion con tabla Actas Colocadas
		[Display(Name = "Actas del alumno")]
		public ICollection<ActasAsignadas> ActasAsignadas { get; set; }

		// Relación con tabla de Matrículas
		[Display(Name = "Matrículas del Estudiante")]
		public ICollection<Matriculas> Matriculas { get; set; }
		#endregion

	}
}
