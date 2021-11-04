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
            List<Joueur> list = new List<Joueur>();
            foreach (var data in datas)
                if (data.Nom.ToLower().Contains(value.ToLower()))
                    list.Add(data);
            return list;
        }
    }
}


