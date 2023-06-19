using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        //private readonly ILogger<PortfolioController> _logger;

        //public PortfolioController(ILogger<PortfolioController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        private readonly PortfolioRepository _portfolioRepository;

        public PortfolioController(PortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        //Utilsation des méthodes du Repository

        //Récupérer tout les projets

        //Récupérer un projet selon sa catégorie

        //Ajouter un projet 

        //Modifier un projet 

        //supprimer un projet 
    }
}