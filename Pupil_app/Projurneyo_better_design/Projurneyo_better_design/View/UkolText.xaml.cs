using Projurneyo_better_design.Model;
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
    public partial class UkolText : UserControl
    {
        public UkolText(string zadani, int idUkolu, int idTymu)
        {
            InitializeComponent();
            this.idUkolu = idUkolu;
            this.idTymu = idTymu;
            Zadani.Text = zadani;
            com = new Komunikace();
            dbManager = new DatabaseManager();
            Potvrdit.IsEnabled = true;
            Odpoved.IsEnabled = true;
        }

        string zadanytext = "";
        int idTymu = 0;
        int idUkolu = 0;
        string pomocnyText = "";
        Paragraph paragraph;
        Komunikace com;
        DatabaseManager dbManager;

        private void Potvrdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                zadanytext = new TextRange(Odpoved.Document.ContentStart, Odpoved.Document.ContentEnd).Text;
                com.UlozText(zadanytext, idUkolu);
                dbManager.PridejAlert(idUkolu, idTymu, zadanytext);
                Potvrdit.IsEnabled = false;
                Odpoved.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Odpoved_GotFocus(object sender, RoutedEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            pomocnyText = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            if (pomocnyText == "Napiš odpověď...\r\n" && richTextBox.Document.Blocks.Count > 0)
            {
                richTextBox.Document.Blocks.Clear();
            }
        }

        public void Odpoved_LostFocus(object sender, RoutedEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            if (richTextBox.Document.Blocks.Count == 0)
            {
                paragraph = new Paragraph();
                paragraph.Inlines.Add("Napiš odpověď...");
                richTextBox.Document.Blocks.Add(paragraph);
            }
        }

        
    }
}
