namespace GestaoDeEquipamentos.ConsoleApp;

class TelaChamado ()
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

        //Console.Write("Digite o ID do equipamento defeituoso: ");
        //int idEquipamento = GeradorID.GerarIdEquipamento();
        //Console.ReadLine();

        DateTime dataChamado = DateTime.Now;

        Chamado novoChamado = new Chamado(motivo, descricao, idEquipamento, dataChamado);

        chamados[contadorChamados] = novoChamado;
        contadorChamados++;

        Console.WriteLine("Chamado cadastrado com sucesso!");
    }

    public void EditarChamado()
    {
        Console.Clear();
        Console.WriteLine("----------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("----------------------------");

        Console.WriteLine("Editando Chamados...");
        Console.WriteLine("----------------------------");

        VisualizarChamado(false);


        Console.Write("Digite o ID do chamado que deseja editar: ");
        int IdSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Console.Write("Digite o motivo do chamado: ");
        string motivo = Console.ReadLine()!;

        Console.Write("Dê uma breve descrição sobre o chamado: ");
        string descricao = Console.ReadLine()!;

        //Console.Write("Digite o ID do equipamento defeituoso: ");
        //int idEquipamento = GeradorID.GerarIdEquipamento();
        //Console.ReadLine();

        Console.Write("Digite a data de fabricação (dd/MM/yyyy): ");
        DateTime dataChamado = Convert.ToDateTime(Console.ReadLine());

        Chamado novoChamado = new Chamado(motivo, descricao, idEquipamento, dataChamado);

        bool conseguiuEditar = false;

        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] == null) continue;

            // sobescrever equipamento
            else if (chamados[i].ID == IdSelecionado)
            {
                chamados[i].Motivo = novoChamado.Motivo;
                chamados[i].Descricao = novoChamado.Descricao;
                chamados[i].IdEquipamento = novoChamado.IdEquipamento;
                chamados[i].DataChamado = novoChamado.DataChamado;

                conseguiuEditar = true;
            }
        }

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição do registro!");
            return;
        }

        Console.WriteLine("O registro foi editado com sucesso!");
    }

    internal void ExcluirChamado()
    {
        throw new NotImplementedException();
    }

    public void VisualizarChamado(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Visualizando Chamados...");
            Console.WriteLine("----------------------------");
        }

        Console.WriteLine();

        // Criando tabelas no console:
        Console.WriteLine(
            "{0, -10} | {1, -15} |{2, -11} |{3, -15} |{4, -17}",
            "ID Chamado", "Motivo", "Núm. Chamado", "Descrição", "Data de Abertura"
            );

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado c = chamados[i];

            if (c == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} |{2, -11} |{3, -15} |{4, -17} |{5, -10}",
                c.ID, c.Motivo, c.ObterNumeroSerie(), c.Descricao, c.DataChamado.ToShortDateString()
                );
        }
    }
}
