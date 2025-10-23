using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIGES_INDEL.Models;
using SIGES_INDEL.Models.Complementos;
using SIGES_INDEL.Models.Registros;
using System.Reflection.Emit;

namespace SIGES_INDEL.Datos
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		//Todos los dbset 
		//Tablas Principales
		public DbSet<Docente> TDocentes { get; set; }
		public DbSet<Estudiante> TEstudiantes { get; set; }
		public DbSet<Matriculas> TMatriculas { get; set; }
		//Tablas de complementos
		public DbSet<Demeritos> TDemertios { get; set; }
		public DbSet<Estado> TEstados { get; set; }
		public DbSet<EstadoCivil> TEstadoCivil { get; set; }
		public DbSet<Etnia> TEtnias { get; set; }
		public DbSet<Grados> TGrados { get; set; }
		public DbSet<Meritos> TMeritos { get; set; }
		public DbSet<Nacionalidades> TNacionalidades { get; set; }
		public DbSet<Parentesco> TParentescos { get; set; }
		//Tablas de Registros
		public DbSet<ActasAsignadas> TActasAsignadas { get; set; }
		public DbSet<DemeritosAsignados> TDemeritosAsignados { get; set; }
		public DbSet<FichasAsignadas> TFichasAsignadas { get; set; }
		public DbSet<MeritosAsignados> TMeritosAsignados { get; set; }



		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Matriculas>()
				.HasOne(m => m.Estudiante)
				.WithMany(e => e.Matriculas)
				.HasForeignKey(m => m.EstudianteId)
				.OnDelete(DeleteBehavior.Restrict);

			// Configuración de relación 1 a 1 entre ApplicationUser y Docente
			builder.Entity<ApplicationUser>()
				.HasOne(u => u.Docente)
				.WithOne()
				.HasForeignKey<ApplicationUser>(u => u.DocenteId)
				.OnDelete(DeleteBehavior.Restrict);
		}

	}
}
