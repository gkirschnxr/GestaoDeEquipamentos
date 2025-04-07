namespace GestaoDeEquipamentos.ConsoleApp;

class TelaChamado 
{
    public Chamado[] chamados = new Chamado[100];
    public int contadorChamados;
    public string ApresentarChamados()
    {
        Console.Write("Abrindo menu Gestão de Chamados");

        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(400);
        }

        Console.Clear();
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
        string opcaoChamadoEscolhida = Console.ReadLine()!;

        return opcaoChamadoEscolhida;

    }

    public void NovoChamado()
    {
        Console.Clear();
        Console.WriteLine("----------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("----------------------------");

        Console.WriteLine("Abrindo novo chamado...");
        Console.WriteLine("----------------------------\n");

        Console.Write("Digite o motivo do chamado: ");
        string motivo = Console.ReadLine()!;

        Console.Write("Dê uma breve descrição sobre o chamado: ");
        string descricao = Console.ReadLine()!;

        Console.WriteLine("IDs de equipamentos disponíveis:");
        int[] idsEquipamentos = telaEquipamento.ObterIdsEquipamentos();
        foreach (int id in idsEquipamentos)
        {
            Console.WriteLine($"ID: {id}");
        }

        Console.Write("Digite o ID do equipamento defeituoso: ");
        int idEquipamento = GeradorID.GerarIdEquipamento();
        Console.ReadLine();

        DateTime dataChamado = DateTime.Now;

        Chamado novoChamado = new Chamado(motivo, descricao, idEquipamento, dataChamado);

        chamados[contadorChamados] = novoChamado;
        contadorChamados++;

        Console.WriteLine("Chamado cadastrado com sucesso!");
    }

    internal void EditarChamado()
    {
        throw new NotImplementedException();
    }

    internal void ExcluirChamado()
    {
        throw new NotImplementedException();
    }

    internal void VisualizarChamado()
    {
        throw new NotImplementedException();
    }
}
