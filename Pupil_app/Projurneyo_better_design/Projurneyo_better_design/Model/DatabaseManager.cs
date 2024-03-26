using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Projurneyo_better_design
{
    internal class DatabaseManager
    {
        public DatabaseManager() 
        {
            sestavovac = new SqlConnectionStringBuilder();
            sestavovac.DataSource = @"Projurneyo_data.mssql.somee.com";
            sestavovac.InitialCatalog = "Projurneyo_data";
            sestavovac.UserID = "adminMisko_SQLLogin_1";
            sestavovac.Password = "rrdhhkp75f";
        } 

        public string[] OverUzivatele(string uzjmeno, string heslo)
        {
            string[] output = new string[5];

            try
            {
                output[0] = "false";

                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select Heslo from Zak where UzJmeno = '" + uzjmeno + "' and Heslo = '" + heslo + "'";

                    string pomocneheslo = prikaz.ExecuteScalar() as string;

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "select UzJmeno from Zak where UzJmeno = '" + uzjmeno + "' and Heslo = '" + heslo + "'";

                    string pomocnejmeno = prikaz.ExecuteScalar() as string;

                    pripojeni.Close();
                    pripojeni.Open();

                    if (pomocneheslo != null && pomocnejmeno != null)
                    {
                        output[0] = "true";
                        output[1] = pomocnejmeno;

                        prikaz.CommandText = "select * from Zak where UzJmeno = '" + uzjmeno + "' and Heslo = '" + heslo + "'";

                        ctecka = prikaz.ExecuteReader();

                        while (ctecka.Read())
                        {
                            output[2] = ctecka[3].ToString();
                            output[3] = ctecka[0].ToString();
                            if (ctecka[4].ToString() == "")
                            {
                                output[4] = "0";
                            }
                            else
                            {
                                output[4] = ctecka[4].ToString();
                            }
                        }

                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return output;
        }       

        public void PridejUsera(string typ, string jmeno, string heslo)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "INSERT INTO Zak(UzJmeno, Heslo) VALUES(@UzJmeno, @Heslo)";

                    //Z důvodu bezpečnosti se data přidávají formou parametrů
                    prikaz.Parameters.AddWithValue("@UzJmeno", jmeno);
                    prikaz.Parameters.AddWithValue("@Heslo", heslo);

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void PridejProjekt(string nazev, string popis, int tym)
        {
            bool proslo = true;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;
                    //Projekty je složitější indexově odlišit a koncept umožňuje kreativní názvy, proto se názvy nesmí opakovat.
                    prikaz.CommandText = "select * from Projekty where Nazev = '" + nazev + "' and Tym =" + tym;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        proslo = false;
                    }

                    pripojeni.Close();
                    pripojeni.Open();

                    if (proslo)
                    {
                        prikaz.CommandText = "INSERT INTO Projekty(Nazev, Zadani, Hotovo, Tym) VALUES(@Nazev, @Zadani, @Hotovo, @Tym)";

                        prikaz.Parameters.AddWithValue("@Nazev", nazev);
                        prikaz.Parameters.AddWithValue("@Zadani", popis);
                        prikaz.Parameters.AddWithValue("@Hotovo", 0);
                        prikaz.Parameters.AddWithValue("@Tym", tym);

                        int ovlivneneradky = prikaz.ExecuteNonQuery();

                        pripojeni.Close();
                    }
                    else MessageBox.Show("Zvolte jiný název projektu, projekt s tímto názvem už existuje", "POZOR", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void PridejUkol(string nazev, string TypOdevzdani, int Idporojektu)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "insert into Ukoly(Nazev, Typ_odevzdani, Idprojektu, Hotovo) values (@Nazev, @Typ_odevzdani, @Idprojektu, @Hotovo)";

                    prikaz.Parameters.AddWithValue("@Nazev", nazev);
                    prikaz.Parameters.AddWithValue("@Typ_odevzdani", TypOdevzdani);
                    prikaz.Parameters.AddWithValue("@Idprojektu", Idporojektu);
                    prikaz.Parameters.AddWithValue("@Hotovo", 0);

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void PridejAlert(int idUkolu, int idTymu, string messaage)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "insert into Alerty(IdUkolu, IdTymu, Message)" +
                        " values (@IdUkolu, @IdTymu, @Message)";

                    prikaz.Parameters.AddWithValue("@IdUkolu", idUkolu);
                    prikaz.Parameters.AddWithValue("@IdTymu", idTymu);
                    prikaz.Parameters.AddWithValue("@Message", messaage);

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void PriradUkol(int idProjektu, int idZaka, string nazevUkolu)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "update Ukoly set IdPrirazeno= " + idZaka +
                        " where idProjektu= " + idProjektu + " and Nazev='" + nazevUkolu +
                        "'";

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void OdradUkol(int idProjektu, string nazevUkolu)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "update Ukoly set IdPrirazeno= null where idProjektu= "
                        + idProjektu + " and Nazev='" + nazevUkolu +
                        "'";

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string> NactiTymy(int idTridy)
        {
            List<string> tymy = new List<string>();

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select * from Tymy where IdTridy= " + idTridy + " order by Xp desc";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        tymy.Add(ctecka[1].ToString() + ";" + ctecka[4].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return tymy;
        }

        public List<string> NactiTridy()
        {
            List<string> tridy = new List<string>();

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select * from Tridy";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        tridy.Add(ctecka[1].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return tridy;
        }

        public List<string> NactiProjekty(int idtridy)
        {
            List<string> projekty = new List<string>();

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select * from Projekty where Tym= " + idtridy;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        projekty.Add(ctecka[0].ToString() + ";" + ctecka[1].ToString() + ";" + ctecka[2].ToString() + ";" + ctecka[3].ToString() + ";" +
                            ctecka[4].ToString());
                    }

                    pripojeni.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return projekty;
        }

        public List<string> NactiUkoly(int idProjektu, int idZaka)
        {
            List<string> ukoly = new List<string>();

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select * from Ukoly where Idprojektu= " + idProjektu + " and IdPrirazeno= " + idZaka + " and Hotovo= 0";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        ukoly.Add(ctecka[0].ToString() + ";" + ctecka[1].ToString() + ";" + ctecka[2].ToString()
                            + ";" + ctecka[3].ToString() + ";" + ctecka[4].ToString() + ";" +
                            ctecka[5].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return ukoly;
        }

        public List<string> NactiZaky(int idTymu)
        {
            List<string> zaci = new List<string>();

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select * from Zak where IdTymu= " + idTymu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        zaci.Add(ctecka[1].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return zaci;
        }

        public List<string> NactiVsechnyUkoly(int idProjektu)
        {
            List<string> tasky = new List<string>();

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select * from Ukoly where Hotovo = 0 and Idprojektu= " + idProjektu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        tasky.Add(ctecka[0].ToString() + ";" + ctecka[1].ToString() + ";" + ctecka[2].ToString()
                            + ";" + ctecka[3].ToString() + ";" + ctecka[4].ToString() + ";" +
                            ctecka[5].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return tasky;
        }

        public void SplnUkol(int idUkolu)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "update Ukoly set Hotovo=1 where Id = " + idUkolu;

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
        public int ZjistiIdUkolu(string nazev, int idProjektu)
        {
            int idUkol = 0;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Ukoly where Nazev= '" + nazev + "' and IdProjektu= " + idProjektu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        idUkol = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return idUkol;
        }

        public int ZjistiKapitan(int idZaka)
        {
            int result = 0;
            List<string> pomocnylist = new List<string>();

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select * from Tymy where KapitanId = " + idZaka.ToString();

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        pomocnylist.Add(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (pomocnylist.Count > 0)
            {
                return result = 1;
            }
            else return result = 0;
        }

        public int ZjistiIdZakaPodleTymu(string jmeno, int idTymu)
        {
            int idZak = 0;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Zak where UzJmeno= '" + jmeno + "' and Idtymu= " + idTymu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        idZak = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return idZak;
        }
            

        public int ZjistiIdZaka(string jmeno, int idTridy)
        {
            int idZak = 0;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Zak where UzJmeno= '" + jmeno + "' and Idtridy= " + idTridy;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        idZak = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return idZak;
        }    

        public int ZjistiIdTymZaka(int idZaka)
        {
            int vysledek = 0;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Tymy where KapitanId = " + idZaka;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        vysledek = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return vysledek;
        }

        public int ZjistiIdProjektZNazvu(string nazev)
        {
            int vysledek = 0;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Projekty where Nazev = '" + nazev + "'";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        vysledek = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return vysledek;
        }  

        public int ZjistiIdProjekt(string nazev, string popis)
        {
            int vysledek = 0;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Projekty where Nazev = '" + nazev + "' and Zadani = '"
                        + popis + "'";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        vysledek = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return vysledek;
        }

        public int ZjistiIdTymuZProjektu(string nazev)
        {
            int vysledek = 0;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select Tym from Projekty where Nazev = '" + nazev + "'";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        vysledek = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return vysledek;
        }

        private SqlConnectionStringBuilder sestavovac;
        private SqlConnection pripojeni;
        private SqlCommand prikaz;
        private SqlDataReader ctecka;
    }
}
