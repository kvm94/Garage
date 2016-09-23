using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Moteur
    {
        //Attributs

        public int      id        { get; set; }
        public string   carburant { get; set; }
        public int      cylindre  { get; set; }
        public int      puissance { get; set; }

        //Constructeur
        public Moteur()
        {

        }

        public Moteur(int id, string carburant, int cylindre, int puissance)
        {
            this.id = id;
            this.carburant  = carburant;
            this.cylindre   = cylindre;
            this.puissance  = puissance;
        }

        //Méthodes

        //Ajoute le moteur dans la base de données.
        public void Ajout()
        {
            DataBase.AddMoteur(this);
        }

        //Supprime le moteur de la base de données.
        public void Supprimer()
        {
            DataBase.DeleteMotor(this.id);
        }
    }
}
