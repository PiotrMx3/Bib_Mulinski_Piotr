using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bib_Mulinski_Piotr
{
    internal class App
    {
        private Library _library = null!;
        private LibraryMenuUi _menuLibrary = null!;
        private ReadingRoomMenuUi _menuReadingRoom = null!;


        public void Run()
        {
            this._library = InitBibNameUi();
            this._menuLibrary = new LibraryMenuUi(this._library);
            this._menuReadingRoom = new ReadingRoomMenuUi(this._library);

            MockBooks();

            bool isRunning = true;

            while (isRunning)
            {
                Logger.LogInfo("==== Menu ====");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Biobliotheek Menu");
                Console.WriteLine("2. Leeszaal Menu");
                Console.WriteLine("0. Afsluiten");
                Console.WriteLine();
                Console.Write("Maak een keuze: ");


                string userChoice = (Console.ReadLine() ?? "").Trim();
                Console.WriteLine();

                switch (userChoice)
                {
                    case "1":
                        _menuLibrary.ShowBibMenuUi();
                        break;
                    case "2":
                        _menuReadingRoom.ShowReadingRoomMenuUi();
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

        private Library InitBibNameUi()
        {
            string bibName = "";

            do
            {
                Logger.LogInfo("Welkom bij het bibliotheekbeheersysteem \nOm te beginnen geef de naam van jouw bib in: ");

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

