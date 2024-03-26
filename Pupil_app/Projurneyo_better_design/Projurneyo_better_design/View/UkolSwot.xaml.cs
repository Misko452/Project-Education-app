using Projurneyo_better_design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public partial class UkolSwot : UserControl
    {
        public UkolSwot(string zadani, int idUkolu, int idTymu)
        {
            InitializeComponent();

            Zadani.Text = zadani;
            this.idUkolu = idUkolu;
            this.idTymu = idTymu;
            komunikace = new Komunikace();
            dbManager = new DatabaseManager();
        }

        int idTymu = 0;
        int idUkolu = 0;
        string name = "";
        Paragraph paragraph;
        Komunikace komunikace;
        DatabaseManager dbManager;
        string pomocnyText;

        private void Potvrd_Click(object sender, RoutedEventArgs e)
        {
           string s = new TextRange(S.Document.ContentStart, S.Document.ContentEnd).Text;
           string w = new TextRange(W.Document.ContentStart, W.Document.ContentEnd).Text;
           string o = new TextRange(O.Document.ContentStart, O.Document.ContentEnd).Text;
           string t = new TextRange(T.Document.ContentStart, T.Document.ContentEnd).Text;

           if (s != "Silné stránky..." && w != "Slabé stránky..." && o != "Příležitosti..."
                && t != "Hrozby...")
           {
                string vysledek = s + ";;;;;" + w + ";;;;;" + o + ";;;;;" + t;
                komunikace.UlozText(vysledek, idUkolu);
                dbManager.PridejAlert(idUkolu, idTymu, vysledek);
                Potvrd.IsEnabled = false;
                S.IsEnabled = false;
                W.IsEnabled = false;
                O.IsEnabled = false;
                T.IsEnabled = false;
            }
        }

        public void RT_GotFocus(object sender, RoutedEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            richTextBox.Foreground = stetec;
            if (richTextBox.Document.Blocks.Count > 0)
            {
                pomocnyText = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
                
                if (pomocnyText == "Silné stránky...\r\n" || pomocnyText == "Slabé stránky...\r\n" ||
                    pomocnyText == "Příležitosti...\r\n" || pomocnyText == "Hrozby...\r\n")
                {
                    richTextBox.Document.Blocks.Clear();
                }
            }
        }

        public void RT_LostFocus(object sender, RoutedEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF868686"));
            richTextBox.Foreground = stetec;
            name = richTextBox.Name;
            if (richTextBox.Document.Blocks.Count == 0)
            {
                paragraph = new Paragraph();

                switch (name)
                {
                    case "S":
                        paragraph.Inlines.Add("Silné stránky...");
                        break;
                    case "W":
                        paragraph.Inlines.Add("Slabé stránky...");
                        break;
                    case "O":
                        paragraph.Inlines.Add("Příležitosti...");
                        break;
                    case "T":
                        paragraph.Inlines.Add("Hrozby...");
                        break;
                }
                richTextBox.Document.Blocks.Add(paragraph);
            }
        }

        
    }
}
