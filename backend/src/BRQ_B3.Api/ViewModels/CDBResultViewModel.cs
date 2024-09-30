namespace BRQ_B3.Api.ViewModels
{
    public class CDBResultViewModel
    {
        public Guid Id { get; set; }

        public decimal ValorInicial { get; set; }
        public decimal Cdi { get; set; }
        public decimal TaxaBanco { get; set; }
        public int Meses { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
