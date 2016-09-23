using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ListeVoiture
    {
        //Attribut

        private List<Voiture> liste;

        //Constructeur

        public ListeVoiture()
        {
            liste = new List<Voiture>();
        }

        //Méthodes

        //Ajout d'une voiture à la liste.
        public void Ajout(int id, string marque, string modele, string type, string couleur, int annee, int idMoteur, string carburant, int cylindre, int puissance, int km)
        {
            Voiture v = new Voiture(id, marque, modele, type, couleur, annee, idMoteur, carburant, cylindre, puissance, km);
            liste.Add(v);
        }

        public void Ajout(Voiture v)
        {
            liste.Add(v);
        }

        //Supprimer une voiture de la liste et de la base de données.
        public void Supprimer(int pos, ListeEntretien listeE, ListeConsommation listeC)
        {
            liste[pos].Supprimer(listeE, listeC);
            liste.Remove(liste[pos]);
        }

        //Compte le nombre d'élements de la liste.
        public int Count()
        {
            return liste.Count();
        }

        //Extrait la voiture à une position demandé de la liste.
        public Voiture Extraire(int pos)
        {
            return liste[pos];
        }

        //Charge le contenue de la liste à partir de la base de données.
        public void Charger(string pseudo)
        {
            DataBase.LoadCars(this, pseudo);
        }
    }
}
