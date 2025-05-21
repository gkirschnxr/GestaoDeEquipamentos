using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

namespace GestaoDeEquipamentos.ConsoleApp.Extensions;

public static class ChamadoExtensions
{
    public static DetalhesChamadoViewModel ParaDetalhesVM(this Chamado chamado)
    {
        return new DetalhesChamadoViewModel(
            chamado.Id,
            chamado.Titulo,
            chamado.Descricao,
            chamado.DataAbertura,
            chamado.TempoDecorrido,
            chamado.Equipamento.Nome);
    }
}
