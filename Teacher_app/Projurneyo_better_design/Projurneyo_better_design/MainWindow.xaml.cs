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
            Btn3.IsEnabled = false;

            
            register = new Register(this);
            login = new Login(this);
            navigace = new NavigaceVProgramu(this);
            inside = new ProjektInside(this);
            navigace.SwitchniLogin(login);

            Back.Visibility = Visibility.Collapsed;
        }

        public string aktualniStranka = "";
        public string nazevOrg = "";

        public int idTridy = 0;
        public int idUcitele = 0;

        private readonly NavigaceVProgramu navigace;
        public Projekty seznamprojektu;
        public Leaderboard zebricek;
        public UkolVseobecny NT;
        public readonly Login login;
        public readonly Register register;
        public Tym tym;
        public readonly ProjektInside inside;
        
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
            if (aktualniStranka == "ProjektInside")
            {
                navigace.SwitchniNaProjekty(seznamprojektu);
                seznamprojektu.NactiAlerty();
            }
        }

        public string pomocnynazev = "";
        public string pomocnezadani = "";
        public string pomocnehotovo = "";
        public int pomocneid = 0;
        public int pomocneid2 = 0;

        public void TymZpravaSwitch()
        {
            tym = new Tym(idTridy, idUcitele);
            navigace.SwitchniNaTymy(tym);
            tym.NactiData();
        }

        public void ZebricekSwitch()
        {
            zebricek = new Leaderboard();
            navigace.SwitchniNaZebricek(zebricek);
            zebricek.NactiZebricek();
        }

        public void VytvorTymSwitch()
        {
            NT = new UkolVseobecny(idUcitele);
            navigace.SwitchniLibovolny(NT);
            NT.NactiData();
        }

        public void AlertySwitch()
        {
            seznamprojektu = new Projekty(this, idUcitele);
            navigace.SwitchniNaProjekty(seznamprojektu);
            seznamprojektu.NactiProjekt();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            TymZpravaSwitch();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            AlertySwitch();
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            ZebricekSwitch();
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            VytvorTymSwitch();
        }
    }
}
