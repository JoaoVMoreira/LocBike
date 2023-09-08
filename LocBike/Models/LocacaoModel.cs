namespace LocBike.Models
{
    public class LocacaoModel
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public DateOnly DataLocacao { get; set; }
        public DateOnly? DataDevolucao { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorTotal { get; set; }
    }
}