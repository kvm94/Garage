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
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        //Attributs

        private Utilisateur user;


        //Constructeur

        public Inscription(Utilisateur user)
        {
            InitializeComponent();
            this.user       = user;
        }

        //Evènements

       //Ferme la fenêtre.
        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Inscrit un utilisateur à la base de données si il n'est pas déjà inscrit.
        private void button_Inscription_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Pseudo.Text != "" && passwordBox_Confirmation.Password != "" && passwordBox_Mdp.Password != "")
            {
                if (passwordBox_Mdp.Password == passwordBox_Confirmation.Password)
                {
                    user.Nom = textBox_Nom.Text;
                    user.Prenom = textBox_Prenom.Text;
                    user.Pseudo = textBox_Pseudo.Text;
                    user.Email = textBox_Email.Text;
                    user.Mdp = passwordBox_Mdp.Password;
                    try
                    {
                        user.Inscription();
                        MessageBox.Show("Utilisateur inscrit!");
                        this.Close();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
                else
                    MessageBox.Show("Les deux mots de passe ne correspondent pas!");
            }
            else
                MessageBox.Show("Champ(s) manquant(s)!");
        }
    }
}
