using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ListeConsommation
    {
        //Attribut

        private List<ConsommationV> liste;

        //Constructeur

        public ListeConsommation()
        {
            liste = new List<ConsommationV>();
        }

        //Méthodes

        //Ajout d'une consommation à la liste.
        public void Ajout(int id, float litre, int km, float cout)
        {
            ConsommationV conso = new ConsommationV(id, litre, cout, km);
            this.Ajout(conso);
        }

        public void Ajout(ConsommationV conso)
        {
            liste.Add(conso);
        }

        //Supprimer tous les entretiens de la liste et de la base de données.
        public void Supprimer()
        {
            int i;
            for (i = 0; i < this.Count(); i++)
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
        public ConsommationV Extraire(int pos)
        {
            return liste[pos];
        }

        //Charge le contenue de la liste à partir de la base de données.
        public void Charger(int idMoteur)
        {
            DataBase.LoadConsommation(this, idMoteur);
        }

        //Calcul la moyenne de toute les consommation litre/100km.
        public float CalculerMoyenneLitre()
        {
            int i;
            float res = 0;
            for (i = 0; i < Count(); i++)
            {
                res += liste[i].CalculerConsommationLitre();
            }
            return res / Count();
        }

        //Calcul la moyenne de toute les consommation cout/100km.
        public float CalculerMoyenneCout()
        {
            int i;
            float res = 0;
            for (i = 0; i < Count(); i++)
            {
                res += liste[i].CalculerConsommationCout();
            }
            return res / Count();
        }
    }
}
