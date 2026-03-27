namespace Betriebsmittel.PrueffristenMonitor
{
    internal class DeviceStatusService
    {
        public static string GetStatus(Device gereat)
        {


            if (!gereat.NaechstePruefung.HasValue)
            {
                return "Nicht geprüft";
            }
            else if (gereat.NaechstePruefung < DateOnly.FromDateTime(DateTime.Now))
            {
                return "Überfällig";
            }
            else if (gereat.NaechstePruefung < DateOnly.FromDateTime(DateTime.Now.AddDays(30)))
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