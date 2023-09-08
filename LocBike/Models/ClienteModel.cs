namespace LocBike.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public long Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
