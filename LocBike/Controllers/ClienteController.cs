using LocBike.Models;
using LocBike.Repositorio;
using LocBike.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            try
            {

                if (!ModelState.IsValid)
                {
                    return View("AdicionarCliente", cliente);

                }
                else
                {
                    _repository.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops... Ocorreu um erro: {ex.Message}";
                return RedirectToAction("Index");
            }
         
        }


        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Atualziar(cliente);
                    TempData["MensagemSucesso"] = "Alteração realizada com sucesso";
                    return RedirectToAction("Index");
                }
                return View("EditarCliente", cliente);
            }
            catch (Exception ex) {
                TempData["MensagemErro"] = "Ops... Ocorreu um erro na alteração";
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
