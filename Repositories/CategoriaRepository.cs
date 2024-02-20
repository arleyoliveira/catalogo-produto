using Catalogo.Context;
using Catalogo.Contracts;
using Catalogo.Models;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Categoria> GetAllWithProducts()
        {
            return _context.Categorias.Include(c => c.Produtos).ToList();
        }
    }
}