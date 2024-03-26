using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Projurneyo_better_design.Utilities
{
    public class Btn : RadioButton
    {
        static Btn()
        {
            try
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(Btn)
    , new FrameworkPropertyMetadata(typeof(Btn)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
