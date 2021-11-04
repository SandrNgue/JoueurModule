using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoueurModule.BO
{
    public class Joueur
    {
        public string Email { get; set; }
        public string Nom { get; set; }
        public double Score { get; set; }

        public Joueur(string email, string nom)
        {
            Email = email;
            Nom = nom;
            Score = 0;
        }

        public override bool Equals(object obj)
        {
            return obj is Joueur joueur &&
                   Email == joueur.Email;
        }

        public override int GetHashCode()
        {
            return -506688385 + EqualityComparer<string>.Default.GetHashCode(Email);
        }
    }
}
