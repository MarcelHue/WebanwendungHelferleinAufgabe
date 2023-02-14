https://docs.google.com/document/d/17JuMZf5MoUUNP5ZtK2yKUK7UdwW25Tz02zw1OH4OsR8/edit#heading=h.69f71u8df24w
Der gemeinnützige Verein Helferlein e. V. vermittelt Dienstleistungen von freiwilligen Helfern an hilfesuchende Bürger. Bislang wurden diese Dienstleistungen telefonisch kommuniziert. Nun möchte der Helferlein e. V. die Verwaltung der Dienstleistungen digitalisieren. 

In der Webanwendung der Helferlein e. V. können Mitglieder ihre persönlichen Daten verwalten. Falls noch nicht erfolgt, ist ein Login erforderlich. Jedes Mitglied kann Terminvorschläge für eine Dienstleistung abrufen. Sie kann eine Dienstleistung buchen, muss dazu aber in jedem Fall Terminvorschläge für die Dienstleistung abrufen. Für die Buchung ist ebenfalls ein Login erforderlich. Ein Administrator ist ein Mitglied, welches Dienstleistungsarten verwalten kann. Auch hier ist ein Login erforderlich, falls dieser noch nicht durchgeführt wurde. Für einen Gast gibt es ebenfalls die Möglichkeit, Terminvorschläge für eine Dienstleistung abzurufen. Außerdem kann sich ein Gast als Mitglied registrieren.


1. Erstellen Sie ein Anwendungsfalldiagramm, welches die beschriebenen Anwendungsfälle und die erforderlichen Akteure darstellt. 



2. Die Datenbank für die Leistungserbringung soll nach dem folgenden Pflichtenheft modelliert werden. 
- Für die Mitglieder sollen folgende Attribute hinterlegt sein: vollständiger Name und vollständige Adresse, Telefonnummer, E-Mail-Adresse. 
- Für jedes Mitglied sollen seine summierten Einnahmen und Ausgaben in einer eigenen Tabelle verwaltet werden.
- Für die Leistung ist eine Beschreibung zu erfassen.
- Für die Leistung kann optional eine Ausrüstung erforderlich sein. 
- Leistungsarten (z. B. Kinderbetreuung, Fahrdienst, Gartenarbeit) sowie Ausrüstung (z. B. Werkzeug, Rasenmäher) sollen jeweils in einer eigenen Tabelle hinterlegt sein. 
- Jedes Mitglied kann beliebige Leistungen als Leistungsnehmer in Anspruch nehmen. 
- Jedes Mitglied kann beliebige Leistungen als Leistungsgeber erbringen. 
- Für jede erbrachte Leistung ist der Leistungsbeginn und die Leistungsdauer in vollen Stunden zu erfassen. 

a) Erstellen Sie ein ERM und ein RM (relationales Datenbankmodell) in der dritten Normalform. Kennzeichnen Sie im RM Schlüsselattribute mit PK für Primärschlüssel und FK für Fremdschlüssel. Geben Sie alle Beziehungen mit ihren Kardinalitäten an. Geben Sie den Tabellen und Attributen selbsterklärende Namen. Adressdaten dürfen redundant sein. 

RM
ERM
b) Implementieren Sie ihren Entwurf in ein DBMS ihrer Wahl. (Zusatzaufgabe)


3. Für den Helferlein e.V. soll eine Prozedur entwickelt werden, welche die erbrachten Leistungen und die aufsummierten Entgelte auflistet. Die Daten sind in einem Journal gespeichert.

a) Entwickeln Sie einen Algorithmus für die Prozedur erstelle_liste(stundensatz: Double), der die Liste entsprechend der Vorgabe schreibt und dazu die entsprechenden Werte berechnet. Stellen Sie den Algorithmus in Pseudocode, einem Struktogramm oder einem PAP dar. 

b) Implementieren Sie den Algorithmus in Java



4. Alle Mitglieder des Helferlein e.V. sollen über eine App nur ihre eigenen Serviceangebote editieren und nur für andere Mitglieder eine Bewertung von 1 bis 10 abgeben können. Um dies zu gewährleisten, wird der Zugriff auf die Methoden „setService" und,,giveRating" über die Klasse Proxy gesteuert. Die Methode „isOwner" vergleicht die Objekte „mitglied" und „ user". 
a) Ergänzen Sie das folgende unvollständige UML-Klassendiagramm nach den folgenden Vorgaben.
 - Die Klasse „RealMitglied" soll die nur klassenintern sichtbaren Instanzvariablen „name", ,,service", ,,rating", und ,,countRatings" beinhalten. 
- Der öffentliche Konstruktor der Klasse „Real Mitglied" soll zwei Übergabeparameter haben, mit denen „ name" und ,, service" initialisiert werden. 
- Der öffentliche Konstruktor der Klasse „Proxy" soll zwei „ Real Mitglied" 
-Objekte übergeben bekommen und diese mit den Referenzen „mitglied" und „user" verknüpfen. 
- Die Klassen „Proxy" und „RealMitglied" sollen beide das Interface Mitglied implementieren. Zeichnen Sie alle Klassenbeziehungen ein:

b) Zusatzaufgabe: Implementieren Sie den Entwurf des Klassendiagramms in Java



5. Die Funktionsweise des Zugriffproxies soll nachfolgend mit einem UMLSequenzdiagramm verdeutlicht werden:

- Der Client ruft auf dem Proxyobjekt die Methode „giveRating" auf.
- Die Methode „giveRating" überprüft mittels der Methode „isOwner", ob das bewertete RealMitglied „ mitglied" und der Bewerter „user" ein und dieselbe Person sind. 
- Im Ja-Fall gibt „giveRating" den Wert -1.0 an den Client zurück. 
- Im Nein-Fall wird die Methode „giveRating" des RealMitglied-Objekts aufgerufen, welche die abgegebene Bewertung hinzufügt und die durchschnittliche Bewertung zurückgibt. 
- Die durchschnittliche Bewertung wird an den Client weitergereicht.

6. Informationen zu Mitgliedern, ihren jeweiligen Angeboten und Bewertungen, stehen in folgender Datenbank zur Verfügung: 



Formulieren Sie SQL-Statements für die nachstehenden Aufgabenstellungen. 

a) Geben Sie alle Attribute des jüngsten Mitglieds aus. 
b) Ermitteln Sie eine Mitgliederliste aufsteigend sortiert nach der durchschnittlichen Bewertung für die Leistungsart „ Kinderbetreuung". Beispiel: 


c) Erstellen Sie eine Angebotsliste, die alle Mitglieder und die entsprechende Leistungsart des Angebots ausgibt, welche donnerstags von 14:00 Uhr bis 16:00 Uhr zur Verfügung stehen. Beispiel:



d) Erstellen Sie eine neue Tabelle MitgliedArchiv. Transferieren Sie alle Mitglieder, die kein Angebot eingestellt haben, in diese Tabelle. Löschen Sie diese inaktiven Mitglieder aus der Tabelle Mitglied.
