//public record Cidade(int Id, string Nome, string Uf, List<Pessoa> Pessoas);

public class Cidade
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Uf { get; set; }
    public List<Pessoa> Pessoas { get; set; }
}
