using Microsoft.EntityFrameworkCore;

namespace LocBike.Models
{
    [Index(nameof(NomeCliente), IsUnique = true)]
    public class LocacaoModel
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorTotal { get; set; }
    }
}