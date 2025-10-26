using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGES_INDEL.Migrations
{
    /// <inheritdoc />
    public partial class PorfavorYaNoQuieroRepetirEsto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TDemertios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Demerito = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDemertios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEstadoCivil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEstadoCivil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estados = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEstados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEtnias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etnias = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEtnias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TGrados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abreviacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGrados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TMeritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merito = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMeritos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TNacionalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TNacionalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TParentescos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parentescos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TParentescos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TDocentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIP = table.Column<int>(type: "int", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenDocente = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GradosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDocentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TDocentes_TGrados_GradosId",
                        column: x => x.GradosId,
                        principalTable: "TGrados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TEstudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIE = table.Column<int>(type: "int", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenEstudiante = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discapacidades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NacionalidadId = table.Column<int>(type: "int", nullable: false),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false),
                    EtniaId = table.Column<int>(type: "int", nullable: false),
                    NombreCompletoRepresentante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DUI = table.Column<int>(type: "int", nullable: false),
                    TelefonoRepresentante = table.Column<int>(type: "int", nullable: false),
                    TelefonoTrabajoRepresentante = table.Column<int>(type: "int", nullable: false),
                    ParentescoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEstudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TEstudiantes_TEstadoCivil_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "TEstadoCivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEstudiantes_TEtnias_EtniaId",
                        column: x => x.EtniaId,
                        principalTable: "TEtnias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEstudiantes_TNacionalidades_NacionalidadId",
                        column: x => x.NacionalidadId,
                        principalTable: "TNacionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEstudiantes_TParentescos_ParentescoId",
                        column: x => x.ParentescoId,
                        principalTable: "TParentescos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_TDocentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "TDocentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TActasAsignadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    Acta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TActasAsignadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TActasAsignadas_TDocentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "TDocentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TActasAsignadas_TEstudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "TEstudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TDemeritosAsignados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    DemeritoId = table.Column<int>(type: "int", nullable: false),
                    DemeritosId = table.Column<int>(type: "int", nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDemeritosAsignados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TDemeritosAsignados_TDemertios_DemeritosId",
                        column: x => x.DemeritosId,
                        principalTable: "TDemertios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TDemeritosAsignados_TDocentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "TDocentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TDemeritosAsignados_TEstudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "TEstudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TFichasAsignadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    Ficha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFichasAsignadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TFichasAsignadas_TDocentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "TDocentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TFichasAsignadas_TEstudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "TEstudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TMatriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMatricula = table.Column<DateOnly>(type: "date", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    GradosId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaEgresion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMatriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TMatriculas_TEstados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "TEstados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMatriculas_TEstudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "TEstudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TMatriculas_TGrados_GradosId",
                        column: x => x.GradosId,
                        principalTable: "TGrados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TMeritosAsignados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    MeritosId = table.Column<int>(type: "int", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMeritosAsignados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TMeritosAsignados_TDocentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "TDocentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMeritosAsignados_TEstudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "TEstudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMeritosAsignados_TMeritos_MeritosId",
                        column: x => x.MeritosId,
                        principalTable: "TMeritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocenteId",
                table: "AspNetUsers",
                column: "DocenteId",
                unique: true,
                filter: "[DocenteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TActasAsignadas_DocenteId",
                table: "TActasAsignadas",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_TActasAsignadas_EstudianteId",
                table: "TActasAsignadas",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_TDemeritosAsignados_DemeritosId",
                table: "TDemeritosAsignados",
                column: "DemeritosId");

            migrationBuilder.CreateIndex(
                name: "IX_TDemeritosAsignados_DocenteId",
                table: "TDemeritosAsignados",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_TDemeritosAsignados_EstudianteId",
                table: "TDemeritosAsignados",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_TDocentes_GradosId",
                table: "TDocentes",
                column: "GradosId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TEstudiantes_EstadoCivilId",
                table: "TEstudiantes",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_TEstudiantes_EtniaId",
                table: "TEstudiantes",
                column: "EtniaId");

            migrationBuilder.CreateIndex(
                name: "IX_TEstudiantes_NacionalidadId",
                table: "TEstudiantes",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_TEstudiantes_ParentescoId",
                table: "TEstudiantes",
                column: "ParentescoId");

            migrationBuilder.CreateIndex(
                name: "IX_TFichasAsignadas_DocenteId",
                table: "TFichasAsignadas",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_TFichasAsignadas_EstudianteId",
                table: "TFichasAsignadas",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_TMatriculas_EstadoId",
                table: "TMatriculas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TMatriculas_EstudianteId",
                table: "TMatriculas",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_TMatriculas_GradosId",
                table: "TMatriculas",
                column: "GradosId");

            migrationBuilder.CreateIndex(
                name: "IX_TMeritosAsignados_DocenteId",
                table: "TMeritosAsignados",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_TMeritosAsignados_EstudianteId",
                table: "TMeritosAsignados",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_TMeritosAsignados_MeritosId",
                table: "TMeritosAsignados",
                column: "MeritosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TActasAsignadas");

            migrationBuilder.DropTable(
                name: "TDemeritosAsignados");

            migrationBuilder.DropTable(
                name: "TFichasAsignadas");

            migrationBuilder.DropTable(
                name: "TMatriculas");

            migrationBuilder.DropTable(
                name: "TMeritosAsignados");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TDemertios");

            migrationBuilder.DropTable(
                name: "TEstados");

            migrationBuilder.DropTable(
                name: "TEstudiantes");

            migrationBuilder.DropTable(
                name: "TMeritos");

            migrationBuilder.DropTable(
                name: "TDocentes");

            migrationBuilder.DropTable(
                name: "TEstadoCivil");

            migrationBuilder.DropTable(
                name: "TEtnias");

            migrationBuilder.DropTable(
                name: "TNacionalidades");

            migrationBuilder.DropTable(
                name: "TParentescos");

            migrationBuilder.DropTable(
                name: "TGrados");
        }
    }
}
