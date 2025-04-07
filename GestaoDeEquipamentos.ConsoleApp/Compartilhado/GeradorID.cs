namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public static class GeradorID
{
    public static int IdEquipamentos = 0;
    public static int IdChamados = 0;

    public static int GerarIdEquipamento()
    {
        IdEquipamentos++;

        return IdEquipamentos;
    }
    public static int GerarIdChamado()
    {
        IdChamados++;

        return IdChamados;
    }
}
