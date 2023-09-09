using LocBike.Models;
using LocBike.Repositorio;
using LocBike.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LocBike.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;
        public ClienteController(IClienteRepository clienteRepository) 
        {
            _repository = clienteRepository;
        }
        public IActionResult Index()
        {
            List<ClienteModel> clientes = _repository.BuscarTodos();
            return View(clientes);
        }

        public IActionResult AdicionarCliente()
        {
            return View();
        }

        public IActionResult EditarCliente(int id)
        {
            ClienteModel cliente = _repository.BuscarPorId(id);

            return View(cliente);
        }

        public IActionResult ExcluirCliente(int id)
        {
            ClienteModel cliente = _repository.BuscarPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            _repository.Adicionar(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            _repository.Atualziar(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            _repository.Apagar(id);
            return RedirectToAction("Index");
        }


    }
}
