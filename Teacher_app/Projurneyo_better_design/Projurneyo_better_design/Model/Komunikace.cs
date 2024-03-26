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
using System.Windows.Documents;
using Microsoft.Win32;

namespace Projurneyo_better_design.Model
{
    class Komunikace
    {

        public Komunikace()
        {
            dbManager = new DatabaseManager();
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
                string cesta = Path.Combine(Environment.CurrentDirectory, @"PomocneSoubory\", "textak.txt");

                File.WriteAllText
                    (cesta, text);

                adresa += idUkolu.ToString();

                using (client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(username, pass);
                    client.UploadFile(adresa, WebRequestMethods.Ftp.UploadFile, cesta);
                }

                File.WriteAllText
                    (cesta, "");

                dbManager.SplnUkol(idUkolu);

                MessageBox.Show("Odpověď byla odeslána k hodnocení", "Odevzdáno", MessageBoxButton.OK, MessageBoxImage.Information);


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
                adresa = "ftp://ftp5.webzdarma.cz/Projurneyo_projekty/";
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

                MessageBox.Show("Odpověď byla odeslána k hodnocení", "Odevzdáno", MessageBoxButton.OK, MessageBoxImage.Information);
                adresa = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string> NactiSoubory()
        {
            List<string> list = new List<string>();

            try
            {
                adresa = "ftp://ftp5.webzdarma.cz/Projurneyo_projekty/";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(adresa);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, pass);

                FtpWebResponse odpoved = (FtpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(odpoved.GetResponseStream());
                string soubory = reader.ReadToEnd();
                reader.Close();
                odpoved.Close();

                list = soubory.Split('\n').ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public string NactiTextSoubor(string nazev)
        {
            string obsahsouboru = "";

            try
            {
                adresa = "ftp://ftp5.webzdarma.cz/Projurneyo_projekty/" + nazev;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(adresa);
                request.Credentials = new NetworkCredential(username, pass);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse odpoved = (FtpWebResponse)request.GetResponse();
                StreamReader ctecka = new StreamReader(odpoved.GetResponseStream());

                obsahsouboru = ctecka.ReadToEnd();

                ctecka.Close();
                odpoved.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return obsahsouboru;
        }

        public void StahniSoubor(string soubor)
        {
            try
            {
                adresa = "ftp://ftp5.webzdarma.cz/Projurneyo_projekty/" + soubor;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(adresa);
                request.Credentials = new NetworkCredential(username, pass);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UseBinary = true;
                request.KeepAlive = true;
                request.UsePassive = true;

                FtpWebResponse odpoved = (FtpWebResponse)request.GetResponse();
                StreamReader ctecka = new StreamReader(odpoved.GetResponseStream());

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "All Files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.FileName = soubor;
                dialog.ShowDialog();
                string cesta = dialog.FileName;

                if (cesta != "")
                {
                    using (FileStream writer = new FileStream(cesta, FileMode.Create))
                    {
                        long delka = odpoved.ContentLength;
                        int bufferSize = 2048;
                        byte[] buffer = new byte[2048];

                        int pocetcteni = odpoved.GetResponseStream().Read(buffer, 0, bufferSize);
                        while (pocetcteni > 0)
                        {
                            writer.Write(buffer, 0, pocetcteni);
                            pocetcteni = odpoved.GetResponseStream().Read(buffer, 0, bufferSize);
                        }
                    }
                }
      
                ctecka.Close();
                odpoved.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
