using AniversariantesSubti.Models;
using AniversariantesSubti.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AniversariantesSubti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AniversariantesController : ControllerBase
    {
        private readonly IAniversariantesRepository _repository;

        public AniversariantesController(IAniversariantesRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Aniversariantes>> ListarTodosAniversariantes()
        {
            IEnumerable<Aniversariantes> aniversariantes = _repository.ObterTodos();

            return Ok(aniversariantes);
        }

        [HttpGet("ObterPorNome")]
        public ActionResult<Aniversariantes> ObterPorNome([FromQuery] string nome)
        {
            var Aniversariante = _repository.ObterPorNome(nome);
            if (Aniversariante == null)
            {
                return NotFound("Aniversariante nao encontrado");
            }
            return Ok(Aniversariante);
        }



        [HttpPost]
        public ActionResult Post([FromBody] Aniversariantes aniversariantes)
        {
            _repository.Adicionar(aniversariantes);
            return Ok("Codigo do aniversariante INCLUIDO: " + aniversariantes.Id);

        }

        //[HttpPut]

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var aniversariante = _repository.ObterPorId(id);
            if (aniversariante is null)
            {
                return BadRequest("Aniversariante nao encontrado");
            }
            else
            {
                _repository.Remover(id);
                return Ok(" Codigo do Aniversariante DELETADO: " + id);
            }
        }
    }
}
