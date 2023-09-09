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
                locacao.DataDevolucao = null;
            }
            
            _context.SaveChanges();
            return locacao;
        }

        public bool Apagar(int id)
        {
            LocacaoModel locacaoModel = BuscarPorId(id);

            if(locacaoModel == null) { throw new Exception("Locação não localizada"); }
            _context.Locacao.Remove(locacaoModel);
            _context.SaveChanges();
            return true;
        }

        public LocacaoModel Atualizar(LocacaoModel locacao)
        {
            LocacaoModel locacaoModel = BuscarPorId(locacao.Id);
            if(locacaoModel == null) { throw new Exception("Locação não localizada"); }

            locacaoModel.NomeCliente = locacao.NomeCliente;
            locacaoModel.DataLocacao = locacao.DataLocacao;
            locacaoModel.DataDevolucao = locacao.DataDevolucao;
            locacaoModel.ValorDiaria= locacao.ValorDiaria;

            TimeSpan diferenca = (TimeSpan)(locacao.DataDevolucao - locacao.DataLocacao);
            double dias = diferenca.TotalDays;
            locacaoModel.ValorTotal = locacao.ValorDiaria * dias;

            _context.Locacao.Update(locacaoModel);
            _context.SaveChanges();

            return locacaoModel;
        }

        public LocacaoModel BuscarPorId(int id)
        {
            LocacaoModel locacao = _context.Locacao.FirstOrDefault(x => x.Id == id);
            return locacao;
        }

        public List<LocacaoModel> BuscarTodas()
        {
            List<LocacaoModel> locacoes =  _context.Locacao.ToList();
            return locacoes;
        }
    }
}
