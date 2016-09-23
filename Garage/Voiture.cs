using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Voiture
    {
        //Attributs

        public int      id      { get; set; }
        public string   marque  { get; set; }
        public string   modele  { get; set; }
        public string   type    { get; set; }
        public string   couleur { get; set; }
        public int      annee   { get; set; }
        public int      km      { get; set; }
        public Moteur   m       { get; set; }
        public EntretienV ent       { get; set; }
        public ConsommationV conso  { get; set; }

        //Constructeur
        public Voiture()
        {
            m = new Moteur();
        }

        public Voiture(int id, string marque, string modele, string type, string couleur, int annee, int idMoteur, string carburant, int cylindre, int puissance, int km)
        {
            this.id         = id;
            this.marque     = marque;
            this.modele     = modele;
            this.type       = type;
            this.couleur    = couleur;
            this.annee      = annee;
            this.km         = km;
            m = new Moteur(idMoteur, carburant, cylindre, puissance);
        }

        //Ajoute la voiture à la base de données.
        public void Ajout(string pseudo)
        {
            DataBase.AddCar(this, pseudo);
            m.Ajout();
            DataBase.AddDetail(this, pseudo);
        }

        //Supprime la voiture de la base de données.
        public void Supprimer(ListeEntretien listeE, ListeConsommation listeC)
        {

            listeE.Supprimer();
            listeC.Supprimer();
            DataBase.DeleteCar(this.id);
            m.Supprimer();
        }

        //Modifier la voiture dans la base de données.
        public void Modifier()
        {
            DataBase.UpdateCar(this);
        }

        //Ajoute un entretien.
        public EntretienV CreerEntretien()
        {
            ent = new EntretienV();
            return ent;
        }

        //La voiture consomme
        public ConsommationV Consomme()
        {
            conso = new ConsommationV();
            return conso;
        }
    }
}
