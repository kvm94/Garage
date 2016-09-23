using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Utilisateur
    {
        //Attributs

        private string  nom;
        private string  prenom;
        private string  email;
        private string  pseudo;
        private string  mdp;
        private Voiture v;

        //Constructeurs

        public Utilisateur()
        {
          
        }

        public Utilisateur(string pseudo = "", string mdp = "", string nom="", string prenom="", string email="")
        {
          
            this.nom        = nom;
            this.prenom     = prenom;
            this.email      = email;
            this.pseudo     = pseudo;
            this.mdp        = mdp;
        }

        //Accesseurs

        public string Nom
        {
            get { return nom;  }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        public string Mdp
        {
            get { return mdp; }
            set { mdp = value; }
        }


        //Méthodes

        //Donne l'ordre de créer une voiture.
        public Voiture CreerVoiture()
        {
            return v = new Voiture();
        }

        //L'utilisateur se connecte.
        public void SeConnecter (string pseudo, string mdp)
        {
            this.pseudo = pseudo;
            this.mdp    = mdp;
            DataBase.Connexion(this);
        }

        //L'utilisateur se déconnecte.
        public void SeDeconnecter()
        {
            nom     = "";
            prenom  = "";
            email   = "";
            pseudo  = "";
            mdp     = "";
        }

        //L'utilisateur s'inscrit.
        public void Inscription()
        {
           DataBase.Inscription(this);
        }

        //L'utilisateur modifie sont profil.
        public void Modifier()
        {
            DataBase.UpdateU(this);
        }

    }
}
