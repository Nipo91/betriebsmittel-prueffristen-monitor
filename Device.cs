using System.Collections.Generic;
namespace Betriebsmittel.PrueffristenMonitor
{
    internal class Device
    {
        public string id;
        public string bezeichnung;
        public string abteilung;
        public DateOnly? pruefdatum;

        public DateOnly? naechstePruefung;
        public int pruefintervall;


        public Device(string geraeteID, string geraeteBezeichnung, string geraeteAbteilung, DateTime? geraetePruefdatum, DateTime? geraeteDatumNaechstePruefung, int geraetePruefintervall)
        {
            id = geraeteID;
            bezeichnung = geraeteBezeichnung;
            abteilung = geraeteAbteilung;

            if (geraetePruefdatum.HasValue)
            {
                pruefdatum = DateOnly.FromDateTime(geraetePruefdatum.Value);
            }
            else
            {
                pruefdatum = null;
            }

            if (geraeteDatumNaechstePruefung.HasValue)
            {
                naechstePruefung = DateOnly.FromDateTime(geraeteDatumNaechstePruefung.Value);
            }

            else
            {
                naechstePruefung = null;
            }
            pruefintervall = geraetePruefintervall;
            Console.WriteLine(this);
            Console.WriteLine($"ID: {id}, Bezeichung: {bezeichnung}, Abteilung: {abteilung}, Prüfdatum: {pruefdatum}, Nächste Prüfung: {naechstePruefung}, Prüfintervall: {pruefintervall}");
        }

    }
}