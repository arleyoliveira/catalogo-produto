using Catalogo.Models;
using Catalogo.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private IProdutoRepository repository;

        public ProdutosController(IProdutoRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = repository.GetAll();

            if (produtos is null)
                return NotFound();

            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = repository.GetById(id);

            if (produto is null)
                return NotFound("Produto não encontrado!");

            return produto;
        }

        [HttpPut("{id:int}", Name = "AtualizarProduto")]
        public ActionResult Put(int id, Produto produto)
        {
            if (produto is null || id != produto.ProdutoId)
                return BadRequest();

            repository.Update(produto);

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest("Dados produtos inválidos!");

            repository.Save(produto);

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            var produto = repository.GetById(id);

            if (produto is null)
                return NotFound("Produto não encontrado!");

            repository.Delete(produto);

            return NoContent();
        }
    }
}