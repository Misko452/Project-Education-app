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
            mainwindow.control.Content = seznamprojektu;
            mainwindow.aktualniStranka = "Projects";
        } 

        public void SwitchniNaNovyProjekt(NovyProjekt novyprojekt)
        {
            mainwindow.control.Content = novyprojekt;
            mainwindow.aktualniStranka = "NewProject";
        }

        public void SwitchniNaNPUkoly(NPUkoly tvorbaukolu)
        {
            mainwindow.control.Content = tvorbaukolu;
            mainwindow.aktualniStranka = "NewTask";
        }

        public void SwitchniNaTymy(Tym tym)
        {
            mainwindow.control.Content = tym;
            mainwindow.aktualniStranka = "Teams";
        }

        public void SwitchniLogin(Login login)
        {
            mainwindow.control.Content = login;
        }

        public void SwitchniRegister(Register register)
        {
           mainwindow.control.Content = register;
        }

        public void SwitchniVnitrekProjektu(ProjektInside vnitrekprojektu)
        {
            mainwindow.control.Content = vnitrekprojektu;
            mainwindow.aktualniStranka = "ProjectInside";
        }

        public void SwitchniTextUkol(UkolText text)
        {
            mainwindow.control.Content = text;
            mainwindow.aktualniStranka = "TaskInside";
        }

        public void SwitchniSWOTUkol(UkolSwot swotka)
        {
            mainwindow.control.Content = swotka;
            mainwindow.aktualniStranka = "TaskInside";
        }

        public void SwitchniLibovolny(UkolVseobecny cokoliv)
        {
            mainwindow.control.Content = cokoliv;
            mainwindow.aktualniStranka = "TaskInside";
        }

        public void SwitchniSoubor(UkolSoubor soubor)
        {
            mainwindow.control.Content = soubor;
            mainwindow.aktualniStranka = "TaskInside";
        }

        public void SwitchniNaZebricek(Leaderboard zebricek)
        {
            mainwindow.control.Content = zebricek;
            mainwindow.aktualniStranka = "Leaderboard";
        }


        public NavigaceVProgramu(Prihlaseni mainwindow)
        {
            this.mainwindow = mainwindow;
        }
     }
}
