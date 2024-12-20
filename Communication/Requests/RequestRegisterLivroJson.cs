namespace Livraria.Communication.Requests;

public class RequestRegisterLivroJson
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public double Preco { get; set; }
    public int Qtd { get; set; }
}
