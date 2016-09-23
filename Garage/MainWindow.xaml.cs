using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Garage
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        //Attributs 

        private Connexion    connexion;
        private Utilisateur user;
        private ListeVoiture listeV;
        private ListeEntretien listeE;
        private ListeConsommation listeC;
       
        //Constructeur

        public MainWindow()
        {
            InitializeComponent();
            user        = new Utilisateur();
            connexion   = new Connexion(this, user);
            connexion.ShowDialog();
            button_Afficher.IsEnabled   = false;
            button_Supprimer.IsEnabled  = false;
        }

        //Evènements

        //Déconnecte l'utilisateur.
        private void button_logout_Click(object sender, RoutedEventArgs e)
        {
            connexion.Visibility        = Visibility.Visible;
            this.Visibility             = Visibility.Hidden;
            button_Afficher.IsEnabled   = false;
            button_Supprimer.IsEnabled  = false;

            //Vide la liste des voitures.
            listView.Items.Clear();

            //L'utilisateur se déconnecte.
            user.SeDeconnecter();
        }

        //Afficher le profil utilisateur.
        private void button_profil_Click(object sender, RoutedEventArgs e)
        {
            ProfilU profil = new ProfilU(user);
            profil.ShowDialog();
        }

        //Ferme l'application.
        private void window_Garage_Closed(object sender, EventArgs e)
        {
            connexion.Close();
        }

        //Affiche les informations à propos de l'application.
        private void button_APropos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Créé par Marra Kevin \n Date: 18/04/2016 \n Dernière mise à jour: 02/05/2016 \n Version: 1.0.1");
        }

        //Ouvre un formulaire pour ajouter une voiture.
        private void button_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            AjoutV ajout = new AjoutV(user);
            ajout.ShowDialog();

            //Actualise la liste si un voiture a été ajouté.
            if (ajout.Ajout)
            {
                listView.Items.Clear();
                LoadListView();
            }
            button_Afficher.IsEnabled = false;
            button_Supprimer.IsEnabled = false;

        }

        //Afficher les détails d'un voiture.
        private void button_Afficher_Click(object sender, RoutedEventArgs e)
        {
            var voiture = listView.SelectedItem as Voiture;
            
            ProfilV profil = new ProfilV(listeV.Extraire(listView.SelectedIndex));
            profil.ShowDialog();

            //Actualise la liste si une voiture a été modifié.
            if (profil.updated)
            {
                listView.Items.Clear();
                LoadListView();
                button_Afficher.IsEnabled = false;
                button_Supprimer.IsEnabled = false;
            }
            
        }

        //Afficher les interractions avec un voiture.
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_Afficher.IsEnabled   = true;
            button_Supprimer.IsEnabled  = true;
        }

        //Supprime une voiture sélectionné.
        private void button_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Êtes-vous sûr?", "Confirmation de suppression", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    listeE = new ListeEntretien();
                    listeC = new ListeConsommation();
                    listeC.Charger(listeV.Extraire(listView.SelectedIndex).m.id);
                    listeE.Charger(listeV.Extraire(listView.SelectedIndex).m.id);
                    listeV.Supprimer(listView.SelectedIndex, listeE, listeC);
                    button_Afficher.IsEnabled = false;
                    button_Supprimer.IsEnabled = false;
                    MessageBox.Show("Voiture supprimée!");
                    listView.Items.Clear();
                    LoadListView();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }   
        }

        //Charge la liste des voiture.
        public void LoadListView()
        {
            int i;
            listeV = new ListeVoiture();
            listeV.Charger(user.Pseudo);

            for(i = 0;i< listeV.Count();i++)
                listView.Items.Add(listeV.Extraire(i));
        }

        
    }
}
