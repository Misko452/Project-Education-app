using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Tym : UserControl
    {
        public Tym(int idTridy, int idUcitele)
        {
            InitializeComponent();

            dbManager = new DatabaseManager();   
            this.idTridy = idTridy;
            this.idUcitele = idUcitele;
        }

        List<string> tridy;
        List<string> tymy;
        List<string> zaciTym;
        List<string> zaci;

        int idTridy = 0;
        int idUcitele = 0;
        int idTymu = 0;

        string vybranaTrida = "";
        string vybranytym = "";

        string vybranyzak = "";
        string vybranyzak2 = "";

        DatabaseManager dbManager;

        public void NactiData()
        {
            try
            {
                tridy = dbManager.NactiTridy(idUcitele);
                foreach (var t in tridy)
                {
                    CmbxTrida.Items.Add(t);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPrirad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbManager.PriradZakaTymu(vybranyzak, idTymu);
                Tymvyber.SelectedIndex = -1;
                Tymvyber.Items.Remove(vybranyzak);
                Tymactive.Items.Add(vybranyzak);
                BtnPrirad.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbManager.OdstranZakaZTymu(vybranyzak2, idTymu);
                Tymvyber.SelectedIndex = -1;
                Tymactive.Items.Remove(vybranyzak2);
                Tymvyber.Items.Add(vybranyzak2);
                BtnPrirad.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPovys_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idnovyvelitel = dbManager.ZjistiIdZakaPodleTymu(vybranyzak2, idTymu);
                dbManager.ZvolVelitele(idnovyvelitel, idTymu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Tymactive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Tymactive.Items.Count != 0 )
                {
                    if (Tymactive.SelectedIndex != -1)
                    {
                        vybranyzak2 = Tymactive.SelectedItem.ToString();
                        BtnBack.IsEnabled = true;
                        BtnPovys.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Tymvyber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Tymvyber.Items.Count != 0)
                {
                    if (Tymvyber.SelectedIndex != -1)
                    {
                        vybranyzak = Tymvyber.SelectedValue.ToString();
                        BtnPrirad.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbxTrida_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CmbxTrida.Items.Count != 0)
                {
                    CmBxTym.Items.Clear();
                    Tymvyber.Items.Clear();
                    Tymactive.Items.Clear();

                    vybranaTrida = CmbxTrida.SelectedValue.ToString();
                    idTridy = dbManager.ZjistiIdTridy(vybranaTrida);
                    tymy = dbManager.NactiTymyID(idTridy);

                    foreach (var a in tymy)
                    {
                        CmBxTym.Items.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmBxTym_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CmBxTym.Items.Count != 0)
                {
                    vybranytym = CmBxTym.SelectedValue.ToString();
                    string[] rozdelovac = vybranytym.Split(';');
                    idTymu = int.Parse(rozdelovac[0]);
                    zaciTym = dbManager.NactiZaky(idTymu);
                    zaci = dbManager.NactiZakyBezTymu(idTridy);

                    Tymactive.Items.Clear();
                    foreach (var b in zaciTym)
                    {
                        Tymactive.Items.Add(b);
                    }

                    Tymvyber.Items.Clear();
                    foreach (var c in zaci)
                    {
                        Tymvyber.Items.Add(c);
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
