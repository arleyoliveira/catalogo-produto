using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Contracts
{
    public interface IRepositoryBase<T>
    {
        public List<T> GetAll();
        public T? GetById(int id);
        public T Save(T produto);
        public T Update(T produto);
        public void Delete(T produto);
    }
}