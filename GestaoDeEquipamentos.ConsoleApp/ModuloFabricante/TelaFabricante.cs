using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
public class TelaFabricante
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioFabricante, RepositorioEquipamento repositorioEquipamento)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        this.repositorioFabricante = repositorioFabricante;
    }
    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1 - Cadastrar Fabricante");
        Console.WriteLine("2 - Editar Fabricante");
        Console.WriteLine("3 - Excluir Fabricante");
        Console.WriteLine("4 - Visualizar Fabricantes");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!);

        return operacaoEscolhida;
    }
    public void CadastrarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Fabricante...");
        Console.WriteLine("--------------------------------------------");

        Fabricante novoFabricante = ObterDadosFabricante();

        repositorioFabricante.CadastrarFabricante(novoFabricante);

        Console.WriteLine();
        Console.WriteLine("O fabricante foi cadastrado com sucesso!");
    }
    public void EditarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Fabricante...");
        Console.WriteLine("--------------------------------------------");

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do fabricante que deseja editar: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Fabricante novoFabricante = ObterDadosFabricante();

        bool conseguiuEditar = repositorioFabricante.EditarFabricante(idFabricante, novoFabricante);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O fabricante foi editado com sucesso!");
    }
    public void ExcluirFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Fabricante...");
        Console.WriteLine("--------------------------------------------");

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do fabricante que deseja excluir: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idFabricante);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O fabricante foi excluído com sucesso!");
    }
    public void VisualizarFabricantes(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ExibirCabecalho();

            Console.WriteLine("Visualizando Fabricantes...");
            Console.WriteLine("--------------------------------------------");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -12} | {2, -15} | {3, -30}",
            "Id", "Nome", "E-mail", "Telefone"
        );

        Fabricante[] fabricantesCadastrados = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
            Fabricante f = fabricantesCadastrados[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15}",
                f.Id, f.NomeFabricante, f.EmailFabricante, f.TelefoneFabricante
            );
        }
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Controle de Fabricantes");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();
    }
    public Fabricante ObterDadosFabricante()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine()!.Trim();

        Console.Write("Digite o e-mail do fabricante: ");
        string email = Console.ReadLine()!.Trim();

        Console.Write("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine()!.Trim();

        Console.Write("Digite o ID do equipamento associado: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);

        Fabricante novoFabricante = new Fabricante(nome, email, telefone, equipamentoSelecionado);

        return novoFabricante;
    }
}
