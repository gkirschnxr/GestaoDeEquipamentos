using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado : EntidadeBase
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public Equipamento Equipamento { get; set; }
    public DateTime DataAbertura { get; private set; }

    public int TempoDecorrido
    {
        get
        {
            TimeSpan diferencaTempo = DateTime.Now.Subtract(DataAbertura);

            return diferencaTempo.Days;
        }
    }

    public Chamado(string titulo, string descricao, Equipamento equipamento)
    {
        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;
        DataAbertura = DateTime.Now;
    }

    public override void AtualizarRegistro(EntidadeBase registroEditado)
    {
        Chamado chamadoEditado = (Chamado)registroEditado;

        Titulo = chamadoEditado.Titulo;
        Descricao = chamadoEditado.Descricao;
        Equipamento = chamadoEditado.Equipamento;
    }
}
