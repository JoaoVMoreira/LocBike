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

            try
            {

                if (ModelState.IsValid)
                {
                    LocacaoModel locacao = _repository.Adicionar(locacaoModel);
                    TempData["MensagemSucesso"] = "Cadastro de locação realziado com sucesso!";
                    return RedirectToAction("Index");
                }

                List<ClienteModel> clientes = _clienteRepository.BuscarTodos();
                LocacaoViewModel locacaoViewModel = new LocacaoViewModel();
                locacaoViewModel.clienteModels = clientes;
                locacaoViewModel.LocacaoModel = locacaoModel;


                return View("AdicionarLocacao", locacaoViewModel);
            }
            catch (Exception ex) {

                TempData["MensagemErro"] = $"Oops... Ocorreu um erro: {ex.Message}";

                List<ClienteModel> clientes = _clienteRepository.BuscarTodos();
                LocacaoViewModel locacaoViewModel = new LocacaoViewModel();
                locacaoViewModel.clienteModels = clientes;
                locacaoViewModel.LocacaoModel = locacaoModel;


                return View("AdicionarLocacao", locacaoViewModel);
            }

        }

        [HttpPost]
        public IActionResult Alterar(LocacaoModel locacaoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Atualizar(locacaoModel);
                    TempData["MensagemSucesso"] = "Locação alterada com sucesso";
                    return RedirectToAction("Index");
                }
                List<ClienteModel> clientes = _clienteRepository.BuscarTodos();
                LocacaoViewModel locacaoViewModel = new LocacaoViewModel();
                locacaoViewModel.clienteModels = clientes;
                locacaoViewModel.LocacaoModel = locacaoModel;
                return View("EditarLocacao", locacaoViewModel);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops... Ocorreu um erro ao atualizar a locação: {ex.Message}";
                return View("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            _repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
