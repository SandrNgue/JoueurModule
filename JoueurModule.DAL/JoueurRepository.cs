using JoueurModule.BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JoueurModule.DAL
{
    public class JoueurRepository : BaseRepository<Joueur>
    {
        public JoueurRepository()
        {
        }

        public List<Joueur> FindByName(string value)
        {
            return FindAll(x => x.Nom.ToLower().Contains(value.ToLower()));
        }
    }
}


