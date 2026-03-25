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
            Console.WriteLine(DeviceRepository.GetDevices(datenPfad));

        }



    }
}
