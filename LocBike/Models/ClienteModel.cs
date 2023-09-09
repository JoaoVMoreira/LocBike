using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LocBike.Models
{
    [Index(nameof(Nome), IsUnique = true)]
    [Index(nameof(Telefone), IsUnique = true)]
    public class ClienteModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Informe o nome do cliente")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Endereço inválido")]
        public string Endereco { get; set; }
        
        [Required(ErrorMessage = "Informe o telefone do cliente")]
        public long Telefone { get; set; }
        
        
        [Required(ErrorMessage = "Informe a data de nascimento do usuário")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
