using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LocBike.Models
{
    [Index(nameof(NomeCliente), IsUnique = true)]
    public class LocacaoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Informe a data da locação")]
        [DataType(DataType.Date)]
        public DateTime DataLocacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataDevolucao { get; set; }

        [Required(ErrorMessage = "Informe o valor da diária")]
        public double ValorDiaria { get; set; }

        public double ValorTotal { get; set; }
    }
}