using System.Diagnostics;
using System.Runtime.CompilerServices;
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
        List<Personagem> personagens = GetPersonagens();
        List<Elemento> elementos = GetElementos();
        ViewData["Elementos"] = elementos;
        return View(personagens);
    }

    public IActionResult Details(int id)
    {
        List<Personagem> personagens = GetPersonagens();
        List<Elemento> elementos = GetElementos();
        DetailsVM details = new() {
            Elementos = elementos,
            Atual = personagens.FirstOrDefault(p => p.Numero == id),
            Anterior = personagens.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = personagens.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
            return View(details);
    }
        
        private List<Personagem> GetPersonagens()
        {
            using (StreamReader leitor = new("Data\\personagens.json"))
            {
                string dados = leitor.ReadToEnd();
                return JsonSerializer.Deserialize<List<Personagem>>(dados);
            }
        }

        private List<Elemento> GetElementos()
        {
            using (StreamReader leitor = new("Data\\elementos.json"))
            {
                string dados = leitor.ReadToEnd();
                return JsonSerializer.Deserialize<List<Elemento>>(dados);
            }
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
