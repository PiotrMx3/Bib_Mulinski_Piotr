# Bibliotheekbeheer – projectstructuur

## Overzicht
Dit project stelt een eenvoudige .NET-consoleapplicatie voor die een bibliotheek beheert,
waarmee je kunt schakelen tussen het bibliotheekmenu en het leeszaalmenu.
De `App`-laag initialiseert de bibliotheek, vult deze met voorbeeldboeken
en geeft dezelfde instantie door aan de gebruikersinterfaces die verantwoordelijk zijn
voor operaties op de boekencollectie en de leeszaalitems.

## Structuur van de oplossing
| Pad | Beschrijving |
| --- | --- |
| `Bib_Mulinski_Piotr.sln` | Hoofdoplossingsbestand van Visual Studio. |
| `Bib_Mulinski_Piotr/Program.cs` | Entry point dat `App.Run()` uitvoert. |
| `Bib_Mulinski_Piotr/App.cs` | Initialiseert de bibliotheek, maakt menu’s aan en seedt data. |
| `Bib_Mulinski_Piotr/Library.cs` | Domeinlogica van de bibliotheek en leeszaal. |
| `Bib_Mulinski_Piotr/LibraryMenuUi.cs` | Afhandeling van gebruikerscommando’s voor de boekenverzameling. |
| `Bib_Mulinski_Piotr/ReadingRoomMenuUi.cs` | Afhandeling van gebruikerscommando’s voor de leeszaal. |
| `Bib_Mulinski_Piotr/Book.cs`, `Magazine.cs`, `NewsPaper.cs` | Representaties van boeken en persmateriaal. |
| `Bib_Mulinski_Piotr/BooksEnums.cs`, `EnumUtlis.cs` | Enums en hulpmiddelen voor het tonen van boekmetadata. |
| `Bib_Mulinski_Piotr/Logger.cs` | Eenvoudige wrapper voor console-logging. |
| `Bib_Mulinski_Piotr/Documentation/` | UML-diagrammen en ondersteunende notities. |

## Controleflow
1. `Program` maakt een `App`-instantie en roept `Run()` aan om de menuloop te starten.
2. `App` vraagt de gebruiker om de naam van de bibliotheek, maakt een `Library`
   en initialiseert `LibraryMenuUi` en `ReadingRoomMenuUi`, waarna
   voorbeeldboeken worden toegevoegd.
3. In de hoofdloop kiest de gebruiker het bibliotheekmenu (operaties op boeken)
   of het leeszaalmenu (operaties op kranten/tijdschriften). Beide interfaces
   gebruiken dezelfde `Library`-instantie en loggen meldingen via de `Logger`.

## Domeinmodel
- **Library** – bewaart een lijst boeken (`List<Book>`) en een dictionary
  met leeszaalitems (`Dictionary<DateTime, ReadingRoomItem>`), en stelt
  immutable kopieën ter beschikking voor weergave.
- **Book** – entiteit van de boekencollectie met een volledige set metadata:
  ISBN, auteur, uitgever, aantal pagina’s, taal, herkomstland, kafttype en genre.
- **ReadingRoomItem** – basisklasse voor **Magazine** en **NewsPaper**,
  met gedeelde identificatie-eigenschappen voor leeszaalitems.
- **BooksEnums** en **EnumUtlis** – enumeraties en extensiemethoden
  voor het omzetten van waarden naar duidelijke labels.

## Aanvullende documentatie
De map `Documentation/` bevat UML-diagrammen (`*.png`) en een Word-bestand met beschrijving,
zodat je de structuur van de code eenvoudig kunt koppelen aan de visuele documentatie.
