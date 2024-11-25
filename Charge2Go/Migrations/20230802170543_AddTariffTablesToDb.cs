using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charge2Go.Migrations
{
    /// <inheritdoc />
    public partial class AddTariffTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TariffBottom",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffSolutionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TariffSolutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TariffSolutionSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffBottom", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TariffMiddle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffPriceImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TariffPriceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TariffScheduleImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TariffScheduleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TariffCampaignImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TariffCampaignDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffMiddle", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TariffTop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageCard = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffTop", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "TariffBottom",
                columns: new[] { "ID", "TariffSolutionImage", "TariffSolutionSubtitle", "TariffSolutionTitle" },
                values: new object[] { 1, "", "Oferta integrada de solução de carregamento de veículos elétricos e tarifário para a mobilidade elétrica!", "Aproveite ainda outra solução Charge2Go" });

            migrationBuilder.InsertData(
                table: "TariffMiddle",
                columns: new[] { "ID", "TariffCampaignDescription", "TariffCampaignImage", "TariffPriceDescription", "TariffPriceImage", "TariffScheduleDescription", "TariffScheduleImage" },
                values: new object[] { 1, "Em qualquer um dos planos o cliente pode usufruir do fornecimento de um carregador “Plug and Charge”de:\r\n\r\n \r\n\r\n3,6kW com fidelização de 36 meses e com um custo mensal adicional de\r\n\r\n25,90€", "", "Os valores apresentados incluem as tarifas de acesso à rede, definidas pela ERSE, para 2023. Excluem-se os custos correspondentes ao imposto especial de consumo (IEC) e taxas de OPC, acrescido de IVA à taxa legal.\r\n\r\nAdicionalmente será aplicada a taxa EGME, definida pela ERSE, com valor de 0,2608 €/carregamento. A este valor será aplicado o desconto do Fundo Ambiental de 0,1902 €/carregamento.\r\n\r\nPreços válidos a partir de 01/07/2023.\r\n\r\nO cliente pode usufruir do fornecimento de um carregador CHARGE2GO de 3.6kW com um custo mensal de 25,90 € durante 36 meses.", "", "Os restantes Intervalos de tempo não discriminados, correspondem às horas fora de vazio. (períodos do dia em que o preço da energia é mais elevado).", "" });

            migrationBuilder.InsertData(
                table: "TariffTop",
                columns: new[] { "ID", "Description", "ImageCard", "ImageTop" },
                values: new object[] { 1, "Na Charge2Go temos tarifas que se adaptam na perfeição às necessidades dos nossos clientes.", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TariffBottom");

            migrationBuilder.DropTable(
                name: "TariffMiddle");

            migrationBuilder.DropTable(
                name: "TariffTop");
        }
    }
}
