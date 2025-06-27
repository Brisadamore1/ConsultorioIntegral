using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class agreguecorrecciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Honorarios",
                table: "Sesiones",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Pagos",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Deudas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 6, 26, 18, 37, 50, 484, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "Deudas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 6, 16, 18, 37, 50, 484, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.InsertData(
                table: "ModalidadesPago",
                columns: new[] { "Id", "Modalidad" },
                values: new object[] { 4, "Transferencia" });

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Monto",
                value: 20000m);

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Monto",
                value: 22000m);

            migrationBuilder.UpdateData(
                table: "Sesiones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Honorarios", "Notas" },
                values: new object[] { 20000m, "Paciente se presentó puntual. Refirió sentirse ansioso por situaciones laborales. Se trabajó en identificar factores desencadenantes. Buena predisposición al diálogo." });

            migrationBuilder.UpdateData(
                table: "Sesiones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Honorarios", "Notas" },
                values: new object[] { 20000m, "Paciente mencionó recuerdos de infancia que impactaron emocionalmente. Profundizar en vínculos afectivos en la próxima sesión." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModalidadesPago",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Honorarios",
                table: "Sesiones",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<int>(
                name: "Monto",
                table: "Pagos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.UpdateData(
                table: "Deudas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 6, 24, 21, 46, 6, 420, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "Deudas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 6, 14, 21, 46, 6, 420, DateTimeKind.Local).AddTicks(402));

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Monto",
                value: 20000);

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Monto",
                value: 22000);

            migrationBuilder.UpdateData(
                table: "Sesiones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Honorarios", "Notas" },
                values: new object[] { 2000, "" });

            migrationBuilder.UpdateData(
                table: "Sesiones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Honorarios", "Notas" },
                values: new object[] { 45, "" });
        }
    }
}
