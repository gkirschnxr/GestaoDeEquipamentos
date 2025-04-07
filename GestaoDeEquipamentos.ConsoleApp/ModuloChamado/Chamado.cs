namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
public class Chamado
{
    public int ID; //sempre algo unico
    public string Motivo;
    public string Descricao;
    public int IdEquipamento;
    public DateTime DataChamado;

    public Chamado(string motivo, string descricao, int idequipamento, DateTime dataChamado)
    {
        Motivo = motivo;
        Descricao = descricao;
        IdEquipamento = idequipamento;
        DataChamado = dataChamado;
    }

    // regra de negócio
    public string ObterNumeroSerie()
    {
        // SubString dado um indice, retorna tudo depois do valor ex: ABCDE se o indice for 2, irá retornar DE, o resto
        // usando dois numeros, ele retorna o valor entre os dois indices, do zero ate o tres
        string tresPrimeirosCaracteres = Motivo.Substring(0, 3).ToUpper();

        return $"{tresPrimeirosCaracteres}-{ID}";
    }
}
