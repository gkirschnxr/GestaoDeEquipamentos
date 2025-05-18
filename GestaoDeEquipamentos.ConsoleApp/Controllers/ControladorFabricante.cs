using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("fabricantes")]
public class ControladorFabricante : Controller
{
    [HttpGet("cadastrar")]
    public Task ExibirFormularioCadastrarFabricante()
    {
        string conteudo = System.IO.File.ReadAllText("ModuloFabricante/Html/Cadastrar.html");

        return HttpContext.Response.WriteAsync(conteudo);
    }

    [HttpPost("cadastrar")]
    public Task CadastrarFabricante()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string nome = HttpContext.Request.Form["nome"].ToString();
        string email = HttpContext.Request.Form["email"].ToString();
        string telefone = HttpContext.Request.Form["telefone"].ToString();

        Fabricante novoFabricante = new Fabricante(nome, email, telefone);

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro \"{novoFabricante.Nome}\" foi cadastrado com sucesso.");

        string conteudoString = stringBuilder.ToString();

        return HttpContext.Response.WriteAsync(conteudoString);
    }

    [HttpGet("editar/{id:int}")]
    public Task ExibirFormularioEditarFabricante()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        int id = Convert.ToInt32(HttpContext.GetRouteValue("id"));

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        string conteudo = System.IO.File.ReadAllText("ModuloFabricante/Html/Editar.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#id#", id.ToString());
        sb.Replace("#nome#", fabricanteSelecionado.Nome);
        sb.Replace("#email#", fabricanteSelecionado.Email);
        sb.Replace("#telefone#", fabricanteSelecionado.Telefone);

        string conteudoString = sb.ToString();

        return HttpContext.Response.WriteAsync(conteudoString);
    }

    [HttpPost("editar/{id:int}")]
    public Task EditarFabricante()
    {
        int id = Convert.ToInt32(HttpContext.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string nome = HttpContext.Request.Form["nome"].ToString();
        string email = HttpContext.Request.Form["email"].ToString();
        string telefone = HttpContext.Request.Form["telefone"].ToString();

        Fabricante fabricanteAtualizado = new Fabricante(nome, email, telefone);

        repositorioFabricante.EditarRegistro(id, fabricanteAtualizado);

        string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro \"{fabricanteAtualizado.Nome}\" foi editado com sucesso.");

        string conteudoString = stringBuilder.ToString();

        return HttpContext.Response.WriteAsync(conteudoString);
    }

    [HttpGet("excluir/{id:int}")]
    public Task ExibirFormularioExcluirFabricante()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        int id = Convert.ToInt32(HttpContext.GetRouteValue("id"));

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        string conteudo = System.IO.File.ReadAllText("ModuloFabricante/Html/Excluir.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#id#", id.ToString());
        sb.Replace("#fabricante#", fabricanteSelecionado.Nome);

        string conteudoString = sb.ToString();

        return HttpContext.Response.WriteAsync(conteudoString);
    }

    [HttpPost("excluir/{id:int}")]
    public Task ExcluirFabricante()
    {
        int id = Convert.ToInt32(HttpContext.GetRouteValue("id"));

        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro foi excluído com sucesso.");

        string conteudoString = stringBuilder.ToString();

        return HttpContext.Response.WriteAsync(conteudoString);
    }

    [HttpGet("visualizar")]
    public IActionResult VisualizarFabricantes()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        string conteudo = System.IO.File.ReadAllText("ModuloFabricante/Html/Visualizar.html");

        StringBuilder sb = new StringBuilder(conteudo);

        foreach (Fabricante f in repositorioFabricante.SelecionarRegistros())
        {
            string itemLista = $"<li>{f.ToString()}</li> / <a href='/fabricantes/editar/{f.Id}'>Editar</a> / <a href='/fabricantes/excluir/{f.Id}'>Excluir</a> #fabricante#";

            sb.Replace("#fabricante#", itemLista);
        }

        sb.Replace("#fabricante#", "");

        string conteudoString = sb.ToString();

        return Content(conteudoString, "text/html");
    }

}