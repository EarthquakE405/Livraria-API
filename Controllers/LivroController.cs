using Livraria.Communication.Requests;
using Livraria.Communication.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LivroController : ControllerBase
{
    private static List<Livro> livros = new List<Livro>();
    private static int AutomaticId = 1;


    [HttpGet]
    [ProducesResponseType(typeof(Livro), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),  StatusCodes.Status400BadRequest)]
    public IActionResult GetLivro()
    {
        return Ok(livros);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponsesRegisterLivroJson), StatusCodes.Status201Created)]
    public IActionResult CreateLivro([FromBody]RequestRegisterLivroJson request)
    {
        var novoLivro = new Livro
        {
            Id = AutomaticId++,
            Titulo = request.Titulo,
            Autor = request.Autor,
            Genero = request.Genero,
            Preco = request.Preco,
            Qtd = request.Qtd
        };

        livros.Add(novoLivro);

        var response = new ResponsesRegisterLivroJson
        {
            Id = novoLivro.Id,
            Titulo = novoLivro.Titulo
        };  
        return Created(String.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateLivro(
        [FromRoute] int id,
        [FromBody] RequestUpdateLivroJson request)
    {
        var livro = livros.Find(l => l.Id == id);
        if (livro == null)
        {
            return NotFound($"Livro com id {id} não encontrado.");
        }

        livro.Titulo = request.Titulo;
        livro.Autor = request.Autor;
        livro.Genero = request.Genero;
        livro.Preco = request.Preco;
        livro.Qtd = request.Qtd;

        return NoContent();

    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteLivro([FromRoute] int id)
    {
        var livro = livros.Find(l => l.Id == id);
        if (livro == null)
        {
            return NotFound($"Livro com id {id} não encontrado.");
        }
        var TituloDeletado = livro.Titulo;

        livros.Remove(livro);

        return Ok($"Livro '{TituloDeletado}' foi deletado com sucesso.");

    }


}
