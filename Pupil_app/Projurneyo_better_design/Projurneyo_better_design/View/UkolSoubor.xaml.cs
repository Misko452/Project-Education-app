using Microsoft.Win32;
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
using System.IO;
using Projurneyo_better_design.Model;

namespace Projurneyo_better_design.View
{

    public partial class UkolSoubor : UserControl
    {
        public UkolSoubor(string zadani, int idUkolu, int idTymu)
        {
            InitializeComponent();

            this.idUkolu = idUkolu;
            this.idTymu = idTymu;
            this.zadani = zadani;
            Potvrdit.IsEnabled = false;
            VyberSoubor.IsEnabled = true;

            TxtBxpopisUkolu.Text = zadani;
            dbmanager = new DatabaseManager();
            komunikace = new Komunikace();
        }

        int idUkolu = 0;
        int idTymu = 0;
        string zadani = "";
        string cesta;

        byte[] buffer;
        string[] pripona;

        Komunikace komunikace;
        DatabaseManager dbmanager;

        private void Potvrdit_Click(object sender, RoutedEventArgs e)
        {
            komunikace.UlozSoubor(cesta,
                idUkolu, buffer, pripona);
            Potvrdit.IsEnabled = false;
            VyberSoubor.IsEnabled = false;
            dbmanager.PridejAlert(idUkolu, idTymu, "Soubory jsou odeslané.");
        }

        private void VyberSoubor_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;
            dialog.ShowDialog();
            cesta = dialog.FileName;
            pripona = cesta.Split('.');

            if (cesta != "")
            {
                FileStream stream = new FileStream(cesta, FileMode.Open);
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, int.Parse(stream.Length.ToString()));
                Vybrano.Content = "Vybraný soubor: " + cesta;
                Potvrdit.IsEnabled = true;
            }
            
        }
    }
}
