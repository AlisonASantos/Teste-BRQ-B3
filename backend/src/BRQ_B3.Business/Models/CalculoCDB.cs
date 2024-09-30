using BRQ_B3.Business.Models;

namespace BRQ_B3.Business.Models
{
    public class CalculoCDB : Entity
    {
        public decimal ValorInicial { get; set; }
        public decimal Cdi { get; set; }
        public decimal TaxaBanco { get; set; }
        public int Meses { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
