using Projurneyo_better_design.ViewModel;
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

namespace Projurneyo_better_design.View
{
    public partial class Projekty : UserControl
    {
        public Projekty(Prihlaseni mainwindow, int idUcitele)
        {
            InitializeComponent();

            dbManager = new DatabaseManager();
            vnitrek = new ProjektInside(mainwindow);
            this.mainwindow = mainwindow;
            navigace = new NavigaceVProgramu(mainwindow);
            this.idUcitele = idUcitele;
        }

        DatabaseManager dbManager;
        List<string> alerty;
        List<string> projekty;
        List<string> tymy;

        ProjektInside vnitrek;
        Prihlaseni mainwindow;
        NavigaceVProgramu navigace;

        string vybranatrida = "";
        string vybranyalert = "";
        int idUcitele = 0;

        public void NactiAlerty()
        {
            try
            {
                Alerty.Items.Clear();

                string[] rozdelovac = vybranatrida.Split(';');
                tymy = dbManager.NactiTymyID(int.Parse(rozdelovac[0]));
                foreach (var a in tymy)
                {
                    rozdelovac = a.Split(';');
                    alerty = dbManager.NactiAlerty(int.Parse(rozdelovac[0]));
                    foreach (var b in alerty)
                    {
                        string[] delicalertu = b.Split(":");
                        Alerty.Items.Add(dbManager.ZjistiTypUkoluZID(int.Parse(delicalertu[1]))
                            + " - " + dbManager.ZjistiNazevTymuZId(int.Parse(delicalertu[2])) + " - "
                            + delicalertu[3].Replace(";;;;", ";") + " - " + delicalertu[1] + " - "
                            + delicalertu[2]);
                    }
                    alerty.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void NactiProjekt()
        {
            try
            {
                projekty = dbManager.NactiUcitelovoTridy(idUcitele);
                foreach (var a in projekty)
                {
                    CmbxProjekty.Items.Add(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbxProjekty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vybranatrida = CmbxProjekty.SelectedValue.ToString();
            NactiAlerty();
        }

        private void Alerty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Alerty.Items.Count != 0) 
            {
                vybranyalert = Alerty.SelectedValue.ToString();
                BtnAlertIn.IsEnabled = true;
            }
        }

        private void BtnAlertIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] data = vybranyalert.Split(" - ");
                vnitrek.typ = data[0];
                vnitrek.idTymu = int.Parse(data[4]);
                vnitrek.idUkolu = int.Parse(data[3]);
                vnitrek.message = data[2];
                navigace.SwitchniVnitrekProjektu(vnitrek);
                vnitrek.Yes.IsEnabled = true;
                vnitrek.No.IsEnabled = true;
                vnitrek.NactiUkoly();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
