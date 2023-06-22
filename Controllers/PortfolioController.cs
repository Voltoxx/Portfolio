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
            return View(GetAllProjects());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("Update/{id}")]
        public IActionResult Update(int id)
        {
	        Projets model = GetOneProject(id);
            return View(model);
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

		[HttpGet("GetAllProjects")]
		public IEnumerable<Projets> GetAllProjects()
        {
            return _portfolioRepository.GetAllProjects();
        }

		//Récupérer un projet selon son nom

		[HttpGet("GetOneProject")]
		public Projets GetOneProject(int id)
        {
            return _portfolioRepository.GetOneProject(id);
        }

		//Récupérer plusieurs projets selon leur catégorie

		[HttpGet("GetOneCategory")]
		public IEnumerable<Projets> GetOneCategory(string categorie)
        {
            return _portfolioRepository.GetOneCategory(categorie);
        }

		//Ajouter un projet 

		[HttpPost("InsertOneProject")]
		public ActionResult InsertOneProject(Projets projet)
        {
            _portfolioRepository.InsertOneProject(projet);
            return RedirectToAction(nameof(Projects));
		}

		[HttpPost("UpdateOneProject")]
		//Modifier un projet 

		public ActionResult UpdateOneProject(Projets projet)
        {
            _portfolioRepository.UpdateOneProject(projet);
            return RedirectToAction(nameof(Projects));
        }

		//supprimer un projet 

		[HttpGet("DeleteOneProject")]
		public ActionResult DeleteOneProject(int id)
        {
            _portfolioRepository.DeleteOneProject(id);
            return RedirectToAction(nameof(Projects));
        }
    }
}