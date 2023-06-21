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

        public IActionResult Profil()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult LegalMentions()
        {
            return View();
        }

        public IActionResult PrivacyPolicies()
        {
            return View();
        }

        public IActionResult CookieManagement()
        {
            return View();
        }

        public IActionResult SiteMap()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly PortfolioRepository _portfolioRepository;

        public PortfolioController(PortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        //Utilsation des méthodes du Repository

        //Récupérer tout les projets

        public IEnumerable<Projets> GetAllProjects()
        {
            return _portfolioRepository.GetAllProjects();
        }

        //Récupérer un projet selon sa catégorie

        public IEnumerable<Projets> GetOneProject(string categorie)
        {
            return _portfolioRepository.GetOneProject(categorie);
        }

        //Ajouter un projet 

        public void InsertOneProject(Projets projet)
        {
            _portfolioRepository.InsertOneProject(projet);
        }

        //Modifier un projet 

        public void UpdateOneProject(Projets projet)
        {
            _portfolioRepository.UpdateOneProject(projet);
        }

        //supprimer un projet 

        public void DeleteOneProject(string title)
        {
            _portfolioRepository.DeleteOneProject(title);
        }
    }
}