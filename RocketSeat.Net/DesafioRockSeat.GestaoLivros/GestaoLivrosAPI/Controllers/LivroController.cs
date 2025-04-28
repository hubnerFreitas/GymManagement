using GestaoLivrosAPI.Communication;
using GestaoLivrosAPI.UseCases.CaseLivro;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreteLivroJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] RequestCreateLivroJson request)
        {
            var createLivroCase = new CreateLivroUseCase();
            var response = createLivroCase.Execute(request);
            
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseListaLivroJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseListaLivroJson), StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            var listaLivroCase = new ListaLivroUseCase();

            var response = listaLivroCase.Execute();

            return Ok(response);
        }


        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseListaLivroJson), StatusCodes.Status200OK)]
        public IActionResult Update(
            [FromRoute] Guid id,
            [FromBody] RequestUpdateLivroJson request)
        {
            var updateLivroCase = new UpdateLivroUseCase();
            var livro = updateLivroCase.Execute(id, request);

            return Ok(livro);
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var deleteCase = new DeleteLivroUseCase();
            deleteCase.Execute(id);

            return NoContent();
        }
    }
}
