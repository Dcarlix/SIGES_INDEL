using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGES_INDEL.Models
{
	public class ApplicationUser : IdentityUser
	{
		// Relación uno a uno con Docente
		[ForeignKey("Docente")]
		public int? DocenteId { get; set; }

		public Docente? Docente { get; set; }
	}
}
