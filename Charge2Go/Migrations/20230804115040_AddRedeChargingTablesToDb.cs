using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charge2Go.Migrations
{
    /// <inheritdoc />
    public partial class AddRedeChargingTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RedeChargingPoints",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NormalChargingPointTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalChargingPointDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuickChargingPointTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuickChargingPointDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeChargingPoints", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RedeChargingTop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTop = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeChargingTop", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "RedeChargingPoints",
                columns: new[] { "ID", "NormalChargingPointDescription", "NormalChargingPointTitle", "QuickChargingPointDescription", "QuickChargingPointTitle" },
                values: new object[] { 1, "6 a 8 horas, em média, para o carregamento da totalidade da bateria num ponto\r\ncom uma potência de 3,7 kWh (ou 1 hora para 80% da capacidade num ponto de 22 kWh de potência,\r\na depender das características do veículo elétrico).", "Pontos de carregamento normal", "6 a 8 horas, em média, para o carregamento da totalidade da bateria num ponto\r\ncom uma potência de 3,7 kWh (ou 1 hora para 80% da capacidade num ponto de 22 kWh de potência,\r\na depender das características do veículo elétrico).", "Pontos de carregamento rápido" });

            migrationBuilder.InsertData(
                table: "RedeChargingTop",
                columns: new[] { "ID", "ImageTop", "Subtitle", "Title" },
                values: new object[] { 1, "", "O Carregamento de veículos elétricos em via pública pode ser efetuada de duas maneiras:", "Carregamento Na Via Pública" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RedeChargingPoints");

            migrationBuilder.DropTable(
                name: "RedeChargingTop");
        }
    }
}
