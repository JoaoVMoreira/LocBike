using LocBike.Models;

namespace LocBike.Repositorio.Interface
{
    public interface IClienteRepository
    {
        ClienteModel Adicionar(ClienteModel cliente);

        List<ClienteModel> BuscarTodos();
    }
}
