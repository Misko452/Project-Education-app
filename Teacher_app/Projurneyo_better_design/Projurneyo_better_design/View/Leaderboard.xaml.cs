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
    public partial class Leaderboard : UserControl
    {
        public Leaderboard()
        {
            InitializeComponent();

            try
            {
                dbManager = new DatabaseManager();

                GridViewColumn sloupec1 = new GridViewColumn();
                GridViewColumn sloupec2 = new GridViewColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        List<string> tymy;
        DatabaseManager dbManager;
        int idTridy = 0;
        GridViewColumn sloupec2;
        GridViewColumn sloupec1;

        public void NactiZebricek()
        {
            try
            {
                tymy = dbManager.NactiTymy();

                foreach (var s in tymy)
                {
                    string[] rozdelovac = s.Split(';');
                    ListBx.Items.Add(new { Nazev = rozdelovac[0], Xp = rozdelovac[1] + " XP" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
