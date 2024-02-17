using Catalogo.Models;

namespace Catalogo.Contracts
{
    public interface IProdutoRepository
    {
         public List<Produto> GetAll();
         public Produto GetById(int id);
         public Produto Save(Produto produto);
    }
}