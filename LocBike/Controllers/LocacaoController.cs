using LocBike.Data;
using LocBike.Models;
using LocBike.Repositorio.Interface;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;

namespace LocBike.Controllers
{
    public class LocacaoController : Controller
    {
        protected readonly ILocacaoRepository _repository;
        protected readonly IClienteRepository _clienteRepository;

        public LocacaoController(ILocacaoRepository locacaoRepository, IClienteRepository clienteRepository)
        {
            _repository = locacaoRepository;
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            List<LocacaoModel> locacoes = _repository.BuscarTodas();
            return View(locacoes);
        }

        public IActionResult AdicionarLocacao()
        {
            LocacaoModel locacao = new LocacaoModel();
            List<ClienteModel> clientes = _clienteRepository.BuscarTodos();
            LocacaoViewModel locacaoViewModel = new LocacaoViewModel();
            locacaoViewModel.clienteModels = clientes;
            return View(locacaoViewModel);
        }

        public IActionResult EditarLocacao(int id)
        {
            LocacaoModel locacao = _repository.BuscarPorId(id);
            List<ClienteModel> clientes = _clienteRepository.BuscarTodos();
            LocacaoViewModel locacaoViewModel = new LocacaoViewModel();
            locacaoViewModel.clienteModels = clientes;
            locacaoViewModel.LocacaoModel = locacao;
            return View(locacaoViewModel);
        }

        public IActionResult ExcluirLocacao(int id)
        {
            LocacaoModel locacao = _repository.BuscarPorId(id);
            return View(locacao);
        }

        [HttpPost]
        public IActionResult Adicionar(LocacaoModel locacaoModel)
        {
            LocacaoModel locacao = _repository.Adicionar(locacaoModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(LocacaoModel locacaoModel)
        {
            _repository.Atualizar(locacaoModel);

            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
