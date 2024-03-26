using Projurneyo_better_design.Utilities;
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
    public partial class UkolVseobecny : UserControl
    {
        public UkolVseobecny(int idUcitele)
        {
            InitializeComponent();
            this.idUcitele = idUcitele;
            this.idTymu = idTymu;
            dbManager = new DatabaseManager();
        }

        int idUcitele = 0;
        int idTymu = 0;
        DatabaseManager dbManager;
        List<string> tymy;
        List<string> tridy;
        string tridaPridat = "";
        string vybranyTym = "";

        public void NactiData()
        {
            try
            {
                tridy = dbManager.NactiTridy(idUcitele);

                foreach (var t in tridy)
                {
                    CmbXTridy.Items.Add(t);
                }

                tymy = dbManager.NactiTymy();

                foreach (var r in tymy)
                {
                    string[] rozdelovac = r.Split(';');
                    SeznamTymu.Items.Add(rozdelovac[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Pridat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool proslo = false;

                if (TxtBxNazevTymu.Text != "" && TxtBxNazevTymu.Text != "Název týmu...")
                {
                    proslo = true;
                }

                foreach (string a in SeznamTymu.Items)
                {
                    if (TxtBxNazevTymu.Text != a)
                    {
                        proslo = true;
                    }
                    else
                    {
                        proslo = false;
                        break;
                    }
                }

                if (proslo == true)
                {
                    dbManager.PridejTym(TxtBxNazevTymu.Text, tridaPridat);
                    SeznamTymu.Items.Add(TxtBxNazevTymu.Text);
                    TxtBxNazevTymu.Text = "";
                    CmbXTridy.SelectedIndex = -1;
                    Pridat.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Odstranit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbManager.OdstranTym(vybranyTym);
                SeznamTymu.SelectedIndex = -1;
                SeznamTymu.Items.Remove(vybranyTym);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SeznamTymu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (SeznamTymu.Items.Count != 0)
                {
                    if (SeznamTymu.SelectedIndex != -1)
                    {
                        vybranyTym = SeznamTymu.SelectedValue.ToString();
                        Odstranit.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbXTridy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CmbXTridy.Items.Count != 0)
                {
                    if (CmbXTridy.SelectedIndex != -1)
                    {
                        tridaPridat = CmbXTridy.SelectedValue.ToString();
                        Pridat.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}