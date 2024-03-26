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

        }

        NavigaceVProgramu navigace;
        DatabaseManager dbManager;
        Prihlaseni mainwindow;

        UkolText text;
        UkolSwot swot;
        UkolVseobecny cokoliv;
        UkolSoubor soubor;

        int pocetHotovo = 0;
        int pocetxp = 0;
        int maxxp = 0;

        int idTymu = 0;
        int idProjektu = 0;

        string vybranyUkol = "";

        public void NactiUkoly(string nazev, string zadani
            ,string hotovo, int idProjektu, int idZaka)
        {
            LstBxUkoly.SelectedIndex = -1;
            LstBxUkoly.Items.Clear();
            this.idProjektu = idProjektu;
            List<string> textukoly = dbManager.NactiUkoly(idProjektu, idZaka);

            if (textukoly.Count == 0)
            {
                Ukol.IsEnabled = false;
            }
            else
            {
                Ukol.IsEnabled = true;
            }

            foreach (var a in textukoly) 
            {
                string[] rozdelovac = a.ToString().Split(';');
                LstBxUkoly.Items.Add(rozdelovac[1] + ";" + rozdelovac[2]);
            }

            ProjektNazev.Content = nazev;
            TxtBxPopis.Text = zadani;

            mainwindow.pomocnynazev = nazev;
            mainwindow.pomocnezadani = zadani;
            mainwindow.pomocnehotovo = hotovo;
            mainwindow.pomocneid = idProjektu;
            mainwindow.pomocneid2 = idZaka;

            idTymu = mainwindow.idTymu;
        }

        public void Ukol_Click(object sender, EventArgs e)
        {
            string[] delic = vybranyUkol.Split(';');

            switch(delic[1])
            {
                case "Text":
                    text = new UkolText(delic[0], dbManager.ZjistiIdUkolu(delic[0],idProjektu), idTymu);
                    navigace.SwitchniTextUkol(text);
                    break;
                case "SWOT":
                    swot = new UkolSwot(delic[0], dbManager.ZjistiIdUkolu(delic[0], idProjektu), idTymu);
                    navigace.SwitchniSWOTUkol(swot);
                    break;
                case "Libovolny":
                    cokoliv = new UkolVseobecny(delic[0], dbManager.ZjistiIdUkolu(delic[0], idProjektu), idTymu);
                    navigace.SwitchniLibovolny(cokoliv);
                    break;
                case "Soubor":
                    soubor = new UkolSoubor(delic[0], dbManager.ZjistiIdUkolu(delic[0], idProjektu), idTymu);
                    navigace.SwitchniSoubor(soubor);
                    break;
                default:
                    break;
            }
        }

        private void LstBxUkoly_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (LstBxUkoly.SelectedItems.Count != 0) 
                {
                    if (LstBxUkoly.SelectedIndex != -1)
                    {
                        vybranyUkol = LstBxUkoly.SelectedValue.ToString();
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
