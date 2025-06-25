using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class inicioproyectoconsultorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadosTurno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosTurno", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModalidadesPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Modalidad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadesPago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Matricula = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesionales", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfesionalId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dni = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsParticular = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ObraSocial = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroAfiliado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Profesionales_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesionales",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactosEmergencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Relacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosEmergencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactosEmergencia_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Deudas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ProfesionalId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cancelada = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deudas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deudas_Profesionales_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    ProfesionalId = table.Column<int>(type: "int", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DuracionMinutos = table.Column<int>(type: "int", nullable: false),
                    EstadoTurnoId = table.Column<int>(type: "int", nullable: false),
                    CanceladoPorProfesional = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MotivoCancelacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_EstadosTurno_EstadoTurnoId",
                        column: x => x.EstadoTurnoId,
                        principalTable: "EstadosTurno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turnos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Turnos_Profesionales_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesionales",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TurnoId = table.Column<int>(type: "int", nullable: true),
                    Notas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Honorarios = table.Column<int>(type: "int", nullable: false),
                    Pagado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sesiones_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SesionId = table.Column<int>(type: "int", nullable: true),
                    ModalidadPagoId = table.Column<int>(type: "int", nullable: true),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_ModalidadesPago_ModalidadPagoId",
                        column: x => x.ModalidadPagoId,
                        principalTable: "ModalidadesPago",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pagos_Sesiones_SesionId",
                        column: x => x.SesionId,
                        principalTable: "Sesiones",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "EstadosTurno",
                columns: new[] { "Id", "Estado" },
                values: new object[,]
                {
                    { 1, "Reservado" },
                    { 2, "Confirmado" },
                    { 3, "Cancelado" },
                    { 4, "Atendido" },
                    { 5, "Ausente" }
                });

            migrationBuilder.InsertData(
                table: "ModalidadesPago",
                columns: new[] { "Id", "Modalidad" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta de crédito" },
                    { 3, "Tarjeta de débito" }
                });

            migrationBuilder.InsertData(
                table: "Profesionales",
                columns: new[] { "Id", "Email", "Especialidad", "Matricula", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "webersantiago@gmail.com", "Psicología", "4456", "Dr. Santiago Weber", "3498114782" },
                    { 2, "urriagavalentina@gmail.com", "Psicología", "8015", "Dra. Valentina Urriaga", "3498114789" }
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Direccion", "Dni", "Email", "EsParticular", "FechaNacimiento", "Nombre", "NumeroAfiliado", "ObraSocial", "ProfesionalId", "Telefono" },
                values: new object[,]
                {
                    { 1, "Italia 4787", "37138426", "abrilcosta@gmail.com", false, new DateTime(1999, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abril Costa", "265488245", "Sancor Salud", 1, "3498123456" },
                    { 2, "Belgrano 2410", "39420170", "joaquinvargas@gmail.com", true, new DateTime(1995, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joaquín Vargas", "", "Particular", 1, "3498234567" },
                    { 3, "25 de mayo 4254", "39421170", "emmaferro@gmail.com", true, new DateTime(1995, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma Ferro", "", "Particular", 2, "3498232687" }
                });

            migrationBuilder.InsertData(
                table: "ContactosEmergencia",
                columns: new[] { "Id", "Nombre", "PacienteId", "Relacion", "Telefono" },
                values: new object[,]
                {
                    { 1, "Alba Russo", 1, "Madre", "3498487726" },
                    { 2, "Julia Urriaga", 2, "Madre", "3498193565" },
                    { 3, "Benjamín Ferro", 3, "Padre", "349827446" }
                });

            migrationBuilder.InsertData(
                table: "Deudas",
                columns: new[] { "Id", "Cancelada", "Descripcion", "Fecha", "Monto", "PacienteId", "ProfesionalId" },
                values: new object[,]
                {
                    { 1, false, "Consulta inicial", new DateTime(2025, 6, 24, 21, 46, 6, 420, DateTimeKind.Local).AddTicks(385), 10000m, 1, 1 },
                    { 2, true, "Seguimiento", new DateTime(2025, 6, 14, 21, 46, 6, 420, DateTimeKind.Local).AddTicks(402), 5000m, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Turnos",
                columns: new[] { "Id", "CanceladoPorProfesional", "DuracionMinutos", "EstadoTurnoId", "FechaHora", "MotivoCancelacion", "PacienteId", "ProfesionalId" },
                values: new object[,]
                {
                    { 1, false, 60, 4, new DateTime(2025, 5, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1 },
                    { 2, false, 50, 4, new DateTime(2025, 6, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Sesiones",
                columns: new[] { "Id", "Honorarios", "Notas", "Pagado", "TurnoId" },
                values: new object[,]
                {
                    { 1, 2000, "", true, 1 },
                    { 2, 45, "", true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "Fecha", "ModalidadPagoId", "Monto", "SesionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20000, 1 },
                    { 2, new DateTime(2025, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 22000, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactosEmergencia_PacienteId",
                table: "ContactosEmergencia",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Deudas_PacienteId",
                table: "Deudas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Deudas_ProfesionalId",
                table: "Deudas",
                column: "ProfesionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ProfesionalId",
                table: "Pacientes",
                column: "ProfesionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ModalidadPagoId",
                table: "Pagos",
                column: "ModalidadPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_SesionId",
                table: "Pagos",
                column: "SesionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_TurnoId",
                table: "Sesiones",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_EstadoTurnoId",
                table: "Turnos",
                column: "EstadoTurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PacienteId",
                table: "Turnos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ProfesionalId",
                table: "Turnos",
                column: "ProfesionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactosEmergencia");

            migrationBuilder.DropTable(
                name: "Deudas");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "ModalidadesPago");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "EstadosTurno");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Profesionales");
        }
    }
}
