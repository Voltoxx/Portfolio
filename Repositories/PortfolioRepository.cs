using Portfolio.Data;

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

        //Récupérer un Projet selon sa catégorie

        //Ajouter un Projet 

        //Modifier un Projet

        //Supprimer un Projet

    }
}
