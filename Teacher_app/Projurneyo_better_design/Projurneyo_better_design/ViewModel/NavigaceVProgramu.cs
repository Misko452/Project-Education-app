using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projurneyo_better_design.Utilities;
using System.Windows.Input;
using System.Threading;
using System.Windows.Controls;
using Projurneyo_better_design.View;
using System.Security.Cryptography.Xml;
using System.Windows;

namespace Projurneyo_better_design.ViewModel
{
     class NavigaceVProgramu : ViewModelBase
     {

        private readonly Prihlaseni mainwindow;
        public readonly Register register;
        public readonly Login login;
        public readonly ProjektInside vnitrekprojektu;

        public void SwitchniNaProjekty(Projekty seznamprojektu)
        {
            try
            {
                mainwindow.control.Content = seznamprojektu;
                mainwindow.aktualniStranka = "Projects";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SwitchniNaTymy(Tym tym)
        {
            try
            {
                mainwindow.control.Content = tym;
                mainwindow.aktualniStranka = "Teams";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SwitchniLogin(Login login)
        {
            try
            {
                mainwindow.control.Content = login;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SwitchniRegister(Register register)
        {
            try
            {
                mainwindow.control.Content = register;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SwitchniVnitrekProjektu(ProjektInside vnitrekprojektu)
        {
            try
            {
                mainwindow.control.Content = vnitrekprojektu;
                mainwindow.aktualniStranka = "ProjectInside";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SwitchniLibovolny(UkolVseobecny cokoliv)
        {
            try
            {
                mainwindow.control.Content = cokoliv;
                mainwindow.aktualniStranka = "TaskInside";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SwitchniNaZebricek(Leaderboard zebricek)
        {
            try
            {
                mainwindow.control.Content = zebricek;
                mainwindow.aktualniStranka = "Leaderboard";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public NavigaceVProgramu(Prihlaseni mainwindow)
        {
            this.mainwindow = mainwindow;
        }
     }
}
