using Catalogo.Context;
using Catalogo.Contracts;
using Catalogo.Models;

namespace Catalogo.Repositories
{
    internal sealed class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }

        public Categoria? GetById(int id)
        {
            return _context.Categorias?.FirstOrDefault(c => c.CategoriaId == id);
        }
    }
}