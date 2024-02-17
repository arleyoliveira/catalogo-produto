using Catalogo.Context;
using Catalogo.Contracts;
using Catalogo.Models;

namespace Catalogo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public Produto GetById(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        }

        public Produto Save(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto;
        }
    }
}