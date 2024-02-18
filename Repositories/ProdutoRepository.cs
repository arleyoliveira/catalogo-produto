using Catalogo.Context;
using Catalogo.Contracts;
using Catalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
            SaveChanges(produto);
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
            SaveChanges(produto);

            return produto;
        }

        public Produto Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            SaveChanges(produto);

            return produto;
        }

        private void SaveChanges(Produto produto) {
            _context.SaveChanges();
        }
    }
}