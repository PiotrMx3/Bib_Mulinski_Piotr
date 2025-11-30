using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class LibraryMenuUi
    {
        private Library _library;

        public LibraryMenuUi(Library library)
        {
            this._library = library;
        }


        private void ReadBooksFromCsvUi()
        {
            ImmutableList<Book> backup = _library.LibraryAllBooks;


            try
            {
                _library.ReadBooksFromCsv("csvBooks.txt");

                Logger.LogSuccess($"Er zijn {_library.LibraryAllBooks.Count - backup.Count} boeken met succes toegevoegd!");
                Console.WriteLine();
            }
            catch (BookValidationExceptions e)
            {
                _library.RollBack(backup.ToList<Book>());
                Logger.LogError("Fout bij het inlezen van CSV. Rollback uitgevoerd", e);

                Console.WriteLine();
            }
            catch (Exception)
            {
                _library.RollBack(backup.ToList<Book>());
                throw;
            }


        }

        private void ShowAllBooksUi()
        {
            Logger.LogInfo("Het totale overzicht van boeken");
            Console.WriteLine();
            Console.WriteLine();

            List<Book> sorted = new List<Book>(_library.LibraryAllBooks);
            sorted.Sort((a, b) => a.Title.CompareTo(b.Title));

            foreach (Book book in sorted)
            {
                Console.WriteLine($"{book.Describe()}");
            }
            Console.WriteLine();

        }


        private void RemoveBookFromLibraryByGuidUi()
        {
            if (_library.LibraryAllBooks.Count == 0)
            {
                Logger.LogError("Bibliotheek bevat geen boeken !");
                Console.WriteLine();
                return;
            }

            List<Book> sorted = new List<Book>(_library.LibraryAllBooks);
            sorted.Sort((a, b) => a.Title.CompareTo(b.Title));
            foreach (Book book in sorted)
            {
                Console.WriteLine($"{book.ShortDescribe()}");
                Console.WriteLine();
            }

            Console.WriteLine();

            Logger.LogInfo("Om een boek te verwijderen geef een GUID in: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Welk boek wil je verwijderen ?: ");

            string guidFromUser = (Console.ReadLine() ?? "").Trim();

            bool removed = _library.RemoveBookFromLibraryByGuid(guidFromUser);

            Console.WriteLine();

            if (removed)
            {
                Console.WriteLine();
                Logger.LogSuccess($"Boek met GUID: {guidFromUser} is verwijderd");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Logger.LogError("Ongeldige GUID of het boek is momenteel uitgeleend");
                Console.WriteLine();
            }

        }

        private void SearchBookSubMenuUi()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Logger.LogInfo("==== Submenu: Boeken Zoeken ====");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("1. Zoek een boek op basis van titel en auteur");
                Console.WriteLine("2. Zoek een boek op basis van ISBN nummer");
                Console.WriteLine("3. Zoek alle boeken op basis van auteur");
                Console.WriteLine("4. Zoek alle boeken op basis van taal");
                Console.WriteLine("5. Zoek een boek op basis van GUID ");
                Console.WriteLine("0. Afsluiten");
                Console.WriteLine();

                Console.Write("Maak een keuze: ");
                string userChoice = (Console.ReadLine() ?? "").Trim();
                Console.WriteLine();

                switch (userChoice)
                {
                    case "1":
                        FindBookByNameAndAuthorUi();
                        break;
                    case "2":
                        FindBookByIsbnUi();
                        break;
                    case "3":
                        FindBooksByAutorUi();
                        break;
                    case "4":
                        AllBooksByLanguageUi();
                        break;
                    case "5":
                        FindBookByGuidUi();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Logger.LogError("Ongeldige keuze");
                        Console.WriteLine();
                        break;
                }

            }


        }


        private void FindBookByGuidUi()
        {

            if (_library.LibraryAllBooks.Count == 0)
            {
                Logger.LogError("Bibliotheek bevat geen boeken !");
                Console.WriteLine();
                return;
            }


            Logger.LogInfo("Om een boek te vinden geef een GUID in: ");


            string guidFromUser = (Console.ReadLine() ?? "").Trim();

            Book? foundBook = _library.FindBookByGuid(guidFromUser);

            Console.WriteLine();

            if (foundBook is not null)
            {
                Console.WriteLine();
                Console.WriteLine(foundBook.Describe());
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Logger.LogError("Boek niet gevonden !");
                Console.WriteLine();
            }

        }
        private void AllBooksByLanguageUi()
        {
            Logger.LogInfo("Geef een gewenste Taal in: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Beschikbare opties: ");
            Console.WriteLine();

            EnumUtils.EnumMenuForLang();
            Console.WriteLine();

            Console.Write("Maak een keuze: ");

            string langChoice = (Console.ReadLine() ?? "").Trim();


            if (int.TryParse(langChoice, out int parsedValue) && Enum.IsDefined<BooksEnums.Language>((BooksEnums.Language)parsedValue))
            {
                BooksEnums.Language langFromUser = (BooksEnums.Language)parsedValue;
                ImmutableList<Book>? allBooksByLang = _library.AllBooksByLanguage(langFromUser);

                if (allBooksByLang is not null && allBooksByLang.Count != 0)
                {
                    Logger.LogInfo($"Gevonden boeken in {EnumUtils.ToDutchLang(langFromUser)}");
                    Console.WriteLine();
                    Console.WriteLine();

                    foreach (Book book in allBooksByLang)
                    {
                        Console.WriteLine($"{book.Describe()}");
                        Console.WriteLine();

                    }

                }
                else
                {
                    Console.WriteLine();
                    Logger.LogError("Geen resultaten gevonden");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
                Logger.LogError("Gekozen waarde bestaat niet !");
                Console.WriteLine();
            }

        }

        private void FindBooksByAutorUi()
        {
            Logger.LogInfo("Zoek alle boeken op basis van Auteur");
            Console.WriteLine();
            Console.Write("Geef de gewenste Auteur van het boek in: ");
            string authorFromUser = (Console.ReadLine() ?? "").Trim();

            ImmutableList<Book> allBooksByAuthor = _library.AllBooksByAuthor(authorFromUser);

            // Distinct geeft een IEnumerable<Book> terug, daarom gebruiken we ToList()
            // om het om te casten naar een List<Book>
            List<Book> distincList = allBooksByAuthor.Distinct(new BookIsbnComparer()).ToList();
            distincList.Sort((a, b) => a.Title.CompareTo(b.Title));

            Console.WriteLine();

            if (allBooksByAuthor is not null && allBooksByAuthor.Count != 0)
            {
                Logger.LogInfo($"Alle gevonden boeken van {authorFromUser}");
                Console.WriteLine();
                Console.WriteLine();

                foreach (Book book in distincList)
                {
                    Console.WriteLine($"{book.Describe()}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
                Logger.LogError("Geen resultaten gevonden. \n\nControleer de auteursnaam");
                Console.WriteLine();
                Console.WriteLine();
            }

        }

        private void FindBookByIsbnUi()
        {
            Logger.LogInfo("Zoek een boek op basis van ISBN nummer");
            Console.WriteLine();

            Console.Write("Geef de ISBN nummer van het boek in: ");
            string isbnFromUser = (Console.ReadLine() ?? "").Trim();

            Book? foundedBook = _library.FindBookByIsbn(isbnFromUser);
            Console.WriteLine();

            if (foundedBook is not null)
            {
                Logger.LogInfo("Gegevens van het gevonden boek: ");
                Console.WriteLine();
                Console.WriteLine($"{foundedBook.Describe()}");
            }

            else
            {
                Console.WriteLine();
                Logger.LogError("Geen resultaten gevonden. \n\nControleer het ISBN nummer");
                Console.WriteLine();
            }
        }

        private void FindBookByNameAndAuthorUi()
        {
            Logger.LogInfo("Zoek een boek op basis van titel en auteur");
            Console.WriteLine();

            Console.Write("Geef de titel van het boek in: ");
            string titleFromUser = (Console.ReadLine() ?? "").Trim();

            Console.Write("Geef de auteur van het boek in: ");
            string authorFromUser = (Console.ReadLine() ?? "").Trim();
            Console.WriteLine();

            Book? foundedBook = _library.FindBookByNameAndAuthor(titleFromUser, authorFromUser);

            if (foundedBook is not null)
            {
                Logger.LogInfo("Gegevens van het gevonden boek: ");
                Console.WriteLine();
                Console.WriteLine($"{foundedBook.Describe()}");
            }

            else
            {
                Console.WriteLine();
                Logger.LogError("Geen resultaten gevonden.\n\nControleer de titel en auteur");
                Console.WriteLine();
            }

        }

        private void ShowBookEditMenuUi(Book book)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Logger.LogInfo("==== Boekaanpassingsmenu ====");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Wat wil je aanpassen?");
                Console.WriteLine();
                Console.WriteLine("1. Titel");
                Console.WriteLine("2. Auteur");
                Console.WriteLine("3. Uitgever");
                Console.WriteLine("4. Genre");
                //Console.WriteLine("5. Jaar van uitgave");
                //Console.WriteLine("6. Aantal pagina's");
                //Console.WriteLine("7. Taal");
                //Console.WriteLine("8. ISBN");
                //Console.WriteLine("9. Omslag");
                //Console.WriteLine("10. Land van oorsprong");
                Console.WriteLine("0. Afsluiten");

                Console.WriteLine();
                Console.Write("Maak een keuze: ");

                string userChoice = (Console.ReadLine() ?? "").Trim();

                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine();
                        Logger.LogInfo($"Huidige Titel: {book.Title} ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Geef nieuwe Titel in: ");

                        string newTitle = (Console.ReadLine() ?? "").Trim();

                        try
                        {
                            book.ChangeTitle(newTitle);
                            Console.WriteLine();
                            Logger.LogSuccess("Titel succesvol gewijzigd!");
                        }
                        catch (BookValidationExceptions e)
                        {
                            Console.WriteLine();
                            Logger.LogError("Fout bij het wijzigen van de titel", e);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        break;

                    case "2":
                        Console.WriteLine();
                        Logger.LogInfo($"Huidige Auteur: {book.Author} ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Geef nieuwe Auteur in: ");



                        string newAuthor = (Console.ReadLine() ?? "").Trim();

                        try
                        {
                            book.ChangeAuthor(newAuthor);
                            Console.WriteLine();
                            Logger.LogSuccess("Auteur succesvol gewijzigd!");
                        }
                        catch (BookValidationExceptions e)
                        {
                            Console.WriteLine();
                            Logger.LogError("Fout bij het wijzigen van de Auteur", e);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        break;

                    case "3":
                        Console.WriteLine();
                        Logger.LogInfo($"Huidige Uitgever: {book.Publisher ?? "Geen"} ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Geef nieuwe Uitgever in: ");



                        string newPublisher = (Console.ReadLine() ?? "").Trim();

                        try
                        {
                            book.ChangePublisher(newPublisher);
                            Console.WriteLine();
                            Logger.LogSuccess("Uitgever succesvol gewijzigd !");
                        }
                        catch (BookValidationExceptions e)
                        {
                            Console.WriteLine();
                            Logger.LogError("Fout bij het wijzigen van de Uitgever", e);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        break;

                    case "4":
                        Console.WriteLine();
                        Logger.LogInfo($"Huidig Genre: {EnumUtils.ToDutchGenre(book.Genre)}");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Geef een nieuwe Genre in: ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Beschikbare opties: ");
                        Console.WriteLine();

                        EnumUtils.EnumMenuForGenre();
                        Console.WriteLine();
                        Console.Write("Kaak een keuze: ");

                        string newGenreChoice = (Console.ReadLine() ?? "").Trim();

                        try
                        {
                            if (int.TryParse(newGenreChoice, out int parsedValue) && Enum.IsDefined<BooksEnums.Genre>((BooksEnums.Genre)parsedValue))
                            {
                                BooksEnums.Genre newGenre = (BooksEnums.Genre)parsedValue;

                                book.ChangeGenre(newGenre);

                                Console.WriteLine();
                                Logger.LogSuccess("Genre succesvol gewijzigd !");
                            }
                            else
                            {
                                throw new BookValidationExceptions("Gekozen waarde bestaat niet !");
                            }

                        }
                        catch (BookValidationExceptions e)
                        {
                            Console.WriteLine();
                            Logger.LogError("Fout bij het wijzigen van de Genre", e);
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        break;

                    //case "5":
                    //    Console.WriteLine("Optie 5 gekozen.");
                    //    break;

                    //case "6":
                    //    Console.WriteLine("Optie 6 gekozen.");
                    //    break;

                    //case "7":
                    //    Console.WriteLine("Optie 7 gekozen.");
                    //    break;

                    //case "8":
                    //    Console.WriteLine("Optie 8 gekozen.");
                    //    break;

                    //case "9":
                    //    Console.WriteLine("Optie 9 gekozen.");
                    //    break;

                    //case "10":
                    //    Console.WriteLine("Optie 10 gekozen.");
                    //    break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Logger.LogError("Ongeldige keuze");
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine();
            }


        }

        private void EditInfoBookUi()
        {

            if (_library.LibraryAllBooks.Count == 0)
            {
                Logger.LogError("Bibliotheek bevat geen boeken !");
                Console.WriteLine();
                return;
            }


            List<Book> sortedList = new List<Book>(_library.LibraryAllBooks);
            sortedList.Sort((a, b) => a.Title.CompareTo(b.Title));

            foreach (Book book in sortedList)
            {
                Console.WriteLine($"{book.ShortDescribe()}");
                Console.WriteLine();
            }

            Console.WriteLine();

            Logger.LogInfo("Om een boek te bewerken geef een GUID in: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Welk boek wil je bewerken ?: ");

            string guidFromUser = (Console.ReadLine() ?? "").Trim();

            Book? bookToEdit = _library.FindBookByGuid(guidFromUser);

            Console.WriteLine();

            if (bookToEdit is not null)
            {

                ShowBookEditMenuUi(bookToEdit);

            }
            else
            {
                Console.WriteLine();
                Logger.LogError("Controleer de GUID aub");
                Console.WriteLine();
            }


        }


        private void AddBookBytitleAndAuthorUi()
        {
            Logger.LogInfo("Om een nieuw boek aan te maken geef de titel en auteur in :");
            Console.WriteLine();

            Console.Write("Geef de titel in: ");
            string userTitle = Console.ReadLine() ?? "";

            Console.Write("Geef de auteur in: ");
            string userAuthor = Console.ReadLine() ?? "";
            Console.WriteLine();

            // Klasse Book bevat validaties in de setter.
            // try/catch is gebruikt om fouten af te handelen die kunnen optreden tijdens de initialisatie.

            try
            {
                // Hier had ik ook book kunnen toevoegen via _library.AddBook()

                Book newBook = new Book(userTitle, userAuthor, _library);
                Logger.LogSuccess($"Nieuw boek van {newBook.Author} is toegevoegd");
                Console.WriteLine();
            }
            catch (BookValidationExceptions e)
            {
                Logger.LogError("", e);
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw;
            }

        }


        public void ShowBibMenuUi()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Logger.LogInfo("==== Bib Menu ====");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Boek toevoegen op basis van titel en auteur");
                Console.WriteLine("2. Info van een boek aanpassen");
                Console.WriteLine("3. Alle info tonen op basis van titel en auteur");
                Console.WriteLine("4. Boek zoeken (submenu)");
                Console.WriteLine("5. Boek verwijderen");
                Console.WriteLine("6. Alle boeken tonen");
                Console.WriteLine("7. CSV inlezen");
                Console.WriteLine("0. Afsluiten");
                Console.WriteLine();
                Console.Write("Maak een keuze: ");


                string userChoice = (Console.ReadLine() ?? "").Trim();
                Console.WriteLine();

                switch (userChoice)
                {
                    case "1":
                        AddBookBytitleAndAuthorUi();
                        break;
                    case "2":
                        EditInfoBookUi();
                        break;
                    case "3":
                        FindBookByNameAndAuthorUi();
                        break;
                    case "4":
                        SearchBookSubMenuUi();
                        break;
                    case "5":
                        RemoveBookFromLibraryByGuidUi();
                        break;
                    case "6":
                        ShowAllBooksUi();
                        break;
                    case "7":
                        ReadBooksFromCsvUi();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Logger.LogError("Ongeldige keuze");
                        Console.WriteLine();
                        break;
                }

            }

            Console.WriteLine();

        }

    }
}
