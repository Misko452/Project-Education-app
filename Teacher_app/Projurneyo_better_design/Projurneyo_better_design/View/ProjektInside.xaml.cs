using Projurneyo_better_design.Model;
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
    public partial class ProjektInside : UserControl
    {
        public ProjektInside(Prihlaseni mainwindow)
        {
            InitializeComponent();

            dbManager = new DatabaseManager();
            this.mainwindow = mainwindow;
            navigace = new NavigaceVProgramu(mainwindow);
            komunikace = new Komunikace();
            VypniButtony();
        }

        NavigaceVProgramu navigace;
        DatabaseManager dbManager;
        Prihlaseni mainwindow;
        Komunikace komunikace;

        public string zadani = "";
        public string typ = "";
        public int idTymu = 0;
        public int idUkolu = 0;
        public string message = "";

        int xp = 0;

        List<string> soubory;

        public void NactiUkoly()
        {
            try
            {
                zadani = dbManager.ZjistiZadaniZId(idUkolu);
                TxtBxZadani.Text = zadani;
                TxtBxOdpoved.Text = "Zpráva: \n" + message;

                soubory = komunikace.NactiSoubory();

                switch (typ)
                {
                    case "Text":
                        Text.Visibility = Visibility.Visible;
                        SWOT.Visibility = Visibility.Collapsed;
                        SWOT.IsEnabled = false;
                        TxtBxOdpoved.IsEnabled = true;
                        Button.Visibility = Visibility.Collapsed;
                        Button.IsEnabled = false;
                        foreach (string s in soubory)
                        {
                            string[] delic = s.Split('.');
                            if (delic[0] == idUkolu.ToString())
                            {
                                TxtBxOdpoved.Text += "\n Odeslaný text \n" + komunikace.NactiTextSoubor(s);
                                TxtBxOdpoved.Visibility = Visibility.Visible;
                                TxtBxOdpoved.IsEnabled = true;
                                break;
                            }
                        }
                        break;
                    case "Soubor":
                        Soubor.Visibility = Visibility.Visible;
                        Button.Visibility = Visibility.Visible;
                        Button.IsEnabled = true;
                        SWOT.Visibility = Visibility.Collapsed;
                        SWOT.IsEnabled = false;
                        TxtBxOdpoved.IsEnabled = false;
                        break;
                    case "SWOT":
                        SWOT.Visibility = Visibility.Visible;
                        SWOT.IsEnabled = true;
                        Text.Visibility = Visibility.Collapsed;
                        Button.Visibility = Visibility.Collapsed;
                        Button.IsEnabled = false;
                        TxtBxOdpoved.IsEnabled = false;
                        foreach (string s in soubory)
                        {
                            string[] delic = s.Split('.');
                            if (delic[0] == idUkolu.ToString())
                            {
                                string[] rozdelovac = komunikace.NactiTextSoubor(s).Split(";;;;;");
                                S.Text = "Strengts: " + rozdelovac[0];
                                W.Text = "Weaknesses: " + rozdelovac[1];
                                O.Text = "Opportunities: " + rozdelovac[2];
                                T.Text = "Threads: " + rozdelovac[3];
                                break;
                            }
                        }
                        break;
                    case "Libovolny":
                        Text.Visibility = Visibility.Visible;
                        Button.Visibility = Visibility.Collapsed;
                        Button.IsEnabled = false;
                        TxtBxOdpoved.IsEnabled = true;
                        TxtBxOdpoved.Text = "Úkol splněn";
                        SWOT.Visibility = Visibility.Collapsed;
                        SWOT.IsEnabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (string s in soubory)
                {
                    string[] delic = s.Split('.');
                    if (delic[0] == idUkolu.ToString())
                    {
                        komunikace.StahniSoubor(s);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;

            btn1.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Visible;
            btn3.Visibility = Visibility.Visible;
            btn4.Visibility = Visibility.Visible;
            btn5.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            No.IsEnabled = false;
            Yes.IsEnabled = false;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Yes.IsEnabled = false;
            No.IsEnabled = false;
            Zamitni();
            VypniButtony();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            xp = 300;
            Potvrd();
            VypniButtony();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            xp = 200;
            Potvrd();
            VypniButtony();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            xp = 100;
            Potvrd();
            VypniButtony();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            xp = 50;
            Potvrd();
            VypniButtony();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            xp = 10;
            Potvrd();
            VypniButtony();
        }

        private void Potvrd()
        {
            dbManager.PotvrdSplneni(idUkolu, xp, idTymu);
        }

        private void Zamitni()
        {
            dbManager.ZamitniSplneni(idUkolu);
        }

        private void VypniButtony()
        {
            btn1.Visibility = Visibility.Collapsed;
            btn2.Visibility = Visibility.Collapsed;
            btn3.Visibility = Visibility.Collapsed;
            btn4.Visibility = Visibility.Collapsed;
            btn5.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;

            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
        }
    }

}
