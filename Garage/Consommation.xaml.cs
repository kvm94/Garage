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
    /// Logique d'interaction pour Consommation.xaml
    /// </summary>
    public partial class Consommation : Window
    {
        //Attributs

        private Voiture v;
        private ListeConsommation liste;

        //Constructeur

        public Consommation(Voiture v)
        {
            InitializeComponent();
            this.v = v;
            liste = new ListeConsommation();
            liste.Charger(v.m.id);
            if(liste.Count()>0)
                LoadTab();
        }

        //Evènements.

        //Ferme la fenêtres.
        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Retour_Copy1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Retour_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        //Calcul et affiche les consommations et ajoute la consommation dans la base de données.
        private void button_Calculer_Click(object sender, RoutedEventArgs e)
        {
            //Vérifie si des champs sont manquants.
            if (textBox_Litre.Text != "" && textBox_Km.Text !="" && textBox_Cout.Text !="")
            {
                try
                {
                    if (textBox_Litre.Text.IndexOf('.') == -1 && textBox_Km.Text.IndexOf('.') == -1 && textBox_Cout.Text.IndexOf('.') == -1)
                    {
                        ConsommationV conso = v.Consomme();
                        float resLitre, resCout;

                        conso.litre = float.Parse(textBox_Litre.Text);
                        conso.km    = int.Parse(textBox_Km.Text);
                        conso.cout  = float.Parse(textBox_Cout.Text);

                        resLitre    = conso.CalculerConsommationLitre();
                        resCout     = conso.CalculerConsommationCout();

                        conso.Ajout(v.m.id);

                        tabItem_DernierPlein.IsSelected = true;

                        liste = new ListeConsommation();
                        liste.Charger(v.m.id);
                        LoadTab();
                    }
                    else
                        MessageBox.Show("Veuillez utiliser ',' comme séparateur pour les nombres décimaux!");                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
                MessageBox.Show("Champ(s) manquant(s)!");
        }

        //Rentre les infomations dans les différents champs.
        private void LoadTab()
        {
            //Onglet : Dernier plein.
            textBlock_LCout_Km_Copy.Text = liste.Extraire(0).CalculerConsommationCout().ToString();
            textBlock_Litre_Km_Copy.Text = liste.Extraire(0).CalculerConsommationLitre().ToString();

            //Onglet : Moyenne.
            textBlock_LCout_Km.Text = liste.CalculerMoyenneCout().ToString();
            textBlock_Litre_Km.Text = liste.CalculerMoyenneLitre().ToString();

        }
    }
}
