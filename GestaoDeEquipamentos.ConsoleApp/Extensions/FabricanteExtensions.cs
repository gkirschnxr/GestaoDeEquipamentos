using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Extensions;

public static class FabricanteExtensions
{
    public static Fabricante ParaEntidade(this FormularioFabricanteViewModel formularioVM)
    {
        return new Fabricante(formularioVM.Nome, formularioVM.Email, formularioVM.Telefone);
    }

    public static DetalhesFabricantesViewModel ParaDetalhesVM(this Fabricante f)
    {
        return new DetalhesFabricantesViewModel(
                f.Id,
                f.Nome,
                f.Email,
                f.Telefone);
    }
}
