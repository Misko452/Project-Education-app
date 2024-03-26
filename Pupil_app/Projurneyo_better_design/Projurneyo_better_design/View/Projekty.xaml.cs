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
        public Projekty(Prihlaseni mainwindow)
        {
            InitializeComponent();

            dbManager = new DatabaseManager();
            projekty = new List<Button>();
            vnitrek = new ProjektInside(mainwindow);
            this.mainwindow = mainwindow;
            navigace = new NavigaceVProgramu(mainwindow);

            projekty.Add(Projekt1);
            projekty.Add(Projekt2);
            projekty.Add(Projekt3);
            projekty.Add(Projekt4);
            projekty.Add(Projekt5);
            projekty.Add(Projekt6);
            projekty.Add(Projekt7);
            projekty.Add(Projekt8);
            projekty.Add(Projekt9);
            projekty.Add(Projekt10);
            projekty.Add(Projekt11);
            projekty.Add(Projekt12);
            projekty.Add(Projekt13);
            projekty.Add(Projekt14);

            VypniButtony();

        }

        DatabaseManager dbManager;
        List<Button> projekty;
        List<string> textprojekty;
        ProjektInside vnitrek;
        Prihlaseni mainwindow;
        NavigaceVProgramu navigace;

        public void VypniButtony()
        {
            try
            {
                foreach (var a in projekty)
                {
                    a.IsEnabled = false;
                    a.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ZapniButtony()
        {
            try
            {
                foreach (var a in projekty)
                {
                    a.IsEnabled = true;
                    a.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void NactiProjekty(int idTymu)
        {
            try
            {
                textprojekty = dbManager.NactiProjekty(idTymu);

                for (int i = 0; i < textprojekty.Count; i++)
                {
                    projekty[i].IsEnabled = true;
                    projekty[i].Visibility = Visibility.Visible;
                    string[] oddelovac = textprojekty[i].Split(';');
                    projekty[i].Content = oddelovac[1];
                    projekty[i].Tag = textprojekty[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Projekt_Click(object sender,  RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string[] rozdelenyTag = button.Tag.ToString().Split(';');
                int id = dbManager.ZjistiIdZaka(mainwindow.LabelUsername.Text, mainwindow.idTridy);
                vnitrek.NactiUkoly(rozdelenyTag[1], rozdelenyTag[2],
                    rozdelenyTag[3], int.Parse(rozdelenyTag[0]), id);
                navigace.SwitchniVnitrekProjektu(vnitrek);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
