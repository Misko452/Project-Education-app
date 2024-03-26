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
        public int pocetukolu { get; set; }
        public int idtridy { get; set; }

        public ModelStranky(Prihlaseni mainwindow)
        {
            this.mainwindow = mainwindow;
            dbManager = new DatabaseManager();
            navigace = new NavigaceVProgramu(mainwindow);
        }

        public void PridejUsera(string username, string password, string typ)
        {
            dbManager.PridejUsera( typ, username, password);
            navigace.SwitchniLogin(mainwindow.login);
        }

        public void OverUzivatele(string username, string password)
        {
            string[] login = dbManager.OverUzivatele(username, password);
            if (login[0] != "false" || login == null)
            {

                mainwindow.LabelUsername.Text = username;
                mainwindow.Btn1.IsEnabled = true;
                mainwindow.Btn3.IsEnabled = true;

                mainwindow.idUcitele = int.Parse(login[3]); 

                mainwindow.Back.Visibility = Visibility.Visible;

                mainwindow.AlertySwitch();
            }
        }
    }
}
