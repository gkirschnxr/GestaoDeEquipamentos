using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.Extensions;

public static class EquipamentosExtensions
{
    public static DetalhesEquipamentoViewModel ParaDetalhesVM(this Equipamento equipamento)
    {
        return new DetalhesEquipamentoViewModel(
            equipamento.Id,
            equipamento.Nome,
            equipamento.PrecoAquisicao,
            equipamento.DataFabricacao,
            equipamento.Fabricante.Nome);
    }
}
