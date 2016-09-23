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
using System.Windows.Shapes;

namespace Garage
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        //Attibuts

        private MainWindow  mainWindow;
        private Utilisateur user;
        
        //Constructeur

        public Connexion(MainWindow mainWindow, Utilisateur user)
        {
            InitializeComponent();
            this.mainWindow     = mainWindow;
            this.Visibility     = Visibility.Visible;
            this.user           = user;
        }

        //Evènements

        //Vérifie la connexion et connecte l'utilisateur.
        private void button_Connexion_Click(object sender, RoutedEventArgs e)
        {
            //Vérifie qu'il n'y a pas de case vide.
            if (textBox_Pseudo.Text != "" && passwordBox_Mdp.Password != "")
            {
                try
                {
                    //L'utilisateur se connecte.
                    user.SeConnecter(textBox_Pseudo.Text, passwordBox_Mdp.Password);
                    mainWindow.Visibility = Visibility.Visible;
                    this.Visibility = Visibility.Hidden;

                    //Chargement de la liste des voitures.
                    mainWindow.LoadListView();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
                MessageBox.Show("Champ(s) manquant(s)!");
        }

        //Ouvre une fenêtre d'inscription.
        private void button_Inscription_Click(object sender, RoutedEventArgs e)
        {
            Inscription inscription = new Inscription(user);
            inscription.ShowDialog();
        }

        //Ferme la fenêtre.
        private void window_Connexion_Closed(object sender, EventArgs e)
        {
            mainWindow.Close();
        }
    }
}
