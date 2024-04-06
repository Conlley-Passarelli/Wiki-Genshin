using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Wiki_Genshin.Models;

namespace Wiki_Genshin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Personagem> personagens = [];
        using (StreamReader leitor = new("Data\\personagens.json"))
        {
            string dados = leitor.ReadToEnd();
            personagens = JsonSerializer.Deserialize<List<Personagem>>(dados);
        }
        List<Elemento> elementos = [];
        using (StreamReader leitor = new("Data\\elementos.json"))
        {
            string dados = leitor.ReadToEnd();
            elementos = JsonSerializer.Deserialize<List<Elemento>>(dados);
        }
        ViewData["Elementos"] = elementos;
        return View(personagens);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
