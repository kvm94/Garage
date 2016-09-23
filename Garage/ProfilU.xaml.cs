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
    /// Logique d'interaction pour ProfilU.xaml
    /// </summary>
    public partial class ProfilU : Window
    {
        //Attributs

        private Utilisateur user;
             
        //Constructeur

        public ProfilU(Utilisateur user)
        {
            InitializeComponent();
            this.user                           = user;
            textBox_Nom.Text                    = user.Nom;
            textBox_Prenom.Text                 = user.Prenom;
            textBlock_Pseudo.Text               = user.Pseudo;
            textBox_Email.Text                  = user.Email;
            passwordBox_Mdp.Password            = user.Mdp;
            passwordBox_Confirmation.Password   = user.Mdp;
        }

        //Evènements

        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Modifier_Click(object sender, RoutedEventArgs e)
        {
            //Vérifie si le mot de passe est identique à la confirmation.
            if (passwordBox_Mdp.Password == passwordBox_Confirmation.Password)
            {
                user.Nom = textBox_Nom.Text;
                user.Prenom = textBox_Prenom.Text;
                user.Pseudo = textBlock_Pseudo.Text;
                user.Email = textBox_Email.Text;
                user.Mdp = passwordBox_Mdp.Password;

                try
                {
                    user.Modifier();
                    MessageBox.Show("Modifications enregistrées!");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
                MessageBox.Show("Les mots de passe ne sont pas identiques!");   
        }
    }
}
