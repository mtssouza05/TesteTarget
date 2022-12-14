using Testetarget.Data;
using Testetarget.Models;

namespace Testetarget.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public ProdutoModel ListarPorId(int id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x=>x.Id==id);
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarPorId(produto.Id);

            if (produtoDB == null) throw new System.Exception("Houve um erro ao atualizar");

            produtoDB.Nome = produto.Nome;
            produtoDB.Valor = produto.Valor;
            produtoDB.Disponibilidade = produto.Disponibilidade;

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();
            return produtoDB;

        }

        public bool Apagar(int id)
        {
            ProdutoModel produtoDB = ListarPorId(id);

            if (produtoDB == null) throw new System.Exception("Houve um erro ao deletar");
            _bancoContext.Produtos.Remove(produtoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
