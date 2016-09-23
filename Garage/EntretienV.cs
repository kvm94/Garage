using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class EntretienV
    {
        //Attributs
        public int      id      { get; set; }
        public DateTime date    { get; set; }
        public int      km      { get; set; }
        public string   info    { get; set; }

        //Constructeurs

        public EntretienV()
        {

        }

        public EntretienV(int id, DateTime date, int km, string info)
        {
            this.id     = id;
            this.date   = date;
            this.km     = km;
            this.info   = info;
        }

        //Méthodes

        //Ajoute l'entretien dans la base de données.
        public void Ajout(int idMoteur)
        {
            DataBase.AddEnt(this, idMoteur);
        }

        //Supprimer un entretien de la base de données.
        public void Supprimer()
        {
            DataBase.DeleteEntretien(this.id);
        }

    }
}
