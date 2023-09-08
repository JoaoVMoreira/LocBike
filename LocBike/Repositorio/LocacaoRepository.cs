using LocBike.Data;
using LocBike.Models;
using LocBike.Repositorio.Interface;

namespace LocBike.Repositorio
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly AppDbContext _context;
        public LocacaoRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public LocacaoModel Adicionar(LocacaoModel locacao)
        {
            if(locacao.DataDevolucao != null)
            {
                _context.Locacao.Add(locacao);
                TimeSpan diferenca = (TimeSpan)(locacao.DataDevolucao - locacao.DataLocacao);
                double dias = diferenca.TotalDays;
                locacao.ValorTotal = locacao.ValorDiaria * dias;
            }
            else
            {
                locacao.ValorTotal = 0;
            }
            
            _context.SaveChanges();
            return locacao;
        }

        public List<LocacaoModel> BuscarTodas()
        {
            List<LocacaoModel> locacoes =  _context.Locacao.ToList();
            return locacoes;
        }
    }
}
