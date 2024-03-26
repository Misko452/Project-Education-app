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
        public Leaderboard(int idTridy)
        {
            InitializeComponent();
            
            dbManager = new DatabaseManager();
            this.idTridy = idTridy;
        }

        List<string> tymy;
        DatabaseManager dbManager;
        int idTridy = 0;

        public void NactiZebricek()
        {
            try
            {
                tymy = dbManager.NactiTymy(idTridy);

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
