using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlunosApiArnaldo.Migrations
{
    public partial class populatabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Idade", "Name" },
                values: new object[] { 1, "maria@teste.com", 42, "Maria da Penha" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Idade", "Name" },
                values: new object[] { 2, "fulano@teste.com", 43, "Fulano de Tall" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
