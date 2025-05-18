using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("/")]
public class ControladorPaginaInicial : Controller
{
    public IActionResult PaginaInicial()
    {
        string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/PaginaInicial.html");

        return Content(conteudo, "text/html");
    }
}
