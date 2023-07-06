using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Context;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class PortfolioRepository
    {

        private readonly AppDbContext _context;

        public PortfolioRepository(AppDbContext context)
        {
            this._context = context;
        }

        //Les méthodes   

        //Récupérer tout les Projets 

        public IEnumerable<Projets> GetAllProjects()
        {
            return _context.Projets;
        }

        //Récupérer les Projet selon la catégorie

        public IEnumerable<Projets> GetOneCategory(string categorie)
        {
            return _context.Projets.Where(x => x.Categorie == categorie);
        }

        //Récupérer un Projet selon son nom

        public Projets GetOneProject(int id)
        {
            return _context.Projets.First(x => x.Id == id);
        }

        //Ajouter un Projet 

        public void InsertOneProject(Projets projet)
        {
            _context.Projets.Add(projet);
            _context.SaveChanges();
        }

        //Modifier un Projet

        public void UpdateOneProject(Projets projet)
        {
	        var change = _context.Projets.First(x => x.Id == projet.Id);
	        change.Title = projet.Title;
            change.Description = projet.Description;
            change.ImagePrincipale = projet.ImagePrincipale;
            change.Categorie = projet.Categorie;
            change.FirstImage = projet.FirstImage;
            change.SecondImage = projet.SecondImage;
            change.ThirdImage = projet.ThirdImage;
			_context.Projets.Update(change);
	        _context.SaveChanges();
        }

        //Supprimer un Projet

        public void DeleteOneProject(int id)
        {
            _context.Projets.Remove(_context.Projets.First(x => x.Id == id));
            _context.SaveChanges();
        }


    }
}
