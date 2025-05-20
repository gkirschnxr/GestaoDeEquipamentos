using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Extensions;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("fabricantes")]
public class ControladorFabricante : Controller
{
    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarFabricanteViewModel();

        return View(cadastrarVM);
    }


    [HttpPost("cadastrar")]
    public IActionResult CadastrarFabricante(CadastrarFabricanteViewModel cadastrarVM)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var novoFabricante = cadastrarVM.ParaEntidade();

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        var notificacaoVM = new NotificacaoViewModel(
             "Fabricante Cadastrado!",
            $"O registro \"{novoFabricante.Nome}\" foi cadastrado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        var editarVM = new EditarFabricanteViewModel(
            id,
            fabricanteSelecionado.Nome,
            fabricanteSelecionado.Email,
            fabricanteSelecionado.Telefone);

        return View(editarVM);
    }


    [HttpPost("editar/{id:int}")]
    public IActionResult EditarFabricante([FromRoute] int id, EditarFabricanteViewModel editarVM)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var fabricanteAtualizado = new Fabricante(editarVM.Nome, editarVM.Email, editarVM.Telefone);

        repositorioFabricante.EditarRegistro(id, fabricanteAtualizado);

        var notificacaoVM = new NotificacaoViewModel(
             "Fabricante Editado!",
            $"O registro \"{fabricanteAtualizado.Nome}\" foi editado com sucesso!");

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirFabricanteViewModel(
            fabricanteSelecionado.Id,
            fabricanteSelecionado.Nome);

        return View(excluirVM);
    }


    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirFabricante([FromRoute] int id)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
            $"Fabricante excluído!",
            $"O registro \"{id}\" foi excluído com sucesso."
            );

        return View("Notificacao", notificacaoVM);
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var contextoDados = new ContextoDados(true);
        var repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        var fabricantes = repositorioFabricante.SelecionarRegistros();

        var visualizarVM = new VisualizarFabricantesViewModel(fabricantes);

        return View(visualizarVM);
    }

}