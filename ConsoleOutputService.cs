namespace Betriebsmittel.PrueffristenMonitor
{
    /// <summary>
    /// Stellt Methoden für die strukturierte Ausgabe der Geräte- und Prüfdaten in der Konsole bereit.
    /// </summary>
    internal class ConsoleOutputService
    {

        /// <summary>
        /// Gibt alle eingelesenen Geräte nach Prüfstatus gruppiert in der Konsole aus.
        /// </summary>
        /// <param name="alleDevice">Liste aller eingelesenen Geräte.</param>
        public static void AusgabeGesamt(List<Device> alleDevice)
        {

            AusgabeBlock(alleDevice, "Nicht geprüft");
            AusgabeBlock(alleDevice, "Überfällig");
            AusgabeBlock(alleDevice, "Bald fällig");
            AusgabeBlock(alleDevice, "Geprüft");
        }

        /// <summary>
        /// Gibt alle Geräte mit dem angegebenen Prüfstatus in einem eigenen Ausgabeblock in der Konsole aus.
        /// </summary>
        /// <param name="alleDevice">Liste aller eingelesenen Geräte.</param>
        /// <param name="status">Der Prüfstatus, nach dem die Geräte gefiltert und ausgegeben werden.</param>
        private static void AusgabeBlock(List<Device> alleDevice, string status)
        {
            bool statusvorhanden = false;
            foreach (Device geraet in alleDevice)
            {

                if (geraet.Status == status)
                {
                    statusvorhanden = true; break;
                }
            }
            if (statusvorhanden == true)
            {


                Console.WriteLine("");
                Console.WriteLine("=== " + status + " ===");
                string kopfzeile = ($"{"ID",-8}{"Bezeichnung",-25}{"Abteilung",-22}{"Prüfdatum",-12}{"Nächste Prüfung",-15}");
                Console.WriteLine(kopfzeile);
                Console.WriteLine(new string('-', kopfzeile.Length));

                foreach (Device geraet in alleDevice)
                {
                    string anzeigeBezeichnung = string.IsNullOrWhiteSpace(geraet.Bezeichnung) ? "-" : geraet.Bezeichnung;
                    string anzeigeAbteilung = string.IsNullOrWhiteSpace(geraet.Abteilung) ? "-" : geraet.Abteilung;
                    string anzeigePruefdatum = geraet.Pruefdatum.HasValue ? geraet.Pruefdatum.Value.ToString("dd.MM.yyyy") : "-";
                    string anzeigeNaechstePruefung = geraet.NaechstePruefung.HasValue ? geraet.NaechstePruefung.Value.ToString("dd.MM.yyyy") : "-";


                    if (geraet.Status == status)
                    {
                        Console.WriteLine($"{geraet.Id,-8}{anzeigeBezeichnung,-25}{anzeigeAbteilung,-22}{anzeigePruefdatum,-12}{anzeigeNaechstePruefung,-15}");
                    }
                }


            }
        }
    }
}