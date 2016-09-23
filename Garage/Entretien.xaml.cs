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
    /// Logique d'interaction pour Entretien.xaml
    /// </summary>
    public partial class Entretien : Window
    {
        //Attributs

        private Voiture v;
        private ListeEntretien liste;

        //Constructeur

        public Entretien(Voiture v)
        {
            this.v = v;
            InitializeComponent();
            button_Afficher.IsEnabled = false;
            LoadListBox();
        }

        //Evènements

        //Ferme la fenêtre.
        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Affiche le formulaire d'ajout d'entretien.
        private void button_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            AjoutE ajoutE = new AjoutE(v);
            ajoutE.ShowDialog();

            //Si un entretien a été ajouté on recharge la liste
            if(ajoutE.ajout)
            {
                listBox.Items.Clear();
                LoadListBox();
            }
        }

        //Affiche les information à propos d'un entretien.
        private void button_Afficher_Click(object sender, RoutedEventArgs e)
        {
            InfoE entretien = new InfoE(liste.Extraire(listBox.SelectedIndex));
            entretien.ShowDialog();
        }

        //Charge le listBox des entretiens.
        private void LoadListBox()
        {
            int i;
            liste = new ListeEntretien();
            liste.Charger(v.m.id);

            for (i = 0; i < liste.Count(); i++)
            {
                EntretienV ent = liste.Extraire(i);
                String field = ent.date.Day + "/" + ent.date.Month + "/" + ent.date.Year + " - " + ent.info;
                listBox.Items.Add(field);
            }
               
        }

        //Active le bouton Afficher lors d'une sélection.
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_Afficher.IsEnabled = true;
        }
    }
}
