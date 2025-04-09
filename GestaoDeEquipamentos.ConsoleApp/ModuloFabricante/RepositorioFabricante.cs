using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
public class RepositorioFabricante
{
    public Fabricante[] fabricantes = new Fabricante[100];
    public int contadorFabricantes = 0;

    public void CadastrarFabricante(Fabricante novoFabricante)
    {
        novoFabricante.Id = GeradorIds.GerarIdFabricante();

        fabricantes[contadorFabricantes++] = novoFabricante;
    }

    public bool EditarFabricante(int idFabricante, Fabricante fabricanteEditado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null) continue;

            else if (fabricantes[i].Id == idFabricante)
            {
                fabricantes[i].NomeFabricante = fabricanteEditado.NomeFabricante;
                fabricantes[i].EmailFabricante = fabricanteEditado.EmailFabricante;
                fabricantes[i].TelefoneFabricante = fabricanteEditado.TelefoneFabricante;

                return true;
            }
        }

        return false;
    }

    public bool ExcluirFabricante(int idFabricante)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null) continue;

            else if (fabricantes[i].Id == idFabricante)
            {
                fabricantes[i] = null!;

                return true;
            }
        }

        return false;
    }

    public Fabricante[] SelecionarFabricantes()
    {
        return fabricantes;
    }

    public Fabricante SelecionarFabricantePorId(int idFabricante)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = fabricantes[i];

            if (f == null)
                continue;

            else if (f.Id == idFabricante)
                return f;
        }

        return null!;
    }
}
