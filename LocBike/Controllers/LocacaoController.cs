using LocBike.Data;
using LocBike.Models;
using LocBike.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LocBike.Controllers
{
    public class LocacaoController : Controller
    {
        protected readonly ILocacaoRepository _repository;

        public LocacaoController(ILocacaoRepository locacaoRepository)
        {
            _repository = locacaoRepository;
        }

        public IActionResult Index()
        {
            List<LocacaoModel> locacoes = _repository.BuscarTodas();
            return View(locacoes);
        }

        public IActionResult AdicionarLocacao()
        {
            return View();
        }

        public IActionResult EditarLocacao()
        {
            return View();
        }

        public IActionResult ExcluirLocacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(LocacaoModel locacaoModel)
        {
            LocacaoModel locacao = _repository.Adicionar(locacaoModel);
            return RedirectToAction("Index");
        }
    }
}
