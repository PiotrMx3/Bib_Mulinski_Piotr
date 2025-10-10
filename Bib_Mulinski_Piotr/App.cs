using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bib_Mulinski_Piotr
{
    internal class App
    {

        private Library _library = null!;

        public void Run()
        {
            _library = InitBibNameUi();

            MockBooks();
            ShowBibMenuUi();

        }

        //TODO: UML aanpassen SearchBookSubMenu()
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

        //TODO: UML aanpassen AllBooksByLanguageUi()

        private void AllBooksByLanguageUi()
        {
            Logger.LogInfo("Geef een gewenste Taal in: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Beschikbare opties: ");
            Console.WriteLine();

            EnumUtlis.EnumMenuForLang();
            Console.WriteLine();

            Console.Write("Maak een keuze: ");

            string langChoice = (Console.ReadLine() ?? "").Trim();


            if (int.TryParse(langChoice, out int parsedValue) && Enum.IsDefined<BooksEnums.Language>((BooksEnums.Language)parsedValue))
            {
                BooksEnums.Language langFromUser = (BooksEnums.Language)parsedValue;
                ImmutableList<Book>? allBooksByLang = _library.AllBooksByLanguage(langFromUser);

                if (allBooksByLang is not null && allBooksByLang.Count != 0)
                {
                    Logger.LogInfo($"Gevonden boeken in {EnumUtlis.ToDutchLang(langFromUser)}");
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
                    Logger.LogError("Geen resultaten gevonden.");
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


        //TODO: UML aanpassen FindBooksByAutor()
        private void FindBooksByAutorUi()
        {
            Logger.LogInfo("Zoek alle boeken op basis van Auteur.");
            Console.WriteLine();
            Console.Write("Geef de gewenste Auteur van het boek in: ");
            string authorFromUser = (Console.ReadLine() ?? "").Trim();

            ImmutableList<Book>? allBooksByAuthor = _library.AllBooksByAuthor(authorFromUser);
            Console.WriteLine();

            if(allBooksByAuthor is not null && allBooksByAuthor.Count != 0)
            {
                Logger.LogInfo($"Alle gevonden boeken van {authorFromUser}");
                Console.WriteLine();
                Console.WriteLine();

                foreach (Book book in allBooksByAuthor)
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

        //TODO: UML aanpassen FindBookByIsbnUi()
        private void FindBookByIsbnUi()
        {
            Logger.LogInfo("Zoek een boek op basis van ISBN nummer.");
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

        //TODO: UML aanpassen FindBookByNameAndAuthorUi()
        private void FindBookByNameAndAuthorUi()
        {
            Logger.LogInfo("Zoek een boek op basis van titel en auteur.");
            Console.WriteLine();

            Console.Write("Geef de titel van het boek in: ");
            string titleFromUser = (Console.ReadLine() ?? "").Trim();

            Console.Write("Geef de auteur van het boek in: ");
            string authorFromUser = (Console.ReadLine() ?? "").Trim();
            Console.WriteLine();

            Book? foundedBook = _library.FindBookByNameAndAuthor(titleFromUser,authorFromUser);

            if(foundedBook is not null)
            {
                Logger.LogInfo("Gegevens van het gevonden boek: ");
                Console.WriteLine();
                Console.WriteLine($"{foundedBook.Describe()}");
            }

            else
            {
                Console.WriteLine();
                Logger.LogError("Geen resultaten gevonden.\n\nControleer de titel en auteur.");
                Console.WriteLine();
            }

        }

        //TODO: UML aanpassen ShowBookEditMenu()
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
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Logger.LogError("Fout bij het wijzigen van de titel", e);
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
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Logger.LogError("Fout bij het wijzigen van de Auteur", e);
                        }

                        break;

                    case "3":
                        Console.WriteLine();
                        Logger.LogInfo($"Huidige Uitgever {book.Publisher} ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Geef nieuwe Uitgever in: ");



                        string newPublisher = (Console.ReadLine() ?? "").Trim();

                        try
                        {
                            book.ChangePublisher(newPublisher);
                            Console.WriteLine();
                            Logger.LogSuccess("Uitgever succesvol gewijzigd!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Logger.LogError("Fout bij het wijzigen van de Uitgever", e);
                        }

                        break;

                    case "4":
                        Console.WriteLine();
                        Logger.LogInfo($"Huidig Genre {EnumUtlis.ToDutchGenre(book.Genre)}");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Geef een nieuwe Genre in: ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Beschikbare opties: ");
                        Console.WriteLine();

                        EnumUtlis.EnumMenuForGenre();
                        Console.WriteLine();
                        Console.Write("Kaak een keuze: ");

                        string newGenreChoice = (Console.ReadLine()?? "").Trim();

                        try
                        {
                            if(int.TryParse(newGenreChoice, out int parsedValue) && Enum.IsDefined<BooksEnums.Genre>((BooksEnums.Genre)parsedValue))
                            {
                                BooksEnums.Genre newGenre = (BooksEnums.Genre)parsedValue;

                                book.ChangeGenre(newGenre);

                                Console.WriteLine();
                                Logger.LogSuccess("Genre succesvol gewijzigd!");
                            } else
                            {
                                throw new ArgumentException("Gekozen waarde bestaat niet !");
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Logger.LogError("Fout bij het wijzigen van de Genre", e);
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

            if(_library.LibraryAllBooks.Count == 0)
            {
                Logger.LogError("Bibliotheek bevat geen boeken !");
                Console.WriteLine();
                return;
            }


            foreach (Book book in _library.LibraryAllBooks)
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

            if(bookToEdit is not null)
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
            Logger.LogInfo("Om een nieuw boek aan te maken geef de titel en auteur in");
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
                Book newBook = new Book(userTitle, userAuthor, _library);

                Logger.LogSuccess($"Nieuw boek van {newBook.Author} is toegevoegd");
                Console.WriteLine();
            }
            catch (Exception e)
            {

                Logger.LogError("", e);
                Console.WriteLine();
            }



        }


        private  void ShowBibMenuUi()
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
                //Console.WriteLine("5. Boek verwijderen");
                //Console.WriteLine("6. Alle boeken tonen");
                //Console.WriteLine("7. CSV inlezen");
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


        private Library InitBibNameUi()
        {
            string bibName = "";

            do
            {
                Logger.LogInfo("Welkom bij het bibliotheekbeheersysteem \nOm te beginne geef de naam van jouw bib in: ");

                bibName = Console.ReadLine() ?? "";
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(bibName)) Logger.LogError("Naam van bib mag niet leeg zijn !");
                Console.WriteLine();

            } while (bibName == "");

            Library library = new(bibName);

            return library;


        }
        private void MockBooks()
        {
            //Author 1: Adam Mickiewicz
            Book book1 = new Book("9788324060000", "Pan Tadeusz", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.History, new DateTime(1834, 1, 1), 340,
                BooksEnums.Language.Polish, BooksEnums.Cover.Hardcover, BooksEnums.Country.Poland, _library);

            Book book2 = new Book("9788324060001", "Dziady", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.Fiction, new DateTime(1823, 1, 1), 280,
                BooksEnums.Language.Polish, BooksEnums.Cover.Paperback, BooksEnums.Country.Poland, _library);

            Book book3 = new Book("9788324060002", "Konrad Wallenrod", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.History, new DateTime(1828, 1, 1), 190,
                BooksEnums.Language.Polish, BooksEnums.Cover.Hardcover, BooksEnums.Country.Poland, _library);

            Book book4 = new Book("9788324060003", "Grażyna", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.Fiction, new DateTime(1823, 1, 1), 150,
                BooksEnums.Language.Polish, BooksEnums.Cover.Paperback, BooksEnums.Country.Poland, _library);

            Book book5 = new Book("9788324060004", "Sonety Krymskie", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.History, new DateTime(1826, 1, 1), 120,
                BooksEnums.Language.Polish, BooksEnums.Cover.Hardcover, BooksEnums.Country.Poland, _library);


            // Author 2: J.R.R. Tolkien
            Book book6 = new Book("9780007525546", "In de Ban van de Ring", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(1954, 7, 29), 423,
                BooksEnums.Language.English, BooksEnums.Cover.Paperback, BooksEnums.Country.UnitedKingdom, _library);

            Book book7 = new Book("9780007525547", "The Hobbit", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(1937, 9, 21), 310,
                BooksEnums.Language.English, BooksEnums.Cover.Hardcover, BooksEnums.Country.UnitedKingdom, _library);

            Book book8 = new Book("9780007525548", "The Silmarillion", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(1977, 9, 15), 365,
                BooksEnums.Language.English, BooksEnums.Cover.Paperback, BooksEnums.Country.UnitedKingdom, _library);

            Book book9 = new Book("9780007525549", "Unfinished Tales", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(1980, 1, 1), 400,
                BooksEnums.Language.English, BooksEnums.Cover.Hardcover, BooksEnums.Country.UnitedKingdom, _library);

            Book book10 = new Book("9780007525550", "The Children of Húrin", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(2007, 1, 1), 320,
                BooksEnums.Language.English, BooksEnums.Cover.Paperback, BooksEnums.Country.UnitedKingdom, _library);


            // Author 3: Multatuli
            Book book11 = new Book("9789027439642", "Max Havelaar", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1860, 1, 1), 312,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Hardcover, BooksEnums.Country.Netherlands, _library);

            Book book12 = new Book("9789027439643", "Ideeën I", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1862, 1, 1), 290,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Paperback, BooksEnums.Country.Netherlands, _library);

            Book book13 = new Book("9789027439644", "Ideeën II", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1864, 1, 1), 310,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Hardcover, BooksEnums.Country.Netherlands, _library);

            Book book14 = new Book("9789027439645", "Minnebrieven", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1861, 1, 1), 250,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Paperback, BooksEnums.Country.Netherlands, _library);

            Book book15 = new Book("9789027439646", "Woutertje Pieterse", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1872, 1, 1), 280,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Hardcover, BooksEnums.Country.Netherlands, _library);


            // Author 4: Victor Hugo
            Book book16 = new Book("9782070408503", "Les Misérables", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.History, new DateTime(1862, 1, 1), 1232,
                BooksEnums.Language.French, BooksEnums.Cover.Hardcover, BooksEnums.Country.France, _library);

            Book book17 = new Book("9782070408504", "Notre-Dame de Paris", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.Fiction, new DateTime(1831, 1, 1), 940,
                BooksEnums.Language.French, BooksEnums.Cover.Paperback, BooksEnums.Country.France, _library);

            Book book18 = new Book("9782070408505", "Les Contemplations", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.History, new DateTime(1856, 1, 1), 450,
                BooksEnums.Language.French, BooksEnums.Cover.Hardcover, BooksEnums.Country.France, _library);

            Book book19 = new Book("9782070408506", "La Légende des siècles", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.History, new DateTime(1859, 1, 1), 600,
                BooksEnums.Language.French, BooksEnums.Cover.Paperback, BooksEnums.Country.France, _library);

            Book book20 = new Book("9782070408507", "L'Homme qui rit", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.Fiction, new DateTime(1869, 1, 1), 720,
                BooksEnums.Language.French, BooksEnums.Cover.Hardcover, BooksEnums.Country.France, _library);
        }
    }
}

