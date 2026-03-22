using Microsoft.Data.Sqlite;

namespace Betriebsmittel.PrueffristenMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Betriebsmittel Prüffristen Monitor DGUV V3 ===");

            string? datenPfad;

            // Wiederholt und Prüft die Eingabe, bis der Benutzer einen gültigen Dateipfad zu einer .db-Datei eingibt.
            while (true)
            {
                Console.WriteLine("Bitte geben Sie den Dateipfad zur gewünschten Prüflingsdatenbank .db ein.");
                Console.WriteLine(@"Beispiel C:\Users\<Benutzername>\Documents\Benning\FirmaXy.db");

                datenPfad = Console.ReadLine() ?? "";


                if (string.IsNullOrWhiteSpace(datenPfad))
                {
                    Console.WriteLine("Sie haben keine Eingabe gemacht.");

                }
                else if (!datenPfad.EndsWith(".db"))
                {
                    Console.WriteLine("Die Datei muss auf .db enden.");
                }

                else if (!File.Exists(datenPfad))
                {
                    Console.WriteLine("Die Datei wurde nicht gefunden.");

                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Datei gefunden");
            DatenbankOeffnen(datenPfad);

        }
        /// <summary>
        /// Prüft, ob sich die angegebene .db-Datei erfolgreich als SQLite-Datenbank öffnen lässt.
        /// </summary>
        /// <param name="pfad">Dateipfad zur zu prüfenden .db-Datei.</param>
        /// <returns>true, wenn die Datenbank erfolgreich geöffnet werden konnte; andernfalls false.</returns>
        public static bool DatenbankOeffnen(string pfad)
        {
            try
            {
                string sqliteVerbindungsString = $"Data Source={pfad}";
                using (SqliteConnection datenbankVerbindung = new SqliteConnection(sqliteVerbindungsString))
                {
                    datenbankVerbindung.Open();
                    Console.WriteLine("Datenbank erfolgreich geöffnet");
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Es kam zu einem Fehler");
                return false;
            }

        }


    }
}
