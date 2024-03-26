using Projurneyo_better_design.View;
using Projurneyo_better_design.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
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

namespace Projurneyo_better_design
{
    public partial class Prihlaseni : Window
    {
        public Prihlaseni()
        {
            InitializeComponent();

            Btn1.IsEnabled = false;
            Btn2.IsEnabled = false;
            Btn3.IsEnabled = false;
            Btn4.IsEnabled = false;

            Back.Visibility = Visibility.Collapsed;

            seznamprojektu = new Projekty(this);
            register = new Register(this);
            login = new Login(this);
            navigace = new NavigaceVProgramu(this);
            inside = new ProjektInside(this);

            navigace.SwitchniLogin(login);
        }

        private readonly NavigaceVProgramu navigace;
        public readonly Projekty seznamprojektu;
        public NovyProjekt novyprojekt;
        public Leaderboard zebricek;
        public readonly Login login;
        public readonly Register register;
        public Tym tym;
        public readonly ProjektInside inside;

        public string pomocnynazev = "";
        public string pomocnezadani = "";
        public string pomocnehotovo = "";
        public int pomocneid = 0;
        public int pomocneid2 = 0;

        public string aktualniStranka = "";
        public string nazevOrg = "";
        public int idTridy = 0;
        public int idZaka = 0;
        public int idTymu = 0;

        public void SwitchniNaProjekty_Click(object sender, RoutedEventArgs e)
        {
            navigace.SwitchniNaProjekty(seznamprojektu);
            seznamprojektu.NactiProjekty(idTymu);
        }

        public void SwitchniNaNovyProjekt_CLick(object sender, RoutedEventArgs e)
        {
            novyprojekt = new NovyProjekt(nazevOrg, this, idZaka);
            navigace.SwitchniNaNovyProjekt(novyprojekt);
        }

        public void SwitchniNaTym_Click(object sender, RoutedEventArgs e)
        {
            tym = new Tym(idTymu);
            tym.nacetlo = false;
            tym.NactiData(idTymu, idZaka);
            navigace.SwitchniNaTymy(tym);
        }

        public void SwitchniNaLeaderboard_CLick(object sender, RoutedEventArgs e)
        {
            zebricek = new Leaderboard(idTridy);
            navigace.SwitchniNaZebricek(zebricek);
            zebricek.NactiZebricek();
        }

        private void MinIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (aktualniStranka)
            {
                case "NewTask":
                    navigace.SwitchniNaNovyProjekt(novyprojekt);
                    break;
                case "Teams":
                    break;
                case "ProjectInside":
                    navigace.SwitchniNaProjekty(seznamprojektu);
                    seznamprojektu.NactiProjekty(idTymu);
                    break;
                case "TaskInside":
                    navigace.SwitchniVnitrekProjektu(inside);
                    inside.NactiUkoly(pomocnynazev,
                        pomocnezadani, pomocnehotovo, pomocneid, pomocneid2);
                    break;
                case "Leaderboard":
                    break;
            }
        }
    }
}
