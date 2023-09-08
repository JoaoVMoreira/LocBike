using LocBike.Models;

namespace LocBike.Repositorio.Interface
{
    public interface ILocacaoRepository
    {
        LocacaoModel Adicionar(LocacaoModel locacao);
        List<LocacaoModel> BuscarTodas();
    }
}
