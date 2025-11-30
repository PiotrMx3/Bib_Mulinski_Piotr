# Bibliotheekbeheer – Projectstructuur
# (English Below)

## Overzicht
Dit project is een .NET-consoleapplicatie voor het beheren van een bibliotheek. De applicatie stelt de gebruiker in staat om te schakelen tussen drie hoofdmodules: het beheer van de boekencollectie, het leeszaalbeheer en het **ontleenmenu**.
De `App`-laag initialiseert de bibliotheek, vult deze met voorbeelddata (boeken en exemplaren) en geeft dezelfde instantie door aan de verschillende user interfaces (UI) die verantwoordelijk zijn voor de specifieke domeinen.

## Structuur van de oplossing

| Bestand/Pad | Beschrijving |
| :--- | :--- |
| `Bib_Mulinski_Piotr.sln` | Hoofdoplossingsbestand van Visual Studio. |
| `Program.cs` | Entry point dat `App.Run()` uitvoert. |
| `App.cs` | Initialiseert de bibliotheek, maakt menu’s aan en seedt data (MockBooks). |
| `Library.cs` | Centrale domeinlogica. Bevat lijsten van boeken, leeszaalitems en het **uitleenlogboek**. |
| `LibraryMenuUi.cs` | UI voor CRUD-operaties op boeken (zoeken, toevoegen, verwijderen). |
| `ReadingRoomMenuUi.cs` | UI voor beheer van kranten en tijdschriften in de leeszaal. |
| `BorrowMenuUi.cs` | **Nieuw:** UI voor het uitlenen en terugbrengen van boeken (inclusief groepering). |
| `Book.cs` | Representatie van een fysiek boekexemplaar. Implementeert `ILendable`. |
| `Interface.cs` | Bevat de `ILendable` interface (contract voor uitlenen/terugbrengen). |
| `BooksGroup.cs` | Hulpklasse voor het groeperen van boeken op ISBN in het ontleenmenu. |
| `Magazine.cs`, `NewsPaper.cs` | Klassen voor leeszaalitems (erven van `ReadingRoomItem`). |
| `BooksEnums.cs`, `EnumUtlis.cs` | Enums en hulpmiddelen voor vertaling en weergave van metadata. |
| `Logger.cs` | Eenvoudige wrapper voor console-logging (Info, Error, Success). |

## Controleflow
1. `Program` maakt een `App`-instantie en roept `Run()` aan.
2. `App` vraagt de bibliotheeknaam, maakt een `Library`-instantie en initialiseert de drie sub-menu's (`LibraryMenuUi`, `ReadingRoomMenuUi`, `BorrowMenuUi`).
3. Vervolgens worden er **100 voorbeeldboeken** gegenereerd (20 titels × 5 exemplaren) om het groeperingsmechanisme te testen.
4. In de hoofdloop kiest de gebruiker uit:
    * **Bibliotheek Menu:** Beheer van de catalogus.
    * **Leeszaal Menu:** Beheer van kranten/tijdschriften.
    * **Ontleen Menu:** Boeken zoeken, uitlenen op naam en terugbrengen via GUID.

## Domeinmodel
- **Library**: De centrale hub. Bevat:
    - `List<Book>`: Alle fysieke exemplaren.
    - `Dictionary<DateTime, ReadingRoomItem>`: Leeszaalitems.
    - `Dictionary<string, List<string>>`: **BorrowLog** (houdt bij welke gebruiker welke GUIDs heeft).
- **Book**: Fysiek exemplaar. Implementeert **`ILendable`** (bevat logica voor `IsAvailable`, `BorrowingDate`, `BorrowDays`). Bevat validatie in setters (via `BookValidationExceptions`).
- **BooksGroup**: Een view-model klasse gebruikt in het ontleenmenu om identieke boeken (zelfde ISBN) samen te vatten en alleen beschikbare exemplaren te tonen.
- **ReadingRoomItem**: Abstracte basisklasse voor `Magazine` en `NewsPaper`.

## Aanvullende documentatie
De map `Documentation/` bevat de UML-klassendiagrammen die de relaties tussen de UI, de logica (Library) en de data-entiteiten (Book, ReadingRoomItem) visualiseren.



# Library Management System – Project Structure

## Overview
This project is a .NET console application designed to manage a library system. It allows users to switch between three main modules: the book collection management, the reading room management, and the **borrowing menu**.
The `App` layer initializes the library, seeds it with sample data (books and copies), and passes the same library instance to various User Interfaces (UI) responsible for specific domains.

## Solution Structure

| File/Path | Description |
| :--- | :--- |
| `Bib_Mulinski_Piotr.sln` | Visual Studio Solution file. |
| `Program.cs` | Entry point executing `App.Run()`. |
| `App.cs` | Initializes library, creates menus, and seeds mock data. |
| `Library.cs` | Central domain logic. Contains lists of books, reading room items, and the **borrowing log**. |
| `LibraryMenuUi.cs` | UI for CRUD operations on books (search, add, remove). |
| `ReadingRoomMenuUi.cs` | UI for managing newspapers and magazines in the reading room. |
| `BorrowMenuUi.cs` | **New:** UI for borrowing and returning books (includes grouping logic). |
| `Book.cs` | Represents a physical book copy. Implements `ILendable`. |
| `Interface.cs` | Contains the `ILendable` interface (contract for borrow/return). |
| `BooksGroup.cs` | Helper class for grouping books by ISBN in the borrowing menu. |
| `Magazine.cs`, `NewsPaper.cs` | Classes for reading room items (inheriting `ReadingRoomItem`). |
| `BooksEnums.cs`, `EnumUtlis.cs` | Enums and utilities for metadata translation and display. |
| `Logger.cs` | Simple wrapper for console logging (Info, Error, Success). |

## Control Flow
1. `Program` creates an `App` instance and calls `Run()`.
2. `App` requests the library name, instantiates `Library`, and initializes the three sub-menus (`LibraryMenuUi`, `ReadingRoomMenuUi`, `BorrowMenuUi`).
3. Then, **100 sample books** are generated (20 titles × 5 copies each) to test the grouping mechanism.
4. In the main loop, the user selects:
    * **Library Menu:** Catalog management.
    * **Reading Room Menu:** Newspaper/Magazine management.
    * **Borrow Menu:** Search books, borrow by user name, and return via GUID.

## Domain Model
- **Library**: The central hub. Contains:
    - `List<Book>`: All physical copies.
    - `Dictionary<DateTime, ReadingRoomItem>`: Reading room items.
    - `Dictionary<string, List<string>>`: **BorrowLog** (tracks which user holds which GUIDs).
- **Book**: Physical copy. Implements **`ILendable`** (contains logic for `IsAvailable`, `BorrowingDate`, `BorrowDays`). Includes validation in setters (via `BookValidationExceptions`).
- **BooksGroup**: A view-model class used in the Borrow Menu to aggregate identical books (same ISBN) and display only available copies.
- **ReadingRoomItem**: Abstract base class for `Magazine` and `NewsPaper`.

## Additional Documentation
The `Documentation/` folder contains UML class diagrams visualizing the relationships between the UI, Logic (Library), and Data Entities (Book, ReadingRoomItem).
