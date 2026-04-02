namespace Betriebsmittel.PrueffristenMonitor
{
    internal class Device
    {
        public string Id { get; private set; }
        public string Bezeichnung { get; private set; }
        public string Abteilung { get; private set; }
        public DateOnly? Pruefdatum { get; private set; }

        public DateOnly? NaechstePruefung { get; private set; }
        public int Pruefintervall { get; private set; }
        /// <summary>
        /// Speichert den aktuellen Prüfstatus des Geräts. Berechnung in DeviceStatusService.
        /// </summary>
        public string Status { get; set; } = "";

        /// <summary>
        /// Erstellt ein neues Device-Objekt aus den eingelesenen Gerätedaten.
        /// </summary>
        /// <param name="geraeteID">Eindeutige ID des Geräts.</param>
        /// <param name="geraeteBezeichnung">Bezeichnung des Geräts.</param>
        /// <param name="geraeteAbteilung">Abteilung oder Raum des Geräts.</param>
        /// <param name="geraetePruefdatum">Datum der letzten Prüfung.</param>
        /// <param name="geraeteDatumNaechstePruefung">Datum der nächsten Prüfung.</param>
        /// <param name="geraetePruefintervall">Prüfintervall des Geräts in Monaten.</param>
        public Device(string geraeteID, string geraeteBezeichnung, string geraeteAbteilung, DateTime? geraetePruefdatum, DateTime? geraeteDatumNaechstePruefung, int geraetePruefintervall)
        {
            Id = geraeteID;
            Bezeichnung = geraeteBezeichnung;
            Abteilung = geraeteAbteilung;


            if (geraetePruefdatum.HasValue)
            {
                Pruefdatum = DateOnly.FromDateTime(geraetePruefdatum.Value);
            }
            else
            {
                Pruefdatum = null;
            }

            if (geraeteDatumNaechstePruefung.HasValue)
            {
                NaechstePruefung = DateOnly.FromDateTime(geraeteDatumNaechstePruefung.Value);
            }

            else
            {
                NaechstePruefung = null;
            }
            Pruefintervall = geraetePruefintervall;


            //Console.WriteLine(this);
            //Console.WriteLine($"ID: {id}, Bezeichung: {bezeichnung}, Abteilung: {abteilung}, Prüfdatum: {pruefdatum}, Nächste Prüfung: {naechstePruefung}, Prüfintervall: {pruefintervall}");
        }



    }
}