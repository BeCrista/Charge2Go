using Charge2Go.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Charge2Go.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<HomePageSlider> SliderTop { get; set; }

        public DbSet<HomePageMiddle> ImageMiddle { get; set; }

        public DbSet<TariffTop> TariffTop { get; set; }

        public DbSet<TariffMiddle> TariffMiddle { get; set; }

        public DbSet<TariffBottom> TariffBottom { get; set; }

        public DbSet<RedeChargingTop> RedeChargingTop { get; set; }

        public DbSet<RedeChargingPoint> RedeChargingPoints { get; set; }

        public DbSet<FAQS> FAQs { get; set; }

        public DbSet<FAQSQuestions> FAQsQuestions { get; set; }

        public DbSet<ContactUsForm> ContactUs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HomePageSlider>().HasData(
                new HomePageSlider { ID = 1, TitleSlider = "Cartão Charge2Go", SubTitleSlider ="Adira e beneficie de todas as vantagens", ImageSlider = ""},
                new HomePageSlider { ID = 2, TitleSlider = "", SubTitleSlider = "", ImageSlider = ""}
                );

            builder.Entity<HomePageMiddle>().HasData(
                new HomePageMiddle { ID = 1, ImageMiddle = "", ImageMiddleTitle = "A nossa energia, a sua mobilidade.", ImageMiddleSubtitle = "A KLC e a Ecochoice desenvolveram uma solução de mobilidade eléctrica integrada para si!"}
            );

            builder.Entity<TariffTop>().HasData(
                new TariffTop { ID = 1, ImageTop = "", Description = "Na Charge2Go temos tarifas que se adaptam na perfeição às necessidades dos nossos clientes.", ImageCard = ""}
                );

            builder.Entity<TariffMiddle>().HasData(
                new TariffMiddle { ID = 1, TariffPriceImage = "", TariffPriceDescription = "Os valores apresentados incluem as tarifas de acesso à rede, definidas pela ERSE, para 2023. Excluem-se os custos correspondentes ao imposto especial de consumo (IEC) e taxas de OPC, acrescido de IVA à taxa legal.\r\n\r\nAdicionalmente será aplicada a taxa EGME, definida pela ERSE, com valor de 0,2608 €/carregamento. A este valor será aplicado o desconto do Fundo Ambiental de 0,1902 €/carregamento.\r\n\r\nPreços válidos a partir de 01/07/2023.\r\n\r\nO cliente pode usufruir do fornecimento de um carregador CHARGE2GO de 3.6kW com um custo mensal de 25,90 € durante 36 meses.", TariffScheduleImage = "", TariffScheduleDescription = "Os restantes Intervalos de tempo não discriminados, correspondem às horas fora de vazio. (períodos do dia em que o preço da energia é mais elevado).", TariffCampaignImage = "", TariffCampaignDescription = "Em qualquer um dos planos o cliente pode usufruir do fornecimento de um carregador “Plug and Charge”de:\r\n\r\n \r\n\r\n3,6kW com fidelização de 36 meses e com um custo mensal adicional de\r\n\r\n25,90€" }
                );

            builder.Entity<TariffBottom>().HasData(
                new TariffBottom { ID = 1, TariffSolutionImage = "", TariffSolutionTitle = "Aproveite ainda outra solução Charge2Go", TariffSolutionSubtitle = "Oferta integrada de solução de carregamento de veículos elétricos e tarifário para a mobilidade elétrica!" }
                );


            builder.Entity<RedeChargingTop>().HasData(
                new RedeChargingTop { ID = 1, Title = "Carregamento Na Via Pública", Subtitle = "O Carregamento de veículos elétricos em via pública pode ser efetuada de duas maneiras:", ImageTop = "" }
                );

            builder.Entity<RedeChargingPoint>().HasData(
                new RedeChargingPoint { ID = 1, NormalChargingPointTitle = "Pontos de carregamento normal", NormalChargingPointDescription = "6 a 8 horas, em média, para o carregamento da totalidade da bateria num ponto\r\ncom uma potência de 3,7 kWh (ou 1 hora para 80% da capacidade num ponto de 22 kWh de potência,\r\na depender das características do veículo elétrico).", QuickChargingPointTitle = "Pontos de carregamento rápido", QuickChargingPointDescription = "6 a 8 horas, em média, para o carregamento da totalidade da bateria num ponto\r\ncom uma potência de 3,7 kWh (ou 1 hora para 80% da capacidade num ponto de 22 kWh de potência,\r\na depender das características do veículo elétrico)." }
                );


            builder.Entity<FAQS>().HasData(
                new FAQS { ID = 1, Title = "Perguntas\r\nMais Frequentes", ImageFAQs = "" }
                );

            builder.Entity<FAQSQuestions>().HasData(
                new FAQSQuestions { ID = 1, QuestionFAQ = "Posso utilizar o cartão CHARGE2GO apenas nos postos CHARGE2GO?", AnswerFAQ = "Não, o cartão CHARGE2GO pode ser utilizado em qualquer ponto de carregamento integrado na rede pública de mobilidade elétrica." }
                );
        }
    }
}
