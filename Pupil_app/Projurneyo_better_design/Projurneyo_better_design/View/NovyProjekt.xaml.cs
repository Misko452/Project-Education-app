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
    public partial class NovyProjekt : UserControl
    {
        public NovyProjekt(string NazevOrg, Prihlaseni mainwindow, int idZaka)
        {
            InitializeComponent();
            navigace = new NavigaceVProgramu(mainwindow);
            this.idZaka = idZaka;   
            this.mainwindow = mainwindow;
        }

        NavigaceVProgramu navigace;
        NPUkoly tvorukoly;
        Prihlaseni mainwindow;
        Paragraph paragraph;

        string nazev = "";
        string popis = "";
        string trida = "";

        string pomocnyText = "";

        int idZaka = 0;

        public void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            nazev = TextBoxNazev.Text;
            popis = new TextRange(RTpopis.Document.ContentStart, RTpopis.Document.ContentEnd).Text;

            tvorukoly = new NPUkoly(nazev, popis, idZaka, mainwindow);

            navigace.SwitchniNaNPUkoly(tvorukoly);  
        }

        private void TextBoxNazev_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Název projektu...")
            {
                textBox.Text = "";
                var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                textBox.Foreground = stetec;
            }
        }

        private void TextBoxNazev_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Název projektu...";
                var stetec = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF868686"));
                textBox.Foreground = stetec;
            }
        }

        private void RTpopis_GotFocus(object sender, RoutedEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            pomocnyText = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            if (pomocnyText == "Popiš projekt zde...\r\n" && richTextBox.Document.Blocks.Count > 0)
            {
                richTextBox.Document.Blocks.Clear();
            }
        }

        private void RTpopis_LostFocus(object sender, RoutedEventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            if (richTextBox.Document.Blocks.Count == 0)
            {
                paragraph = new Paragraph();
                paragraph.Inlines.Add("Popiš projekt zde...");
                richTextBox.Document.Blocks.Add(paragraph);
            }    
        }
    }
}
