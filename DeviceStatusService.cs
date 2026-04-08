namespace Betriebsmittel.PrueffristenMonitor
{
    /// <summary>
    /// Enthält die Fachlogik zur Bewertung des Prüfstatus eines Geräts.
    /// </summary>
    internal class DeviceStatusService
    {
        /// <summary>
        /// Ermittelt anhand des Datums der nächsten Prüfung den aktuellen Prüfstatus eines Geräts.
        /// </summary>
        /// <param name="geraet">Das Gerät, dessen Prüfstatus berechnet werden soll.</param>
        /// <returns>Den ermittelten Prüfstatus des Geräts.</returns>
        public static string GetStatus(Device geraet)
        {


            if (!geraet.NaechstePruefung.HasValue)
            {
                return "Nicht geprüft";
            }
            else if (geraet.NaechstePruefung < DateOnly.FromDateTime(DateTime.Now))
            {
                return "Überfällig";
            }
            else if (geraet.NaechstePruefung < DateOnly.FromDateTime(DateTime.Now.AddDays(30)))
            {
                return "Bald fällig";
            }
            else
            {
                return "Geprüft";
            }



        }
    }
}