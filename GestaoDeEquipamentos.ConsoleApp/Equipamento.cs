namespace GestaoDeEquipamentos.ConsoleApp;

public class Equipamento
{
    public int ID; //sempre algo unico
    public string Nome;
    public string Fabricante;
    public decimal PrecoAquisicao;
    public DateTime DataFabricacao;

    public Equipamento(string nome, string fabricante, decimal precoAquisicao, DateTime dataFabricacao)
    {
        Nome = nome;
        Fabricante = fabricante;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
    }

    // regra de negócio
    public string ObterNumeroSerie()
    {
        // SubString dado um indice, retorna tudo depois do valor ex: ABCDE se o indice for 2, irá retornar DE, o resto
        // usando dois numeros, ele retorna o valor entre os dois indices, do zero ate o tres
        string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper();

        return $"{tresPrimeirosCaracteres}-{ID}";
    }

}
