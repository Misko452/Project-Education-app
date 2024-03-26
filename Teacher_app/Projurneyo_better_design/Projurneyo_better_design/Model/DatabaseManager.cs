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

        private SqlConnectionStringBuilder sestavovac;
        private SqlConnection pripojeni;
        private SqlCommand prikaz;
        private SqlDataReader ctecka;

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

                    prikaz.CommandText = "select Heslo from Ucitele where UzJmeno = '" + uzjmeno + "' and Heslo = '" + heslo + "'";

                    string heheslo = prikaz.ExecuteScalar() as string;

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "select UzJmeno from Ucitele where UzJmeno = '" + uzjmeno + "' and Heslo = '" + heslo + "'";

                    string uzzjmeno = prikaz.ExecuteScalar() as string;

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "select * from Ucitele where UzJmeno = '" + uzjmeno + "' and Heslo = '" + heslo + "'";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        output[3] = ctecka[0].ToString();
                    }

                    if (heheslo != null && uzzjmeno != null)
                    {
                        output[0] = "true";
                        output[1] = uzzjmeno;

                    }
                    else
                    {
                        MessageBox.Show("Zadané přihlašovací údaje jsou nesprávné", 
                            "CHYBA", MessageBoxButton.OK, MessageBoxImage.Error);
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

                    prikaz.CommandText = "INSERT INTO Ucitele(UzJmeno, Heslo) VALUES(@UzJmeno, @Heslo)";

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

        public void PridejTym(string nazev, string nazevTridy)
        {
            try
            {
                int idTridy = 0;

                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Tridy where NazevTridy= '" + nazevTridy + "'";

                    ctecka = prikaz.ExecuteReader();
                    while (ctecka.Read())
                    {
                        idTridy = (int)ctecka[0];
                    }

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "insert into Tymy(Nazev, KapitanId, IdTridy, Xp) values (@Nazev, @KapitanId, @IdTridy, @Xp)";

                    prikaz.Parameters.AddWithValue("@Nazev", nazev);
                    prikaz.Parameters.AddWithValue("@KapitanId", DBNull.Value);
                    prikaz.Parameters.AddWithValue("@IdTridy", idTridy);
                    prikaz.Parameters.AddWithValue("@Xp", 0);

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void OdstranTym(string vybrany)
        {
            try
            {
                int IdTymu = 0;

                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Tymy where Nazev= '" + vybrany + "'";

                    ctecka = prikaz.ExecuteReader();
                    while (ctecka.Read())
                    {
                        IdTymu = (int)ctecka[0];
                    }

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "update Projekty set Tym = NULL where Tym = " + IdTymu;
                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "update Zak set IdTymu = NULL where IdTymu = " + IdTymu;

                    ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "delete from Tymy where Id = " + IdTymu;

                    ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ZamitniSplneni(int idUkolu)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "update Ukoly set hotovo = 0 where Id=" + idUkolu;

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "delete from Alerty where IdUkolu=" + idUkolu;

                    ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void PotvrdSplneni(int idUkolu, int xp, int idTymu)
        {
            try
            {
                bool hotovo = true;
                int idProjektu = 0;

                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select IdProjektu from Ukoly where Id= " + idUkolu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        idProjektu = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "select Hotovo from Ukoly where Idprojektu=" + idProjektu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        if (ctecka[0].ToString() == "0")
                        {
                            hotovo = false;
                        }
                    }

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "select Xp from Tymy where Id=" + idTymu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        xp += int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                    pripojeni.Open();

                    if (hotovo == true)
                    {
                        xp += 350;
                    }

                    prikaz.CommandText = "update Tymy set Xp = " + xp + " where Id=" + idTymu;

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "delete from Alerty where IdUkolu=" + idUkolu + " and IdTymu=" + idTymu;

                    ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string ZjistiZadaniZId(int idUkolu)
        {
            string vysledek = "";

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select Nazev from Ukoly where Id= " + idUkolu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        vysledek = ctecka[0].ToString();
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

        public string ZjistiTypUkoluZID(int idUkolu)
        {
            string vysledek = "";

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select Typ_odevzdani from Ukoly where Id= " + idUkolu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        vysledek = ctecka[0].ToString();
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

        public string ZjistiNazevTymuZId(int idTymu)
        {
            string vysledek = "";

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select Nazev from Tymy where Id= " + idTymu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        vysledek = ctecka[0].ToString();
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

        public List<string> NactiAlerty(int idTymu)
        {
            List<string> alerty = new List<string>();

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select * from Alerty where IdTymu= " + idTymu;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        alerty.Add(ctecka[0].ToString() + ":" + ctecka[1].ToString() +
                            ":" + ctecka[2].ToString() + ":" + ctecka[3].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return alerty;
        }

        public List<string> NactiTymyID(int idTridy)
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

                    prikaz.CommandText = "select * from Tymy where IdTridy= " + idTridy;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        tymy.Add(ctecka[0].ToString() + ";" + ctecka[1].ToString());
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

        public List<string> NactiTymy()
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

                    prikaz.CommandText = "select * from Tymy order by Xp desc";

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

        public List<string> NactiUcitelovoTridy(int idUcitele)
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

                    prikaz.CommandText = "select * from Tridy where IdUcitele= " + idUcitele;

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        tridy.Add(ctecka[0].ToString() + ";" + ctecka[1].ToString());
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

        public List<string> NactiTridy(int idUcitele)
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

                    prikaz.CommandText = "select * from Tridy where IdUcitele= " + idUcitele;

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

        public void ZvolVelitele(int idvelitel, int idTymu)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "update Tymy set KapitanId = " + idvelitel + " where Id = " + idTymu;

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void PriradZakaTymu(string vybranyzak, int idTymu)
        {
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "update Zak set IdTymu = " + idTymu + " where UzJmeno = '" + vybranyzak + "'";

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void OdstranZakaZTymu(string vybranyzak, int idTymu)
        {
            int idZaka = 0;
            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select Id from Zak where IdTymu = " + idTymu + " and UzJmeno = '" + vybranyzak + "'";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        idZaka = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "update Zak set IdTymu = null where UzJmeno = '" + vybranyzak + "'";

                    int ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "update Tymy set KapitanId = null where KapitanId = " + idZaka;

                    ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                    pripojeni.Open();

                    prikaz.CommandText = "update Ukoly set IdPrirazeno = null where IdPrirazeno = " + idZaka;

                    ovlivneneradky = prikaz.ExecuteNonQuery();

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string> NactiZakyBezTymu(int idTridy)
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

                    prikaz.CommandText = "select * from Zak where IdTymu is null and Idtridy= " + idTridy;

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

        public int ZjistiIdTridy(string nazev)
        {
            int idTrida = 0;

            try
            {
                pripojeni = new SqlConnection(sestavovac.ConnectionString);
                prikaz = new SqlCommand();

                using (pripojeni)
                {
                    pripojeni.Open();
                    prikaz.Connection = pripojeni;

                    prikaz.CommandText = "select id from Tridy where NazevTridy= '" + nazev + "'";

                    ctecka = prikaz.ExecuteReader();

                    while (ctecka.Read())
                    {
                        idTrida = int.Parse(ctecka[0].ToString());
                    }

                    pripojeni.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NEČEKANÁ CHYBA!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return idTrida;
        }        


    }
}
