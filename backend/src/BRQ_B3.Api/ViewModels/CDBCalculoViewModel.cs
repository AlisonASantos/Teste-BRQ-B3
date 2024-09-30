using System.ComponentModel.DataAnnotations;

namespace BRQ_B3.Api.ViewModels
{
    public class CDBCalculoViewModel
    {    
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorInicial { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Cdi { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal TaxaBanco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Meses { get; set; }

    }
}