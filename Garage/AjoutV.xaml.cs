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
    /// Logique d'interaction pour AjoutV.xaml
    /// </summary>
    public partial class AjoutV : Window
    {
        //Attributs

        private Utilisateur user;
        private bool        ajout;

        //Constructeur

        public AjoutV(Utilisateur user)
        {
            InitializeComponent();
            this.user   = user;
            ajout       = false;               
        }

        //Evènements

        //Ferme la fenêtre.
        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Renvoi true si un ajout a été éffectué.
        public bool Ajout
        {
            get { return ajout; }
        }

        //Ajoute une voiture à la base de données.
        private void button_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Voiture v   = user.CreerVoiture();
                v.marque    = textBox_Marque.Text;
                v.modele    = textBox_Modele.Text;
                v.type      = comboBox_Type.Text;
                v.couleur   = textBox_Couleur.Text;
                v.annee     = int.Parse(textBox_Annee.Text);
                v.km        = int.Parse(textBox_Km.Text);
                v.m.carburant   = comboBox_Carburant.Text;
                v.m.cylindre    = int.Parse(textBox_Cylindree.Text);
                v.m.puissance   = int.Parse(textBox_Puissance.Text);
                v.Ajout(user.Pseudo);

                //Flag qui détermine l'ajout d'une voiture.
                ajout = true;

                MessageBox.Show("La voiture a été correctement ajouté!");
                this.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }        
        }
    }
}
