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
    public partial class Tym : UserControl
    {
        public Tym(int idTymu)
        {
            InitializeComponent();

            dbManager = new DatabaseManager();   
            this.idTymu = idTymu;
        }

        List<string> projekty;
        List<string> zaci;
        List<string> ukoly;

        int idTymu = 0;
        int idProjektu = 0;
        string select = "";

        DatabaseManager dbManager;
        public bool nacetlo = false;

        string vybranyzak = "";
        string vybranyukol = "";
        string vybranePrirazeni = "";

        public void NactiData(int idTymu, int idZaka)
        {
            CmbxProjekty.SelectedIndex = -1;
            CmbxProjekty.Items.Clear();

            projekty = dbManager.NactiProjekty(idTymu);

            for (int i = 0; i < projekty.Count; i++)
            {
                string[] rozdelovac = projekty[i].ToString().Split(';');
                CmbxProjekty.Items.Add(rozdelovac[1]);
            }

            nacetlo = true;

            NactiListboxy();
        }

        private void BtnPrirad_Click(object sender, RoutedEventArgs e)
        {
            dbManager.PriradUkol(idProjektu, 
                dbManager.ZjistiIdZakaPodleTymu(vybranyzak, idTymu), vybranyukol);
            Ukol.SelectedIndex = -1;
            Ukol.Items.Remove(vybranyukol);
            Vybrano.Items.Add(vybranyukol);
            vybranyukol = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            dbManager.OdradUkol(idProjektu, vybranePrirazeni);
            Vybrano.SelectedIndex = -1;
            Vybrano.Items.Remove(vybranePrirazeni);
            Ukol.Items.Add(vybranePrirazeni);
            vybranePrirazeni = "";
        }

        private void CmbxProjekty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (nacetlo == true)
                {
                    if (CmbxProjekty.SelectedIndex != -1) 
                    {
                        select = CmbxProjekty.SelectedValue.ToString();
                        NactiListboxy();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void NactiListboxy()
        {
            try
            {
                idProjektu = dbManager.ZjistiIdProjektZNazvu(select);
                if (Tymvyber.Items.Count > 0)
                {
                    Tymvyber.SelectedIndex = -1;
                    Tymvyber.Items.Clear();
                }

                zaci = dbManager.NactiZaky(dbManager.ZjistiIdTymuZProjektu(select));
                for (int i = 0; i < zaci.Count; i++)
                {
                    Tymvyber.Items.Add(zaci[i]);
                }

                if (Ukol.Items.Count > 0)
                {
                    Ukol.SelectedIndex = -1;
                    Ukol.Items.Clear();
                }
                if (Vybrano.Items.Count > 0)
                {
                    Vybrano.SelectedIndex = -1;
                    Vybrano.Items.Clear();
                }
                ukoly = dbManager.NactiVsechnyUkoly(idProjektu);
                foreach (var a in ukoly)
                {
                    string[] delic = a.Split(';');
                    if (delic[4] == "")
                    {
                        Ukol.Items.Add(delic[1]);
                    }
                    else
                    {
                        Vybrano.Items.Add(delic[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void ZapniBtn()
        {
            if (vybranyzak != "" && vybranyukol != "")
            {
                BtnPrirad.IsEnabled = true;
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
                        ZapniBtn();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Ukol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Ukol.Items.Count != 0)
                {
                    if (Ukol.SelectedIndex != -1)
                    {
                        vybranyukol = Ukol.SelectedValue.ToString();
                        ZapniBtn();
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Vybrano_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Vybrano.Items.Count != 0)
                {
                    if (Vybrano.SelectedIndex != -1)
                    {
                        vybranePrirazeni = Vybrano.SelectedValue.ToString();
                        BtnBack.IsEnabled = true;
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
