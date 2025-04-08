using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
public class Fabricante
{
    public int Id;
    public string NomeFabricante;
    public string EmailFabricante;
    public string TelefoneFabricante;
    public Equipamento Equipamento;

    public Fabricante(string nomeFabricante, string emailFabricante, string telefoneFabricante, Equipamento equipamento)
    {
        NomeFabricante = nomeFabricante;
        EmailFabricante = emailFabricante;
        TelefoneFabricante = telefoneFabricante;
        Equipamento = equipamento;
    }
}
