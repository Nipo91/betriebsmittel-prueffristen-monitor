# Betriebsmittel Prüffristen Monitor

C#-Konsolenanwendung zur Auswertung von Prüfdaten elektrischer Betriebsmittel aus einer Benning-ST760-Datenbankdatei (`.db`).

Ziel des Projekts ist es, relevante Daten zu elektrischen Betriebsmitteln und deren Prüfterminen einzulesen, daraus den aktuellen Prüfstatus zu berechnen und fällige bzw. überfällige Prüfungen sichtbar zu machen.

---

## Projektbeschreibung

Dieses Projekt dient dazu, einen praxisnahen Anwendungsfall aus dem Bereich der Prüfung elektrischer Betriebsmittel DGUV V3 in C# umzusetzen.

Die Anwendung liest Daten aus einer SQLite-Datenbank ein, verarbeitet relevante Informationen zu elektrischen Betriebsmitteln und deren Prüfungen und bewertet auf dieser Basis den aktuellen Prüfstatus.

Im Mittelpunkt stehen dabei:

- strukturierter Programmaufbau
- Datenbankzugriff mit C#
- Trennung von Datenmodell, Datenzugriff und Fachlogik
- schrittweise Weiterentwicklung über klar definierte Meilensteine

---

## Aktueller Stand

Aktuell umgesetzt sind:

- Einlesen eines Dateipfads zur gewünschten `.db`-Datei
- Prüfung, ob die angegebene Datei existiert und die Endung `.db` besitzt
- Aufbau einer Verbindung zur Benning-Datenbank
- Auslesen relevanter Daten aus der Tabelle `Geraete`
- Erzeugen von `Device`-Objekten aus den eingelesenen Datensätzen
- Berechnung des Prüfstatus über den `DeviceStatusService`
- Ausgabe der eingelesenen Betriebsmittel- und Prüfinformationen in der Konsole

---

## Aktuelle Statuslogik

Der Prüfstatus wird derzeit anhand des Datums der nächsten Prüfung bewertet.

Aktuell werden folgende Statuswerte verwendet:

- `nicht Geprüft`
- `Prüfung Abgelaufen`
- `Bald Prüfen`
- `Geprüft`

---

## Verwendete Technologien

- C#
- .NET
- Microsoft.Data.Sqlite
- SQLite / `.db`-Datenbankdateien
- Konsolenanwendung

---

## Projektstruktur

- `Program.cs` – Einstiegspunkt des Programms, Benutzereingabe und Konsolenausgabe
- `Device.cs` – technisches Datenmodell für ein elektrisches Betriebsmittel mit relevanten Prüfinformationen
- `DeviceRepository.cs` – Lesen der Betriebsmittel- und Prüfdaten aus der Datenbank
- `DeviceStatusService.cs` – Fachlogik zur Bewertung des Prüfstatus

---

## Entwicklungsstand / Meilensteine

1. Dateipfad zur Datenbank einlesen  
2. Datenbankverbindung prüfen  
3. Tabellenstruktur analysieren  
4. Daten zu elektrischen Betriebsmitteln auslesen  
5. Prüfstatus berechnen  
6. Ergebnisse übersichtlich ausgeben  
7. Fehlerbehandlung und Dokumentation ergänzen  

**Aktueller Stand:** Meilenstein 6 abgeschlossen  
**Nächster Schritt:** Meilenstein 7 – Fehlerbehandlung und Dokumentation ergänzen  

---

## Start der Anwendung

Die Anwendung wird als Konsolenprogramm gestartet.

Nach dem Start gibt der Benutzer den Pfad zur gewünschten `.db`-Datei ein.

Beispiel unter Windows:

`C:\Users\<Benutzername>\Documents\Benning\FirmaXy.db`

Beispiel unter macOS:

`/Users/<Benutzername>/Documents/Benning/FirmaXy.db`

Anschließend werden die Daten eingelesen, der Prüfstatus berechnet und die Ergebnisse in der Konsole ausgegeben.

---

## Projektziel

Das Projekt soll einen realen fachlichen Anwendungsfall aus dem Bereich der Prüfung elektrischer Betriebsmittel in ein strukturiertes C#-Programm überführen.

Neben der eigentlichen Funktionalität dient es auch dazu, den eigenen Entwicklungsstand in den Bereichen

- objektorientierter Programmaufbau
- Arbeiten mit Datenbankdateien
- fachliche Logik in C#
- nachvollziehbare Projektstruktur

sichtbar zu machen.

---

## Hinweis

Dieses Repository dokumentiert ein laufendes Praxis- und Lernprojekt, das schrittweise weiterentwickelt wird.

Der aktuelle Schwerpunkt liegt auf dem Einlesen und Verarbeiten von Prüfdaten elektrischer Betriebsmittel sowie auf der Berechnung des Prüfstatus. Die übersichtlichere Darstellung der Ergebnisse folgt im nächsten Entwicklungsschritt.