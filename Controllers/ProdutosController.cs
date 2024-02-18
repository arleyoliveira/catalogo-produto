using Catalogo.Models;
using Catalogo.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private IProdutoRepository _repository;

        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _repository.GetAll();

            if (produtos is null)
                return NotFound();

            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _repository.GetById(id);

            if (produto is null)
                return NotFound("Produto não encontrado!");

            return produto;
        }

        [HttpPut("{id:int}", Name = "AtualizarProduto")]
        public ActionResult Put(int id, Produto produto)
        {
            if (produto is null || id != produto.ProdutoId)
                return BadRequest();

            _repository.Update(produto);

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest("Dados produtos inválidos!");

            _repository.Save(produto);

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            var produto = _repository.GetById(id);

            if (produto is null)
                return NotFound("Produto não encontrado!");

            _repository.Delete(produto);

            return NoContent();
        }
    }
}