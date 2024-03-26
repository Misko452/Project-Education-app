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
using Projurneyo_better_design.Model;
using Projurneyo_better_design.ViewModel;

namespace Projurneyo_better_design.View
{
    public partial class Login : UserControl
    {
        public Login(Prihlaseni mainwindow)
        {
            InitializeComponent();
            this.mainwindow = mainwindow;
            navigace = new NavigaceVProgramu(mainwindow);
            hlavnimodel = new ModelStranky(mainwindow);
        }

        private readonly Prihlaseni mainwindow;
        private readonly NavigaceVProgramu navigace;
        private readonly ModelStranky hlavnimodel;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prihlas();
        }

        private void LabelDoRegistru_MouseDown(object sender, MouseButtonEventArgs e)
        {
            navigace.SwitchniRegister(mainwindow.register);
        }

        private void TxtBxLoUser_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Uživatelské jméno...")
            {
                textBox.Text = "";
                var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                textBox.Foreground = stetec;
            }
        }

        private void TxtBxLoUser_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Uživatelské jméno...";
                var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF868686"));
                textBox.Foreground = stetec;
            }
        }

        public void Prihlas()
        {
            if (TxtBxLoUser.Text != "Uživatelské jméno..." && TxtBxLoPass.Password != "")
            {
                hlavnimodel.OverUzivatele(TxtBxLoUser.Text,
                TxtBxLoPass.Password);
            }
        }

        private void TxtBxLoUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Prihlas();
            }
        }

        private void TxtBxLoPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Prihlas();
            }
        }
    }
}
