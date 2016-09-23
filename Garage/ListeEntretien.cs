using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ListeEntretien
    {
        //Attribut

        private List<EntretienV> liste;

        //Constructeur

        public ListeEntretien()
        {
            liste = new List<EntretienV>();
        }

        //Méthodes

        //Ajout d'un entretien à la liste.
        public void Ajout(int id,DateTime date, int km, string info)
        {
            EntretienV ent = new EntretienV(id, date, km, info);
            this.Ajout(ent);
        }

        public void Ajout(EntretienV ent)
        {
            liste.Add(ent);
        }

        //Supprimer tous les entretiens de la liste et de la base de données.
        public void Supprimer()
        {
            int i;
            for(i=0; i< this.Count(); i++)
            {
                liste[i].Supprimer();
            }
        }

        //Compte le nombre d'élements de la liste.
        public int Count()
        {
            return liste.Count();
        }

        //Extrait l'entretien à une position demandé de la liste.
        public EntretienV Extraire(int pos)
        {
            return liste[pos];
        }

        //Charge le contenue de la liste à partir de la base de données.
        public void Charger(int idMoteur)
        {
            DataBase.LoadEntretien(this, idMoteur);
        }
    }
}
