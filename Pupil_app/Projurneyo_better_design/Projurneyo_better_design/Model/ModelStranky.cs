using Projurneyo_better_design.View;
using Projurneyo_better_design.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Projurneyo_better_design.Model
{
    class ModelStranky
    {
        public string[] rozdelenytag {  get; set; }

        public DatabaseManager dbManager { get; set; }
        public Projekty seznamprojektu { get; set; }
        public NavigaceVProgramu navigace { get; set; }
        public Prihlaseni mainwindow { get; set; }

        public ModelStranky(Prihlaseni mainwindow)
        {
            this.mainwindow = mainwindow;
            dbManager = new DatabaseManager();
            navigace = new NavigaceVProgramu(mainwindow);
            seznamprojektu = new Projekty(mainwindow);
        }

        public void PridejUsera(string username, string password, string typ)
        {
            dbManager.PridejUsera( typ, username, password);
            navigace.SwitchniLogin(mainwindow.login);
        }

        public void OverUzivatele(string username, string password)
        {
            try
            {
                string[] login = dbManager.OverUzivatele(username, password);
                if (login[0] != "false")
                {
                    navigace.SwitchniNaProjekty(seznamprojektu);
                    seznamprojektu.NactiProjekty(int.Parse(login[4]));
                    mainwindow.Btn1.Tag = login[2];

                    mainwindow.LabelUsername.Text = username;
                    mainwindow.Btn1.IsEnabled = true;
                    mainwindow.Btn2.IsEnabled = true;
                    mainwindow.Btn3.IsEnabled = true;
                    mainwindow.Btn4.IsEnabled = true;

                    mainwindow.idTridy = int.Parse(login[2]);
                    mainwindow.idZaka = int.Parse(login[3]);
                    mainwindow.idTymu = int.Parse(login[4]);

                    mainwindow.Back.Visibility = Visibility.Visible;

                    int kapitan = dbManager.ZjistiKapitan(mainwindow.idZaka);

                    if (kapitan == 0)
                    {
                        mainwindow.Btn3.Visibility = Visibility.Collapsed;
                        mainwindow.Btn2.Visibility = Visibility.Collapsed;
                        mainwindow.Btn2.IsEnabled = false;
                        mainwindow.Btn3.IsEnabled = false;
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
