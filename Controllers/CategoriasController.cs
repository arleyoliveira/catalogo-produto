using Catalogo.Contracts;
using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository _repository;

        public CategoriasController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _repository.GetAll();

            if (categorias is null)
                return NotFound();

            return categorias;
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _repository.GetById(id);

            if (categoria is null)
                return NotFound("Categoria não encontrado!");

            return categoria;
        }

        [HttpPut("{id:int}", Name = "AtualizarCategoria")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (categoria is null || id != categoria.CategoriaId)
                return BadRequest();

            _repository.Update(categoria);

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest("Dados categorias inválidos!");

            _repository.Save(categoria);

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            var categoria = _repository.GetById(id);

            if (categoria is null)
                return NotFound("Categoria não encontrado!");

            _repository.Delete(categoria);

            return NoContent();
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos() {
            return Ok(_repository.GetAllWithProducts());
        }
    }
}