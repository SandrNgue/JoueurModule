using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoueurModule.BO;
using JoueurModule.DAL;

namespace JoueurModule.BLL
{
    public class JoueurManager
    {
        private JoueurRepository joueurRepository;
        public JoueurManager()
        {
            joueurRepository = new JoueurRepository();
        }
        public void Add(Joueur joueur)
        {
            joueurRepository.Add(joueur);
        }
        public void Delete(Joueur joueur)
        {
            joueurRepository.Delete(joueur);
        }
      
        public void Update(Joueur oldJoueur, Joueur joueur)
        {
            joueurRepository.Set(oldJoueur, joueur);
        }

        public Joueur Authenticate(string Email, string Nom)
        {
            return joueurRepository.Find(x => x.Nom == Nom && x.Email == Email);
/*
            var joueurs = joueurRepository.FindByName(Nom);
            foreach (var joueur in joueurs)
            {
                if (joueur.Nom == Email && joueur.Nom == Nom)
                    return joueur;
            }
            
            return null;
*/
        }
    }
}
