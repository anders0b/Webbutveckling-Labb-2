# Uppgiftsbeskrivning
## LABB 2 - APIer

I denna uppgift skall vi implementera 
databashantering och REST API för en e-handel.

Labben är uppdelad i två delar. Den första delen är
att skapa APIet.

Den andra delen är att skapa en Frontend som använder APIet.

## Beställning

Kunden för ditt förra uppdrag var väldigt nöjd med vad du åstadkommit och har rekommenderat dig för en av sina branschkollegor.

De har nu ett nytt uppdrag. Den nya kunden vill att du utvecklar ett REST Api och de vill att vi gör det med Microsoft .NET 8.0 teknologier.

Tanken med det nya uppdraget är att de vill kunna återanvända api:et till flera applikationer som kommer att utvecklas framöver.

De har följande krav på lösningen:

## Grundläggande krav

* Det ska gå att skapa nya proukter som lagras i en databas(SQL-Server eller MongoDB)
* Det ska gå att ändra och ta bort produkter i databasen
* Det ska gå att markera att produkter utgått ur sortimentet
* Det ska gå att hämta alla produkter
* Det ska gå att söka efter en produkt på produktens namn eller produktnummer
* Kunder ska kunna registrera sig och uppgifterna skall lagras i databasen.
* Kunder ska kunna uppdatera sina uppgifter
* Det ska gå att lista alla Kunder
* Det ska gå söka efter kunder på e-post adress
* När en kund köper något/placerar en order måste vi kunna spåra vilken/vilka produkter som kunden har köpt

## Detaljkrav

### För en produkt skall följande uppgifter lagras i databasen

* Produktnummer
* Produktnamn
* Produktbeskrivning
* Pris
* Produktkategori (Mejeri, elektronik, husgeråd eller liknande)
* Status (om den finns i eller har utgått ur sortimentet)

### För en kunder skall följande information lagras

* Förnamn
* Efternamn
* E-post
* Mobilnummer
* Adressuppgifter

## Designkrav

REST Api-lösningen skall utvecklas enligt objektorienterade principer och använda följa Single Responsibility Principle.

All databaskommunikation skall också ske med hjälp av Repository Pattern.
