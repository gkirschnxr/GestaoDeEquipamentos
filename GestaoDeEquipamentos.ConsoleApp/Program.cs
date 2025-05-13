using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.Util;
using System.Text;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // criar server web
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        WebApplication app = builder.Build();

        app.MapGet("/", PaginaInicial);

        app.MapGet("/fabricantes/visualizar", VisualizarFabricantes);

        app.Run();
    }

    static Task PaginaInicial(HttpContext context)
    {
        string conteudo = File.ReadAllText("Html/PaginaInicial.html");

        return context.Response.WriteAsync(conteudo);
    }

    static Task VisualizarFabricantes(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados();
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string conteudo = File.ReadAllText("ModuloFabricante/Html/Visualizar.html");

        StringBuilder sb = new StringBuilder(conteudo);

        foreach (Fabricante f in repositorioFabricante.SelecionarRegistros())
        {
            string itemLista = $"<li>{f.ToString()}</li> #fabricante#";

            sb.Replace("#fabricante#", itemLista);
        }

        sb.Replace("#fabricante#", "");

        string conteudoString = sb.ToString();

        return context.Response.WriteAsync(conteudoString);
    }
}
