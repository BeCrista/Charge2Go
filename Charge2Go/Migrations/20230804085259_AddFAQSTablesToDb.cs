using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charge2Go.Migrations
{
    /// <inheritdoc />
    public partial class AddFAQSTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFAQs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FAQsQuestions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionFAQ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerFAQ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQsQuestions", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "ID", "ImageFAQs", "Title" },
                values: new object[] { 1, "", "Perguntas\r\nMais Frequentes" });

            migrationBuilder.InsertData(
                table: "FAQsQuestions",
                columns: new[] { "ID", "AnswerFAQ", "QuestionFAQ" },
                values: new object[] { 1, "Não, o cartão CHARGE2GO pode ser utilizado em qualquer ponto de carregamento integrado na rede pública de mobilidade elétrica.", "Posso utilizar o cartão CHARGE2GO apenas nos postos CHARGE2GO?" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "FAQsQuestions");
        }
    }
}
