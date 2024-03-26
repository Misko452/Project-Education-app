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
    public partial class Register : UserControl
    {
        public Register(Prihlaseni mainwindow)
        {
            InitializeComponent();
            this.mainwindow = mainwindow;
            navigace = new NavigaceVProgramu(mainwindow);
            hlavnimodel = new ModelStranky(mainwindow);
        }

        private readonly Prihlaseni mainwindow;
        private readonly NavigaceVProgramu navigace;
        private readonly ModelStranky hlavnimodel;

        private void LabelDoLoginu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            navigace.SwitchniLogin(mainwindow.login);
        }

        private void TxtBxRegUser_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Uživatelské jméno...")
            {
                textBox.Text = "";
                var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                textBox.Foreground = stetec;
            }
        }

        private void TxtBxRegUser_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Uživatelské jméno...";
                var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF868686"));
                textBox.Foreground = stetec;
            }
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Registruj();
        }

        public void Registruj()
        {
            if (TxtBxRegUser.Text != "Uživatelské jméno..." && TxtBxRegPass.Password != "")
            {
                hlavnimodel.PridejUsera(TxtBxRegUser.Text,
                    TxtBxRegPass.Password, "Zak");
                MessageBox.Show("Registrace proběhla úspěšně, nyní se přihlašte.",
                    "Registrace dokončena", MessageBoxButton.OK, MessageBoxImage.Information);
                navigace.SwitchniLogin(mainwindow.login);
            }           
            
        }

        private void TxtBxRegUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Registruj();
            }
        }

        private void TxtBxRegPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Registruj();
            }
        }
    }
}
