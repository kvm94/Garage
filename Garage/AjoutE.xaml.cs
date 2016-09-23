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
    /// Logique d'interaction pour AjoutE.xaml
    /// </summary>
    public partial class AjoutE : Window
    {
        //Attributs

        private Voiture v;
        public bool ajout {get; set;}

        //Constructeur

        public AjoutE(Voiture v)
        {
            this.v = v;
            InitializeComponent();
            ajout = false;
        }

        //Evènements

        //Ferme la fenêtre.
        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Ajoute l'entretien à la base de données.
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Vérifie que les champs sont tous remplis.
                if (textBox_Km.Text !="" && textBox_Info.Text !="" && Date_KmE.Text != "")
                {
                    //Crée l'entretien et le remplit.
                    EntretienV ent = v.CreerEntretien();
                    ent.date = Date_KmE.SelectedDate.Value;
                    ent.km = int.Parse(textBox_Km.Text);
                    ent.info = textBox_Info.Text;

                    //Ajoute l'entretien à la base de données.
                    ent.Ajout(v.m.id);
                    //Flag qui dit que un entretien a été ajouté.
                    ajout = true;
                    MessageBox.Show("Entretien ajouté!");
                    this.Close();
                }
                else
                    MessageBox.Show("Champ(s) manquant(s)!");  
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
