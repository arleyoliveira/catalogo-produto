using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Categoria GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}