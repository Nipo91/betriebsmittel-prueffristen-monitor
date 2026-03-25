using Microsoft.Data.Sqlite;
using System.Collections.Generic;
namespace Betriebsmittel.PrueffristenMonitor
{
    internal class DeviceRepository
    {

        public static List<Device> GetDevices(string pfad)
        {
            // 1. Leere Liste anlegen
            List<Device> lGeraete = new List<Device>();
            // 2. Verbindung zur Datenbank öffnen
            try
            {
                string sqliteVerbindungsString = $"Data Source={pfad}";
                //Zugang zur DB
                using (var datenbankVerbindung = new SqliteConnection(sqliteVerbindungsString))
                {
                    //Öffnen der Verbindung 
                    datenbankVerbindung.Open();
                    Console.WriteLine("Datenbank erfolgreich geöffnet");

                    string sqlAbfrage = "SELECT Geraete_ID, Geraete_Bezeichnung, Geraete_Abteilung, Geraete_Pruefdatum, Geraete_Datum_Naechste_Pruefung, Geraete_Pruefintervall FROM Geraete";
                    //SQL-Auftrag
                    using (var command = new SqliteCommand(sqlAbfrage, datenbankVerbindung))
                    {
                        //Lieste Ergebniszeile
                        using (SqliteDataReader device = command.ExecuteReader())
                        {
                            //Alle Zeilen der Tabelle nach einander false wenn am ende 
                            while (device.Read())
                            {

                                var vgeraeteID = device["Geraete_ID"];
                                // Vorkonfigurierte Prüflinge überspringen
                                if (vgeraeteID == DBNull.Value) continue;
                                string geraeteID = vgeraeteID.ToString() ?? "";

                                string geraeteBezeichnung = device["Geraete_Bezeichnung"].ToString() ?? "";

                                string geraeteAbteilung = device["Geraete_Abteilung"].ToString() ?? "";

                                string sGeraetePruefdatum = device["Geraete_Pruefdatum"].ToString() ?? "";
                                DateTime? geraetePruefdatum = null;
                                if (sGeraetePruefdatum != "")
                                {
                                    geraetePruefdatum = DateTime.Parse(sGeraetePruefdatum);
                                }

                                string sGeraeteDatumNaechstePruefung = device["Geraete_Datum_Naechste_Pruefung"].ToString() ?? "";
                                DateTime? geraeteDatumNaechstePruefung = null;
                                if (sGeraeteDatumNaechstePruefung != "")
                                {
                                    geraeteDatumNaechstePruefung = DateTime.Parse(sGeraeteDatumNaechstePruefung);
                                }

                                string sgeraetePruefintervall = device["Geraete_Pruefintervall"].ToString() ?? "";

                                int geraetePruefintervall = int.Parse(sgeraetePruefintervall);

                                //Neues Device-Objekt erzeugen und der Liste hinzugefügt
                                lGeraete.Add(new Device(
                                    geraeteID,
                                    geraeteBezeichnung,
                                    geraeteAbteilung,
                                    geraetePruefdatum,
                                    geraeteDatumNaechstePruefung,
                                    geraetePruefintervall));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Es kam zu einem Fehler: {ex.Message}");

            }




            return lGeraete;








        }






    }
}