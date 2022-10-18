using Microsoft.AspNetCore.Mvc;
using Testetarget.Models;
using Testetarget.Repositorios;

namespace Testetarget.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public IActionResult Index()
        {
            List<ProdutoModel> produtos=_produtoRepositorio.BuscarTodos();

            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Deletar(int id)
        {
            _produtoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            _produtoRepositorio.Adicionar(produto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            _produtoRepositorio.Atualizar(produto);
            return RedirectToAction("Index");
        }

    }
}
