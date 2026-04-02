namespace Betriebsmittel.PrueffristenMonitor
{
    internal class ConsoleOutputService
    {
        public static void AusgabeGesamt(List<Device> alleDevice)
        {

            AusgabeBlock(alleDevice, "Nicht geprüft");
            AusgabeBlock(alleDevice, "Überfällig");
            AusgabeBlock(alleDevice, "Bald fällig");
            AusgabeBlock(alleDevice, "Geprüft");
        }

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