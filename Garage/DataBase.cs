using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class DataBase
    {
        //Connexion à la base de données.
        private static DataClassesGarageDataContext DB = new DataClassesGarageDataContext();

        //Méthodes static

        //Ajout d'un nouvelle utilisateur dans la base de données.
        public static void Inscription(Utilisateur user)
        {
            TUtilisateur tUser = new TUtilisateur();
            var req = DB.SearchUser(user.Pseudo);

            //Si Count() > 0, il y à déjà un utilisateur inscrit avec ce pseudo.
            if (req.Count() > 0)
                throw new Exception("L'utilisateur existe déjà !");
            //Sinon, on inscrit le nouvelle utilisateur dans la base de données.
            else
            {
                tUser.pseudo = user.Pseudo;
                tUser.mdp = user.Mdp;
                tUser.nom = user.Nom;
                tUser.prenom = user.Prenom;
                tUser.email = user.Email;

                DB.TUtilisateur.InsertOnSubmit(tUser);
                DB.SubmitChanges();
            }
        }

        //Verifier les identifiants et initialise l'utilisateur
        public static void Connexion(Utilisateur user)
        {
            var req = DB.GetUser(user.Pseudo, user.Mdp);

            //Compte si il y a bien un utilisateur avec ce pseudo et mot de passe
            if (req.Count() > 0)
            {
                //Recharge la requête car  elle a déjà été énuméré avec le Count()
                req = DB.GetUser(user.Pseudo, user.Mdp);
                foreach (var res in req)
                {
                    user.Nom = res.nom;
                    user.Prenom = res.prenom;
                    user.Email = res.email;
                }

            }
            else
                throw new Exception("Identifiant ou mot de passe incorrect!");
        }

        //Fait une mise à jour de l'utilisateur dans la base de données.
        public static void UpdateU(Utilisateur user)
        {
            var rep = DB.UpdateUser(user.Pseudo, user.Nom, user.Prenom, user.Email, user.Mdp);
        }

        //Charge la liste des voitures
        public static void LoadCars(ListeVoiture liste, string pseudo)
        {
            var req = DB.GetVoiture(pseudo);

            foreach (var item in req)
            {
                liste.Ajout(item.numVoiture , item.marque, item.modele, item.type, item.couleur, item.annee, item.numMoteur, item.carburant, item.cylindre, item.puissance, item.km);
            }
        }

        //Ajout d'une voiture dans la base de données.
        public static void AddCar(Voiture v, string pseudo)
        {
            int numUser = 0, cpt=0;
            TVoiture tCar = new TVoiture();
            var req = DB.GetNumUser(pseudo);

            foreach (var item in req)
            {
                cpt++;
                numUser = item.numUtil;
            }

            if (cpt > 0)
            {
                tCar.numUtil    = numUser;
                tCar.marque     = v.marque;
                tCar.modele     = v.modele;
                tCar.type       = v.type;
                tCar.couleur    = v.couleur;
                tCar.annee      = v.annee;

                DB.TVoiture.InsertOnSubmit(tCar);
                DB.SubmitChanges();
            }
            else
                throw new Exception("Erreur lors de l'ajout de la voiture à la base de donnée!"); 
        }

        //Supprime une voiture de la base de données.
        public static void DeleteCar(int idVoiture)
        {
            DB.DeleteDetail(idVoiture);
            DB.DeleteCar(idVoiture);
            DB.SubmitChanges();
        }

        //Supprime le moteur de la base de données.
        public static void DeleteMotor(int idMotor)
        {
            DB.DeleteMotor(idMotor);
            DB.SubmitChanges();
        }

        //Supprime un entretien de la base de données.
        public static void DeleteEntretien(int idEntretien)
        {
            DB.DeleteEntretien(idEntretien);
            DB.SubmitChanges();
        }

        //Supprime une consommation de la base de données.
        public static void DeleteConsommation(int idConsommation)
        {
            DB.DeleteConsommation(idConsommation);
            DB.SubmitChanges();
        }

        //Ajout d'un Moteur dans la base de données.
        public static void AddMoteur(Moteur m)
        {
            TMoteur tMoteur = new TMoteur();

            tMoteur.puissance = m.puissance;
            tMoteur.carburant = m.carburant;
            tMoteur.cylindre  = m.cylindre;

            DB.TMoteur.InsertOnSubmit(tMoteur);
            DB.SubmitChanges();
        }

        //Ajout d'un détail moteur dans la base de données.
        public static void AddDetail(Voiture v, string pseudo)
        {
            TDetailMoteur detail = new TDetailMoteur();
            int numUtil=0, numMoteur=0, numVoiture=0;

            //Récupération des clé secondaires.
            var req1 = DB.GetNumMoteur(v.m.carburant, v.m.cylindre, v.m.puissance);
            var req2 = DB.GetNumUser(pseudo);

            foreach (var item in req1)
                numMoteur = item.numMoteur;

            foreach (var item in req2)
                numUtil = item.numUtil;

            var req3 = DB.GetNumVoiture(numUtil, v.marque, v.modele, v.type, v.annee);

            foreach (var item in req3)
                numVoiture = item.numVoiture;

            //Enregistrement dans la base de données.
            if (numUtil > 0 && numVoiture > 0 && numMoteur > 0)
            {
                detail.km           = v.km;
                detail.numMoteur    = numMoteur;
                detail.numVoiture   = numVoiture;

                DB.TDetailMoteur.InsertOnSubmit(detail);
                DB.SubmitChanges();
            }
            else
            {
                throw new Exception("Erreur de chargement DétailMoteur!");
            }
        }

        //Modification de la voiture dans la base de données.
        public static void UpdateCar(Voiture v)
        {
            DB.UpdateCar(v.id, v.marque, v.modele, v.type, v.couleur, v.annee);
            DB.UpdateMotor(v.m.id, v.m.carburant, v.m.puissance, v.m.cylindre);
            DB.UpdateDetail(v.m.id, v.id, v.km);
        }

        //Ajout d'un entretien dans la base de données.
        public static void AddEnt(EntretienV e, int idMoteur)
        {
            TEntretien tEnt = new TEntretien();

            tEnt.numMoteur = idMoteur;
            tEnt.kmE = e.km;
            tEnt.info = e.info;
            tEnt.date = e.date;

            DB.TEntretien.InsertOnSubmit(tEnt);
            DB.SubmitChanges();
        }

        //Charge les entretiens dans un liste.
        public static void LoadEntretien(ListeEntretien liste, int idMoteur)
        {
            var req = DB.GetEntretien(idMoteur);

            foreach (var item in req)
            {
                liste.Ajout(item.numEntretient, item.date, item.kmE, item.info);
            }
        }

        //Ajout d'une consommation à la base de données.
        public static void AddConsommation(ConsommationV consoV, int idMotor)
        {
            TConsommation conso = new TConsommation();

            conso.cout = consoV.cout;
            conso.kmC = consoV.km;
            conso.litre = consoV.litre;
            conso.numMoteur = idMotor;

            DB.TConsommation.InsertOnSubmit(conso);
            DB.SubmitChanges();
        }

        //Charge les consommations dans un liste.
        public static void LoadConsommation(ListeConsommation liste, int idMoteur)
        {
            var req = DB.GetConsommation(idMoteur);

            foreach (var item in req)
            {
                liste.Ajout(item.numConsommation, item.litre, item.kmC, item.cout);
            }
        }

    }
}
