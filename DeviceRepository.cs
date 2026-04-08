using Microsoft.Data.Sqlite;
using System.Collections.Generic;
namespace Betriebsmittel.PrueffristenMonitor
{
    /// <summary>
    /// Stellt Methoden zum Lesen von Gerätedaten aus einer SQLite-Datenbank bereit.
    /// </summary>
    internal class DeviceRepository
    {
        /// <summary>
        /// Liest die Gerätedaten aus der Tabelle Geraete der angegebenen SQLite-Datenbank
        /// und erstellt daraus eine Liste von Device-Objekten.
        /// </summary>
        /// <param name="pfad">Pfad zur Benning-Datenbankdatei</param>
        /// <returns>Liste der eingelesenen Geräte</returns>
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
                                if (DateTime.TryParse(sGeraetePruefdatum, out DateTime gelesenesPruefdatum))
                                {
                                    geraetePruefdatum = gelesenesPruefdatum;
                                }

                                string sGeraeteDatumNaechstePruefung = device["Geraete_Datum_Naechste_Pruefung"].ToString() ?? "";
                                DateTime? geraeteDatumNaechstePruefung = null;

                                if (DateTime.TryParse(sGeraeteDatumNaechstePruefung, out DateTime gelesenesNaechstesPruefdatum))
                                {
                                    geraeteDatumNaechstePruefung = gelesenesNaechstesPruefdatum;
                                }

                                string sgeraetePruefintervall = device["Geraete_Pruefintervall"].ToString() ?? "";

                                int geraetePruefintervall = 0;

                                if (int.TryParse(sgeraetePruefintervall, out int gelesenesPruefintervall))
                                {
                                    geraetePruefintervall = gelesenesPruefintervall;
                                }

                                // Device-Objackt erzeugen 
                                Device geraet = new Device(geraeteID,
                                    geraeteBezeichnung,
                                    geraeteAbteilung,
                                    geraetePruefdatum,
                                    geraeteDatumNaechstePruefung,
                                    geraetePruefintervall);
                                // Stautus Berechnen und im Objeckt speichern
                                geraet.Status = DeviceStatusService.GetStatus(geraet);

                                //Neues Device-Objekt der Liste hinzugefügt
                                lGeraete.Add(geraet);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der Gerätedaten aus der Datenbank: {ex.Message}");

            }

            return lGeraete;








        }






    }
}