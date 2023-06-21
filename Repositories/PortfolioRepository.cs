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

        public IEnumerable<Projets> GetOneProject(int id)
        {
            return _context.Projet.Where(x => x.Id == id);
        }

        //Ajouter un Projet 

        public void InsertOneProject(Projets projet)
        {
            _context.Projet.Add(projet);
            _context.SaveChanges();
        }

        //Modifier un Projet

        public void UpdateOneProject(Projets id)
        {
            _context.Projet.Entry(id).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Supprimer un Projet

        public void DeleteOneProject(int id)
        {
            _context.Projet.Remove(_context.Projet.First(x => x.Id == id));
            _context.SaveChanges();
        }

    }
}
