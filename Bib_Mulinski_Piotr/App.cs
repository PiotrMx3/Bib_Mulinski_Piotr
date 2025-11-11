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
            MockNewsPapers();
            MockMagazines();

            _menuLibrary.ShowBibMenuUi();
            _menuReadingRoom.ShowReadingRoomMenuUi();

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

        private void MockMagazines()
        {
            Magazine magazine1 = new Magazine("Knack", "Roularta Media Group", 10, 2023);
            Magazine magazine2 = new Magazine("Libelle", "Roularta Media Group", 11, 2023);
            Magazine magazine3 = new Magazine("Humo", "DPG Media", 9, 2023);
            Magazine magazine4 = new Magazine("De Tijd", "Mediafin", 8, 2022);
            Magazine magazine5 = new Magazine("Feeling", "Roularta Media Group", 1, 2024);
            Magazine magazine6 = new Magazine("Flair", "Roularta Media Group", 5, 2023);
            Magazine magazine7 = new Magazine("Wonen Landelijke Stijl", "Sanoma", 7, 2023);
            Magazine magazine8 = new Magazine("Autogids", "ProduPress", 4, 2024);
            Magazine magazine9 = new Magazine("Njam!", "Studio 100", 3, 2023);
            Magazine magazine10 = new Magazine("Trends", "Roularta Media Group", 2, 2024);
        }

        private void MockNewsPapers()
        {
            NewsPaper newspaper1 = new NewsPaper("De Standaard", "Mediahuis", new DateTime(2024, 5, 10));
            NewsPaper newspaper2 = new NewsPaper("De Morgen", "DPG Media", new DateTime(2024, 5, 10));
            NewsPaper newspaper3 = new NewsPaper("Het Laatste Nieuws", "DPG Media", new DateTime(2024, 5, 9));
            NewsPaper newspaper4 = new NewsPaper("Het Nieuwsblad", "Mediahuis", new DateTime(2024, 5, 10));
            NewsPaper newspaper5 = new NewsPaper("De Tijd", "Mediafin", new DateTime(2024, 5, 8));
            NewsPaper newspaper6 = new NewsPaper("Gazet van Antwerpen", "Mediahuis", new DateTime(2024, 5, 10));
            NewsPaper newspaper7 = new NewsPaper("Het Belang van Limburg", "Mediahuis", new DateTime(2024, 5, 9));
            NewsPaper newspaper8 = new NewsPaper("Metro", "Mass Transit Media", new DateTime(2024, 5, 7));
            NewsPaper newspaper9 = new NewsPaper("Het Laatste Nieuws", "DPG Media", new DateTime(2024, 5, 10));
            NewsPaper newspaper10 = new NewsPaper("De Standaard", "Mediahuis", new DateTime(2024, 5, 9));
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

