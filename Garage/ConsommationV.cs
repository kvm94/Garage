using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ConsommationV
    {
        //Attributs

        public int      id { get; set; }
        public float   litre { get; set; }
        public float   cout { get; set; }
        public int      km { get; set; }

        //Constructeurs

        public ConsommationV()
        {

        }

        public ConsommationV(int id, float litre, float cout, int km)
        {
            this.id = id;
            this.litre = litre;
            this.cout = cout;
            this.km = km;
        }

        //Méthodes

        //Ajoute la consommation à la base de données.
        public void Ajout(int idMoteur)
        {
            DataBase.AddConsommation(this, idMoteur);
        }

        //Supprime la consommation de la base de données.
        public void Supprimer()
        {
            DataBase.DeleteConsommation(this.id);
        }

        //Calcule la consommation en litre pour 100km.
        public float CalculerConsommationLitre()
        {
            return (litre * 100) / km;
        }

        //Calcule la consommation en € pour 100km.
        public float CalculerConsommationCout()
        {
            return (cout * 100) / km;
        }
    }
}
