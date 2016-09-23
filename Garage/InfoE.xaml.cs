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
    /// Logique d'interaction pour InfoE.xaml
    /// </summary>
    public partial class InfoE : Window
    {

        //Attributs

        //Constructeur

        public InfoE(EntretienV ent)
        {
            InitializeComponent();
            textBlock_date.Text  = ent.date.Day + "/" + ent.date.Month + "/" + ent.date.Year;
            textBlock_Km.Text    = ent.km.ToString();
            textBlock_Info.Text  = ent.info;

        }

        //Evènements.

        //Ferme la fenêtre.
        private void button_Retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
