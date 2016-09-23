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
    /// Logique d'interaction pour ProfilV.xaml
    /// </summary>
    public partial class ProfilV : Window
    {
        private Voiture v;
        public bool updated;

        public ProfilV()
        {
            InitializeComponent();
        }

        public ProfilV(Voiture v)
        {
            InitializeComponent();
            this.v = v;
            updated = false;
            textBox_Marque.Text = v.marque;
            textBox_Modele.Text = v.modele;
            comboBox_Type.Text = v.type;
            textBox_Couleur.Text = v.couleur;
            textBox_Annee.Text = v.annee.ToString();
            textBox_Km.Text = v.km.ToString();
            comboBox_Carburant.Text = v.m.carburant;
            textBox_Cylindree.Text = v.m.cylindre.ToString();
            textBox_Puissance.Text = v.m.puissance.ToString();
        }

        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Consommation_Click(object sender, RoutedEventArgs e)
        {
            Consommation consommation = new Consommation(v);
            consommation.ShowDialog();
        }

        private void button_Entretien_Click(object sender, RoutedEventArgs e)
        {
            Entretien entretien = new Entretien(v);
            entretien.ShowDialog();
        }

        private void button_Modifier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                v.marque        = textBox_Marque.Text;
                v.modele        = textBox_Modele.Text;
                v.type          = comboBox_Type.Text;
                v.couleur       = textBox_Couleur.Text;
                v.annee         = int.Parse(textBox_Annee.Text);
                v.km            = int.Parse(textBox_Km.Text);
                v.m.carburant   = comboBox_Carburant.Text;
                v.m.cylindre    = int.Parse(textBox_Cylindree.Text);
                v.m.puissance   = int.Parse(textBox_Puissance.Text);
                v.Modifier();
                MessageBox.Show("Voiture modifié!");
                updated = true;
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
    }
}
