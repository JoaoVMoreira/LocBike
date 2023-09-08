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

        public IActionResult EditarCliente()
        {
            return View();
        }

        public IActionResult ExcluirCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            _repository.Adicionar(cliente);
            return RedirectToAction("Index");
        }

    }
}
