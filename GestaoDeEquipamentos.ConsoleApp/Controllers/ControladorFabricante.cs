﻿using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
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
    public IActionResult ExibirFormularioCadastrarFabricante()
    {
        CadastrarFabricanteViewModel cadastrarVM = new CadastrarFabricanteViewModel();

        return View("Cadastrar");
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarFabricante(CadastrarFabricanteViewModel cadastrarVM)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante novoFabricante = new Fabricante(cadastrarVM.Nome, cadastrarVM.Email, cadastrarVM.Telefone);

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        ViewBag.Mensagem = $"O registro \"{novoFabricante.Nome}\" foi cadastrado com sucesso.";

        return View("Notificacao");
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult ExibirFormularioEditarFabricante([FromRoute] int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        EditarFabricanteViewModel editarVM = new EditarFabricanteViewModel(
            id,
            fabricanteSelecionado.Nome,
            fabricanteSelecionado.Email,
            fabricanteSelecionado.Telefone);

        return View("Editar", fabricanteSelecionado);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult EditarFabricante([FromRoute] int id, EditarFabricanteViewModel editarVM)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricanteAtualizado = new Fabricante(editarVM.Nome, editarVM.Email, editarVM.Telefone);

        repositorioFabricante.EditarRegistro(id, fabricanteAtualizado);

        ViewBag.Mensagem = $"O registro \"{fabricanteAtualizado.Nome}\" foi editado com sucesso.";

        return View("Notificacao");
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult ExibirFormularioExcluirFabricante([FromRoute] int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        ExcluirFabricanteViewModel excluirVM = new ExcluirFabricanteViewModel(
            fabricanteSelecionado.Id,
            fabricanteSelecionado.Nome);

        return View("Excluir", excluirVM);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirFabricante([FromRoute] int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        ViewBag.Mensagem = $"O registro foi excluído com sucesso.";

        return View("Notificacao");
    }

    [HttpGet("visualizar")]
    public IActionResult VisualizarFabricantes()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);

        List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

        VisualizarFabricantesViewModel visualizarVM = new VisualizarFabricantesViewModel(fabricantes);

        return View("Visualizar", visualizarVM);
    }

}