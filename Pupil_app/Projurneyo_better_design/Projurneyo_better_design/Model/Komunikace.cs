using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Projurneyo_better_design.Model
{
    class Komunikace
    {

        public Komunikace()
        {
            dbManager = new DatabaseManager();
            adresa = "ftp://ftp5.webzdarma.cz/Projurneyo_projekty/";
        }

        string adresa = "";
        string username = "projurneyo.borec.cz";
        string pass = "Uloziste624";

        WebClient client;
        DatabaseManager dbManager;

        public async void UlozText(string text, int idUkolu)
        {
            try
            {
                string cesta = Path.Combine(Environment.CurrentDirectory, "textak.txt");

                File.WriteAllText
                    (cesta, text);

                adresa += idUkolu.ToString() + ".txt";

                using (client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(username, pass);
                    client.UploadFile(adresa, WebRequestMethods.Ftp.UploadFile, cesta);
                }

                File.WriteAllText
                    (cesta, "");

                dbManager.SplnUkol(idUkolu);

                MessageBox.Show("Odpověď byla odeslána k hodnocení", "Odevzdáno",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }    

        public async void UlozSoubor(string soubor, int idUkolu, byte[] buffer, string[] pripona)
        {
            try
            {
                string cesta = soubor;

                int byty = 0;

                adresa += idUkolu.ToString() + "." + pripona[1];

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(adresa);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, pass);
                request.KeepAlive = true;
                request.UseBinary = true;

                Stream reqstream = request.GetRequestStream();
                while (byty <= buffer.Length)
                {
                    reqstream.Write(buffer, 0, buffer.Length);
                    byty += buffer.Length;
                }
                reqstream.Close();

                dbManager.SplnUkol(idUkolu);

                MessageBox.Show("Odpověď byla odeslána k hodnocení", "Odevzdáno", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                adresa = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
