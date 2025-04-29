using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento : EntidadeBase
{
    public string Nome { get; set; }
    public Fabricante Fabricante { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; private set; }
    public string NumeroSerie
    {
        get
        {
            string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper();

            return $"{tresPrimeirosCaracteres}-{Id}";
        }
    }

    public Equipamento(string nome, decimal precoAquisicao, DateTime dataFabricacao, Fabricante fabricante)
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }



    public override void AtualizarRegistro(EntidadeBase registroEditado)
    {
        Equipamento equipamentoEditado = (Equipamento)registroEditado;

        Nome = equipamentoEditado.Nome;
        Fabricante = equipamentoEditado.Fabricante;
        PrecoAquisicao = equipamentoEditado.PrecoAquisicao;
        DataFabricacao = equipamentoEditado.DataFabricacao;
    }
}
