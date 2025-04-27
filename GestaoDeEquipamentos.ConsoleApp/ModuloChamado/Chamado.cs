using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado
{
    public int Id { get; set; }
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
}
