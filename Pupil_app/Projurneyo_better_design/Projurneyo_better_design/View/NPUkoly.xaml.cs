using Projurneyo_better_design.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projurneyo_better_design.View
{

    public partial class NPUkoly : UserControl
    {
        public NPUkoly(string nazevProjektu, string popis, int idZaka, Prihlaseni mainwindow)
        {
            InitializeComponent();

            dbManager = new DatabaseManager();

            CmbxTypUkolu.Items.Add("Text");
            CmbxTypUkolu.Items.Add("Soubor");
            CmbxTypUkolu.Items.Add("SWOT");
            CmbxTypUkolu.Items.Add("Libovolny");

            this.nazevProjektu = nazevProjektu;
            this.popis = popis;
            this.idZaka = idZaka;

            this.mainwindow = mainwindow;
            navigace = new NavigaceVProgramu(mainwindow);
        }

        DatabaseManager dbManager;
        NavigaceVProgramu navigace;
        Prihlaseni mainwindow;

        string nazevukol = "";
        string typ = "";
        int pocetukolu = 0;

        string vybranyukol = "";

        string nazevProjektu = "";
        string popis = "";
        int idZaka = 0;

        private void BtnAddUkol_Click(object sender, RoutedEventArgs e)
        {
            if (CmbxTypUkolu.Text != "" && Ukol.Text != "Název úkolu..." && Ukol.Text != "" && !(Ukol.Text.Contains(';')))
            {
                nazevukol = Ukol.Text;
                typ = CmbxTypUkolu.Text;

                Seznam.Items.Add(nazevukol + ";" + typ);
                CmbxTypUkolu.SelectedIndex = -1;
                Ukol.Text = "Název úkolu...";
                pocetukolu++;
                BtnPotvrdit.IsEnabled = true;
                BtnRemoveUkol.IsEnabled = true;
            }
        }

        private void BtnRemoveUkol_Click(object sender, RoutedEventArgs e)
        {
            if (vybranyukol != "")
            {
                Seznam.SelectedIndex = -1;
                Seznam.Items.Remove(vybranyukol);
                BtnRemoveUkol.IsEnabled = false;
                vybranyukol = "";
                pocetukolu--;

                if (pocetukolu == 0)
                {
                    BtnPotvrdit.IsEnabled = false;
                }
            }
        }

        private void Seznam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (vybranyukol == "")
                {
                    if (Seznam.SelectedIndex != -1)
                    {
                        BtnRemoveUkol.IsEnabled = true;
                        vybranyukol = Seznam.SelectedItem.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPotvrdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbManager.PridejProjekt(nazevProjektu, popis, dbManager.ZjistiIdTymZaka(idZaka));
                int idProjektu = dbManager.ZjistiIdProjekt(nazevProjektu, popis);

                if (idProjektu != 0)
                {
                    foreach (var a in Seznam.Items)
                    {
                        string[] rozdelovac = a.ToString().Split(';');

                        dbManager.PridejUkol(rozdelovac[0], rozdelovac[1], idProjektu);

                    }
                    //Přepne stránky aplikace
                    navigace.SwitchniNaProjekty(mainwindow.seznamprojektu);
                    mainwindow.seznamprojektu.NactiProjekty(mainwindow.idTymu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Ukol_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Název úkolu...")
            {
                textBox.Text = "";
                var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                textBox.Foreground = stetec;
            }
        }

        private void Ukol_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Název úkolu...";
                var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF868686"));
                textBox.Foreground = stetec;
            }
        }

        
    }
}
