using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class PortfolioRepository
    {

        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Les méthodes   

        //Récupérer tout les Projets 

        public IEnumerable<Projets> GetAllProjects()
        {
            return _context.Projet;
        }

        //Récupérer les Projet selon la catégorie

        public IEnumerable<Projets> GetOneCategory(string categorie)
        {
            return _context.Projet.Where(x => x.Categorie.CategorieName == categorie);
        }

        //Récupérer un Projet selon son nom

        public IEnumerable<Projets> GetOneProject(string titre)
        {
            return _context.Projet.Where(x => x.Title == titre);
        }

        //Ajouter un Projet 

        public void InsertOneProject(Projets projet)
        {
            _context.Projet.Add(projet);
            _context.SaveChanges();
        }

        //Modifier un Projet

        public void UpdateOneProject(Projets projet)
        {
            _context.Projet.Entry(projet).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Supprimer un Projet

        public void DeleteOneProject(string title)
        {
            _context.Projet.Remove(_context.Projet.First(x => x.Title == title));
            _context.SaveChanges();
        }

    }
}
