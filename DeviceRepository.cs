using Microsoft.Data.Sqlite;
namespace Betriebsmittel.PrueffristenMonitor
{
    internal class DeviceRepository
    {

        public static void Geraete(string pfad)
        {
            // 1. Leere Liste anlegen
            //List <Device> lGeraete = new List<Device>;
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

                    string sqlAbfrage = "SELECT * FROM Geraete";
                    //SQL-Auftrag
                    using (var command = new SqliteCommand(sqlAbfrage, datenbankVerbindung))
                    {
                        //Lieste Ergebniszeile
                        using (SqliteDataReader device = command.ExecuteReader())
                        {
                            //Alle Zeilen der Tabelle nach einander false wenn am ende 
                            while (device.Read())
                            {

                                var geraeteID = device["Geraete_ID"];
                                // Vorkonfigurierte Prüflinge überspringen
                                if (geraeteID == DBNull.Value) continue;
                                var geraeteBezeichnung = device["Geraete_Bezeichnung"];
                                var geraeteAbteilung = device["Geraete_Abteilung"];
                                var geraetePruefdatum = device["Geraete_Pruefdatum"];
                                var geraeteDatumNaechstePruefung = device["Geraete_Datum_Naechste_Pruefung"];
                                var geraetePruefintervall = device["Geraete_Pruefintervall"];
                                Console.WriteLine($"ID: {geraeteID}, Bezeichung: {geraeteBezeichnung}, Abteilung: {geraeteAbteilung}, Prüfdatum: {geraetePruefdatum}, Nächste Prüfung: {geraeteDatumNaechstePruefung}, Prüfintervall: {geraetePruefintervall}");
                            }
                        }
                    }

                }
            }
            catch
            {
                Console.WriteLine("Es kam zu einem Fehler");

            }







            // 5.1 Neues Device-Objekt erzeugen
            // 5.2 Spaltenwerte aus der aktuellen Zeile lesen
            // 5.3 Werte dem Device zuweisen
            // 5.4 Device zur Liste hinzufügen

            // 6. Liste zurückgeben

        }






    }
}