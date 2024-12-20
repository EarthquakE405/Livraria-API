namespace Livraria.Communication.Requests;
using System.ComponentModel.DataAnnotations;

public class RequestUpdateLivroJson
{
    [Required] public string Titulo { get; set; } = string.Empty;
    [Required] public string Autor { get; set; } = string.Empty;
    [Required] public string Genero { get; set; } = string.Empty;
    [Required] public double Preco { get; set; }
    [Required] public int Qtd { get; set; }
}
