namespace GestaoDeEquipamentos.ConsoleApp;

class TelaChamado
{
    public string AbrirChamado()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(); // ADICIONAR TIMER PARA ABRIR O MENU DE CHAMADOS
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("----------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Escolha a operação desejada: ");
        Console.WriteLine("1 - Cadastro de Chamados");
        Console.WriteLine("2 - Edição de Chamados");
        Console.WriteLine("3 - Exclusão de Chamados");
        Console.WriteLine("4 - Visualização de Chamados");
        Console.WriteLine("----------------------------");

        Console.Write("Digite uma opção válida: ");
        string opcaoEscolhida = Console.ReadLine()!;

        return opcaoEscolhida;

    }
}
