using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("chamados")]
public class ControladorChamado : Controller
{
    private ContextoDados contextoDados;
    private IRepositorioChamado repositorioChamado;
    private IRepositorioEquipamento repositorioEquipamento;

    public ControladorChamado()
    {
        contextoDados = new ContextoDados(true);
        repositorioChamado = new RepositorioChamadoEmArquivo(contextoDados);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);
    }


    [HttpGet("cadastrar")]
    public IActionResult Cadastrar() 
    {
        var equipamento = repositorioEquipamento.SelecionarRegistros();

        var cadastrarVM = new CadastrarChamadoViewModel(equipamento);

        return View(cadastrarVM); 
    
    }


    [HttpPost("cadastrar")]
    public IActionResult Cadastrar() 
    { 
        return View();
    
    }


    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        var chamados = repositorioChamado.SelecionarRegistros();

        var visualizarVM = new VisualizarChamadoViewModel(chamados);

        return View(visualizarVM);
    }
}
