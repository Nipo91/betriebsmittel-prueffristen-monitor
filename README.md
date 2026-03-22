# Benning ST760 DB Importer

*Entwicklung einer C#-Konsolenanwendung zur Auswertung von Benning-ST760-Datenbankdateien, um Geräteprüfungen zu identifizieren und insbesondere überfällige Prüfungen übersichtlich darzustellen.*

---

## Projektbeschreibung

Dieses Projekt ist eine Konsolenanwendung in C#, die Daten aus einer Benning-ST760-Datenbankdatei (`.db`) einliest und für die Prüfüberwachung auswertet.

Ziel ist es, Geräte aus der Datenbank zu ermitteln und anzuzeigen, welche Prüfungen bereits überfällig sind, bald anstehen oder noch gültig sind.

Die Anwendung richtet sich an den fachlichen Anwendungsfall, Prüfgerätedaten strukturiert auszulesen und in einer übersichtlichen Form bereitzustellen.

---

## Disclaimer

Dieses Projekt ist ein eigenständig entwickeltes Praxisprojekt, das ich im Rahmen meiner Bewerbung um ein Praktikum in der Anwendungsentwicklung nutze, um meine Arbeitsweise und meine bisherigen Kenntnisse nachvollziehbar aufzuzeigen.

Ziel ist es, einen praxisnahen Anwendungsfall mit C# strukturiert zu entwickeln und dabei meine Kenntnisse im Umgang mit Datenbankdateien, Programmlogik und Projektaufbau zu vertiefen.

KI nutze ich unterstützend in einer fachlich begleitenden Rolle, ähnlich einem Teamleiter oder Ausbilder. Die Unterstützung betrifft vor allem die Projektplanung, die Strukturierung der Arbeitsschritte, technische Erklärungen.

Die Umsetzung des Codes und die inhaltliche Erarbeitung der Lösung erfolgen durch mich selbst.

---

## Schritte der Entwicklung
- Reihenfolge der Entwicklung
- Die sinnvolle Reihenfolge ist aus meiner Sicht:
- Pfad einlesen und prüfen
- Datenbankverbindung testen
- Tabellen und Spalten analysieren
- Geräteabfrage bauen
- Geräteklasse / Datenmodell bauen
- Statuslogik ergänzen
- Ausgabe verbessern
- Fehlerbehandlung und Aufräumen

---

## Funktionen

- Einlesen einer `.db`-Datei über einen vom Benutzer eingegebenen Dateipfad
- Aufbau einer Datenbankverbindung
- Auslesen relevanter Gerätedaten
- Bewertung des Prüfstatus anhand vorhandener Prüfdaten
- Ausgabe einer Übersicht in der Konsole
- Kennzeichnung von überfälligen Geräten

---

## Geplante Ausgabe

Die Anwendung soll unter anderem folgende Informationen anzeigen:

- Inventarnummer
- Gerätebezeichnung
- Raum / Standort
- letztes Prüfdatum
- nächstes Prüfdatum
- aktueller Status

Beispiel für Statuswerte:

- Gültig
- Bald fällig
- Überfällig
- Unbekannt

---

## Projektziel

Das Projekt dient dazu, ein praxisnahes C#-Programm zu entwickeln, das einen realen betrieblichen Anwendungsfall abbildet: die Auswertung von Prüfdaten aus Benning-Datenbanken.

Im Vordergrund stehen dabei:

- strukturierter Programmaufbau
- Datenbankzugriff mit C#
- Verarbeitung fachlicher Daten
- saubere Trennung zwischen Datenzugriff, Logik und Ausgabe

---

## Verwendete Technologien

- C#
- .NET
- SQLite / Datenbankzugriff auf `.db`-Dateien
- Konsolenanwendung

---

## Projektstruktur (geplant)

- `Program.cs` – Einstiegspunkt des Programms
- `Device.cs` – Modell für ein Gerät
- `DeviceRepository.cs` – Datenbankzugriff
- `DeviceStatusService.cs` – Fachlogik zur Statusbewertung
- `ConsoleOutputService.cs` – Ausgabe in der Konsole

---

## Geplanter Entwicklungsstand / Meilensteine

1. Dateipfad zur Datenbank einlesen
2. Datenbankverbindung prüfen
3. Tabellenstruktur analysieren
4. Gerätedaten auslesen
5. Prüfstatus berechnen
6. Ergebnisse übersichtlich ausgeben
7. Fehlerbehandlung und Dokumentation ergänzen

---

## Start der Anwendung

Die Anwendung wird als Konsolenprogramm gestartet.  
Nach dem Start gibt der Benutzer den Pfad zur gewünschten `.db`-Datei ein.

Beispiel:

`/Users/Name/Documents/Benning/Datei.db`

Anschließend liest das Programm die Datenbank ein und erstellt eine Auswertung.

---

## Hinweis

Die genaue Tabellenstruktur der Benning-Datenbank wird im Projekt noch analysiert.  
Deshalb kann sich die konkrete SQL-Abfrage im Verlauf der Entwicklung noch ändern.

---

## Perspektivische Erweiterungen

- Filter nach Raum oder Standort
- Export der Ergebnisse
- grafische Oberfläche
- Unterstützung weiterer Auswertungen