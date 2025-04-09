using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioFabricante)
    {
        this.repositorioFabricante = repositorioFabricante;
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Controle de Fabricantes");
        Console.WriteLine("--------------------------------------------\n");
    }
    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1 - Cadastrar Fabricante");
        Console.WriteLine("2 - Editar Fabricante");
        Console.WriteLine("3 - Excluir Fabricante");
        Console.WriteLine("4 - Visualizar Fabricantes\n");

        Console.WriteLine("S - Voltar\n");

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Console.ReadLine()![0];

        return operacaoEscolhida;
    }
    public void CadastrarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Fabricante...");
        Console.WriteLine("--------------------------------------------");

        Fabricante novoFabricante = ObterDadosFabricante();

        string erros = novoFabricante.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            CadastrarFabricante();

            return;
        }

        repositorioFabricante.CadastrarFabricante(novoFabricante);

        Notificador.ExibirMensagem("O fabricante foi cadastrado com sucesso!", ConsoleColor.Green);
    }
    public void EditarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Fabricante...");
        Console.WriteLine("--------------------------------------------");

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do fabricante que deseja editar: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Fabricante fabricanteEditado = ObterDadosFabricante();

        bool conseguiuEditar = repositorioFabricante.EditarFabricante(idFabricante, fabricanteEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição do fabricante...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O fabricante foi editado com sucesso!", ConsoleColor.Green);
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
            Notificador.ExibirMensagem("Houve um erro durante a exclusão do fabricante...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O fabricante foi excluído com sucesso!", ConsoleColor.Green);
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
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
            "Id", "Nome", "Email", "Telefone", "Qtd. Equipamentos"
        );

        Fabricante[] fabricantesCadastrados = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
            Fabricante f = fabricantesCadastrados[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15}",
                f.Id, f.NomeFabricante, f.EmailFabricante, f.TelefoneFabricante, f.ObterQuantidadeEquipamentos()
            );
        }
    }
    public Fabricante ObterDadosFabricante()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o e-mail do fabricante: ");
        string email = Console.ReadLine()!;

        Console.Write("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine()!;

        Fabricante novoFabricante = new Fabricante(nome, email, telefone);

        return novoFabricante;
    }
}
