//public record Pessoa(int Id, string Nome, string Cpf, int IdCidade, int idade, Cidade Cidade);

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
    public int IdCidade { get; set; }
    public Cidade Cidade { get; set; }
}