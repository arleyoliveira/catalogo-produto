using Catalogo.Context;
using Catalogo.Contracts;
using Catalogo.Models;

namespace Catalogo.Repositories
{
    internal sealed class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public Produto? GetById(int id) => _context.Produtos?.FirstOrDefault(p => p.ProdutoId == id);
    }
}