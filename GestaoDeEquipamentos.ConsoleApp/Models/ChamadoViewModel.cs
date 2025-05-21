using GestaoDeEquipamentos.ConsoleApp.Extensions;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.Models;

public abstract class FormularioChamadoViewModel
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataAbertura { get; set; }
    public int TempoDecorrido { get; set; }
    public int EquipamentoId { get; set; }
    public List<SelecionarEquipamentoViewModel> EquipamentosDisponiveis { get; set; }

    protected FormularioChamadoViewModel()
    {
        EquipamentosDisponiveis = new List<SelecionarEquipamentoViewModel>();
    }
}

public class SelecionarEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarEquipamentoViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class CadastrarChamadoViewModel : FormularioChamadoViewModel
{
    public CadastrarChamadoViewModel() { }
    public CadastrarChamadoViewModel(List<Equipamento> equipamentos) : this()
    {
        foreach (var e in equipamentos)
        {
            var selecionarVM = new SelecionarEquipamentoViewModel(e.Id, e.Nome);

            EquipamentosDisponiveis.Add(selecionarVM);
        }
    }
}

public class VisualizarChamadoViewModel
{
    public List<DetalhesChamadoViewModel> Registros { get; set; }

    public VisualizarChamadoViewModel(List<Chamado> chamados)
    {
        Registros = new List<DetalhesChamadoViewModel>();

        foreach (var c  in chamados)
        {
            var detalhesVM = c.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class CadastrarChamadoViewModel
{

}

public class DetalhesChamadoViewModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataAbertura { get; set; }
    public int TempoDecorrido { get; set; }
    public string NomeEquipamento { get; set; }

    public DetalhesChamadoViewModel(int id, string titulo, string descricao, DateTime dataAbertura,
                                    int tempoDecorrido, string nomeEquipamento)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        DataAbertura = dataAbertura;
        TempoDecorrido = tempoDecorrido;
        NomeEquipamento = nomeEquipamento;
    }

    public override string ToString()
    {
        return $"ID: {Id} - Título: {Titulo} - Descrição {Descricao} - Data de Abertura {DataAbertura:d}"
               + $"Tempo em Aberto: {TempoDecorrido} dias";
    }

}

