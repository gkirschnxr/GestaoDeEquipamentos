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

        app.MapGet("/fabricantes/cadastrar", ExibirFormularioCadastrarFabricante);
        app.MapPost("/fabricantes/cadastrar", CadastrarFabricante);

        app.MapGet("/fabricantes/editar/{id:int}", ExibirFormularioEditarFabricante);
        app.MapPost("/fabricantes/editar/{id:int}", EditarFabricante);

        app.MapGet("/fabricantes/excluir/{id:int}", ExibirFormularioExcluirFabricante);
        app.MapPost("/fabricantes/excluir/{id:int}", ExcluirFabricante);

        app.MapGet("/fabricantes/visualizar", VisualizarFabricantes);

        app.Run();
    }

    static Task PaginaInicial(HttpContext context)
    {
        string conteudo = File.ReadAllText("Compartilhado/Html/PaginaInicial.html");

        return context.Response.WriteAsync(conteudo);
    }

    static Task ExibirFormularioCadastrarFabricante(HttpContext context)
    {
        string conteudo = File.ReadAllText("ModuloFabricante/Html/Cadastrar.html");

        return context.Response.WriteAsync(conteudo);
    }

    static Task CadastrarFabricante(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string nome = context.Request.Form["nome"].ToString();
        string email = context.Request.Form["email"].ToString();
        string telefone = context.Request.Form["telefone"].ToString();

        Fabricante novoFabricante = new Fabricante(nome, email, telefone);

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro \"{novoFabricante.Nome}\" foi cadastrado com sucesso.");

        string conteudoString = stringBuilder.ToString();

        return context.Response.WriteAsync(conteudoString);
    }

    static Task ExibirFormularioEditarFabricante(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        int id = Convert.ToInt32(context.GetRouteValue("id"));

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        string conteudo = File.ReadAllText("ModuloFabricante/Html/Editar.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#id#", id.ToString());
        sb.Replace("#nome#", fabricanteSelecionado.Nome);
        sb.Replace("#email#", fabricanteSelecionado.Email);
        sb.Replace("#telefone#", fabricanteSelecionado.Telefone);

        string conteudoString = sb.ToString();

        return context.Response.WriteAsync(conteudoString);
    }

    static Task EditarFabricante(HttpContext context) 
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string nome = context.Request.Form["nome"].ToString();
        string email = context.Request.Form["email"].ToString();
        string telefone = context.Request.Form["telefone"].ToString();

        Fabricante fabricanteAtualizado = new Fabricante(nome, email, telefone);

        repositorioFabricante.EditarRegistro(id, fabricanteAtualizado);

        string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro \"{fabricanteAtualizado.Nome}\" foi editado com sucesso.");

        string conteudoString = stringBuilder.ToString();

        return context.Response.WriteAsync(conteudoString);
    }

    static Task ExibirFormularioExcluirFabricante(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        int id = Convert.ToInt32(context.GetRouteValue("id"));

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        string conteudo = File.ReadAllText("ModuloFabricante/Html/Excluir.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#id#", id.ToString());
        sb.Replace("#fabricante#", fabricanteSelecionado.Nome);

        string conteudoString = sb.ToString();

        return context.Response.WriteAsync(conteudoString);
    }

    static Task ExcluirFabricante(HttpContext context)
    {
        int id = Convert.ToInt32(context.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro foi excluído com sucesso.");

        string conteudoString = stringBuilder.ToString();

        return context.Response.WriteAsync(conteudoString);
    }

    static Task VisualizarFabricantes(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string conteudo = File.ReadAllText("ModuloFabricante/Html/Visualizar.html");

        StringBuilder sb = new StringBuilder(conteudo);

        foreach (Fabricante f in repositorioFabricante.SelecionarRegistros())
        {
            string itemLista = $"<li>{f.ToString()}</li> / <a href='/fabricantes/editar/{f.Id}'>Editar</a> / <a href='/fabricantes/excluir/{f.Id}'>Excluir</a> #fabricante#";

            sb.Replace("#fabricante#", itemLista);
        }

        sb.Replace("#fabricante#", "");

        string conteudoString = sb.ToString();

        return context.Response.WriteAsync(conteudoString);
    }
}
