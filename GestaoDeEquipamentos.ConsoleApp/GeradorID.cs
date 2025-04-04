namespace GestaoDeEquipamentos.ConsoleApp;

public static class GeradorID
{
    public static int IdEquipamentos = 0;

    public static int GerarIdEquipamento()
    {
        IdEquipamentos++;

        return IdEquipamentos;
    }
}
