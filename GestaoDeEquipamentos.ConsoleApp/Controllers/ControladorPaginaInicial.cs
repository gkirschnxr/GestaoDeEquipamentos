using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("/")]
public class ControladorPaginaInicial : Controller
{
    public IActionResult PaginaInicial()
    {
        return View("PaginaInicial");
    }
}
