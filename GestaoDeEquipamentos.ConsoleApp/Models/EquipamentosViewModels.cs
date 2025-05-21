using GestaoDeEquipamentos.ConsoleApp.Extensions;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Models;

public abstract class FormularioEquipamentoViewModel
{
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }

    /* Passando apenas o ID do fabricante para nao chamar o Fabricante completo para o método
       Pega-se uma unica informacao identificadora para depois recuperar                   */
    public int FabricanteId { get; set; }

    public List<SelecionarFabricanteViewModel> FabricantesDisponiveis { get; set; }

    protected FormularioEquipamentoViewModel()
    {
        FabricantesDisponiveis = new List<SelecionarFabricanteViewModel>();
    }
}

public class SelecionarFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFabricanteViewModel(int id, string nome)
    {
        Nome = nome;
        Id = id;
    }
}

public class CadastrarEquipamentoViewModel : FormularioEquipamentoViewModel
{
    public CadastrarEquipamentoViewModel() { }
    public CadastrarEquipamentoViewModel(List<Fabricante> fabricantes) : this()
    {
        foreach (var f in fabricantes)
        {
            var selecionarVM = new SelecionarFabricanteViewModel(f.Id, f.Nome);

            FabricantesDisponiveis.Add(selecionarVM);
        }
    }
}

public class EditarEquipamentoViewModel : FormularioEquipamentoViewModel
{
    public int Id { get; set; }
    public EditarEquipamentoViewModel() { }

    public EditarEquipamentoViewModel(int id, string nome, decimal precoAquisicao, 
                                      DateTime dataFabricacao, int fabricanteId, List<Fabricante> fabricantes)
    {
        Id = id;
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        FabricanteId = fabricanteId;

        foreach (var f in fabricantes)
        {
            var selecionarVM = new SelecionarFabricanteViewModel(f.Id, f.Nome);

            FabricantesDisponiveis.Add(selecionarVM);
        }
    }
}

public class VisualizarEquipamentosViewModel
{
    public List<DetalhesEquipamentoViewModel> Registros { get; set; }

    public VisualizarEquipamentosViewModel(List<Equipamento> equipamentos)
    {
        Registros = new List<DetalhesEquipamentoViewModel>();

        foreach (var e in equipamentos)
        {
            DetalhesEquipamentoViewModel detalhesVM = e.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public string NomeFabricante { get; set; }

    public DetalhesEquipamentoViewModel(int id, string nome, decimal precoAquisicao, 
                                        DateTime dataFabricacao, string nomeFabricante)
    {
        Id = id;
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        NomeFabricante = nomeFabricante;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Nome: {Nome} - Fabricante: {NomeFabricante}"
               + $" - Preço de Aquisição: {PrecoAquisicao:C2} - Data de Fabricação: {DataFabricacao:d}";
    }
}
