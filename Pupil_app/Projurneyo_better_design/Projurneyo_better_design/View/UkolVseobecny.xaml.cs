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
    public partial class UkolVseobecny : UserControl
    {
        public UkolVseobecny(string zadani, int idUkolu, int idTymu)
        {
            InitializeComponent();

            this.zadani = zadani;
            TxtBxpopisUkolu.Text = zadani;
            this.idUkolu = idUkolu;
            this.idTymu = idTymu;
            dbManager = new DatabaseManager();
        }

        string zadani;
        int idUkolu = 0;
        int idTymu = 0;
        DatabaseManager dbManager;

        public void Potvrdit_Click(object sender, EventArgs a)
        {
            dbManager.PridejAlert(idUkolu, idTymu, zadani + "Splnili jsme zadání, posuďte prosím výsledek");
            dbManager.SplnUkol(idUkolu);
            Potvrdit.IsEnabled = false;
        }
    }
}