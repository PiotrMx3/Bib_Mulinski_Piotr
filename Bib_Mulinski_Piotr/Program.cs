namespace Bib_Mulinski_Piotr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DemoForTessting();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public static void DemoForTessting()
        {
            //string bibName = "";

            //do
            //{
            //    Console.WriteLine("Welkom bij het bibliotheekbeheersysteem. Om te beginne geef de naam van jouw bib in.");
            //    bibName = Console.ReadLine() ?? "";

            //    if (string.IsNullOrWhiteSpace(bibName)) Console.WriteLine("Naam van bib mag niet leeg zijn !");
            //    Console.WriteLine();

            //} while (bibName == "");


            //Library library = new(bibName);

            Library library = new("bib");

            // Author 1: Adam Mickiewicz
            Book book1 = new Book("9788324060000", "Pan Tadeusz", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.History, new DateTime(1834, 1, 1), 340,
                BooksEnums.Language.Polish, BooksEnums.Cover.Hardcover, BooksEnums.Country.Poland, library);

            Book book2 = new Book("9788324060001", "Dziady", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.Fiction, new DateTime(1823, 1, 1), 280,
                BooksEnums.Language.Polish, BooksEnums.Cover.Paperback, BooksEnums.Country.Poland, library);

            Book book3 = new Book("9788324060002", "Konrad Wallenrod", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.History, new DateTime(1828, 1, 1), 190,
                BooksEnums.Language.Polish, BooksEnums.Cover.Hardcover, BooksEnums.Country.Poland, library);

            Book book4 = new Book("9788324060003", "Grażyna", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.Fiction, new DateTime(1823, 1, 1), 150,
                BooksEnums.Language.Polish, BooksEnums.Cover.Paperback, BooksEnums.Country.Poland, library);

            Book book5 = new Book("9788324060004", "Sonety Krymskie", "Adam Mickiewicz", "PWN",
                BooksEnums.Genre.History, new DateTime(1826, 1, 1), 120,
                BooksEnums.Language.Polish, BooksEnums.Cover.Hardcover, BooksEnums.Country.Poland, library);


            // Author 2: J.R.R. Tolkien
            Book book6 = new Book("9780007525546", "In de Ban van de Ring", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(1954, 7, 29), 423,
                BooksEnums.Language.English, BooksEnums.Cover.Paperback, BooksEnums.Country.UnitedKingdom, library);

            Book book7 = new Book("9780007525547", "The Hobbit", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(1937, 9, 21), 310,
                BooksEnums.Language.English, BooksEnums.Cover.Hardcover, BooksEnums.Country.UnitedKingdom, library);

            Book book8 = new Book("9780007525548", "The Silmarillion", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(1977, 9, 15), 365,
                BooksEnums.Language.English, BooksEnums.Cover.Paperback, BooksEnums.Country.UnitedKingdom, library);

            Book book9 = new Book("9780007525549", "Unfinished Tales", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(1980, 1, 1), 400,
                BooksEnums.Language.English, BooksEnums.Cover.Hardcover, BooksEnums.Country.UnitedKingdom, library);

            Book book10 = new Book("9780007525550", "The Children of Húrin", "J.R.R. Tolkien", "HarperCollins",
                BooksEnums.Genre.Fantasy, new DateTime(2007, 1, 1), 320,
                BooksEnums.Language.English, BooksEnums.Cover.Paperback, BooksEnums.Country.UnitedKingdom, library);


            // Author 3: Multatuli
            Book book11 = new Book("9789027439642", "Max Havelaar", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1860, 1, 1), 312,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Hardcover, BooksEnums.Country.Netherlands, library);

            Book book12 = new Book("9789027439643", "Ideeën I", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1862, 1, 1), 290,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Paperback, BooksEnums.Country.Netherlands, library);

            Book book13 = new Book("9789027439644", "Ideeën II", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1864, 1, 1), 310,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Hardcover, BooksEnums.Country.Netherlands, library);

            Book book14 = new Book("9789027439645", "Minnebrieven", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1861, 1, 1), 250,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Paperback, BooksEnums.Country.Netherlands, library);

            Book book15 = new Book("9789027439646", "Woutertje Pieterse", "Multatuli", "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction, new DateTime(1872, 1, 1), 280,
                BooksEnums.Language.Dutch, BooksEnums.Cover.Hardcover, BooksEnums.Country.Netherlands, library);


            // Author 4: Victor Hugo
            Book book16 = new Book("9782070408503", "Les Misérables", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.History, new DateTime(1862, 1, 1), 1232,
                BooksEnums.Language.French, BooksEnums.Cover.Hardcover, BooksEnums.Country.France, library);

            Book book17 = new Book("9782070408504", "Notre-Dame de Paris", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.Fiction, new DateTime(1831, 1, 1), 940,
                BooksEnums.Language.French, BooksEnums.Cover.Paperback, BooksEnums.Country.France, library);

            Book book18 = new Book("9782070408505", "Les Contemplations", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.History, new DateTime(1856, 1, 1), 450,
                BooksEnums.Language.French, BooksEnums.Cover.Hardcover, BooksEnums.Country.France, library);

            Book book19 = new Book("9782070408506", "La Légende des siècles", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.History, new DateTime(1859, 1, 1), 600,
                BooksEnums.Language.French, BooksEnums.Cover.Paperback, BooksEnums.Country.France, library);

            Book book20 = new Book("9782070408507", "L'Homme qui rit", "Victor Hugo", "Gallimard",
                BooksEnums.Genre.Fiction, new DateTime(1869, 1, 1), 720,
                BooksEnums.Language.French, BooksEnums.Cover.Hardcover, BooksEnums.Country.France, library);


            //TODO: logic for switch case find book by Language


            Console.WriteLine("In welke taal boeken zoek jij ?");
            Console.WriteLine();
            BooksEnums.MenuForLang();
            Console.WriteLine();
            Console.WriteLine("Maak een keuze");

            string userInput = Console.ReadLine() ?? "";


            if(int.TryParse(userInput, out int langToCast))
            {
                BooksEnums.Language lang = (BooksEnums.Language)langToCast;

                if (Enum.IsDefined<BooksEnums.Language>(lang))
                {
                    List<Book>? allBooksByLang = library.AllBooksByLanguage(lang);

                    if(allBooksByLang != null && allBooksByLang.Count != 0)
                    {
                        Console.WriteLine($"Boeken met {lang} als Taal");
                        Console.WriteLine();
                        foreach (Book item in allBooksByLang)
                        {
                            Console.WriteLine($"{item.Describe()}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Deze taal bestaat niet.");
                }
            }
            else
            {
                Console.WriteLine("Geef een geldig getal in.");
            }





            //TODO: logic for switch case find book by Author

            //Console.WriteLine("Geef het gewenste Author naam van boek in");
            //string authorFromUser = Console.ReadLine() ?? "";

            //List<Book>? foundedAuthors = library.AllBooksByAuthor(authorFromUser);

            //if (foundedAuthors != null && foundedAuthors.Count!= 0 )
            //{
            //    Console.WriteLine();
            //    Console.WriteLine($"Alle boeken van {authorFromUser}");
            //    Console.WriteLine();

            //    foreach (Book book in foundedAuthors)
            //    {
            //        Console.WriteLine($"{book.Describe()}");
            //        Console.WriteLine();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Geen boeken gevonden!");
            //}




            //TODO: logic for switch case find book by ISBN

            //Console.WriteLine("Geef het ISBN-nummer van het gewenste boek in");
            //        string isbnFromUser = Console.ReadLine() ?? "";
            //        Book? foundedBook = library.FindBookByIsbn(isbnFromUser);

            //        if (foundedBook != null)
            //        {
            //            Console.WriteLine();
            //            Console.WriteLine("Boek gevonden! ");
            //            Console.WriteLine();
            //            Console.WriteLine($"{foundedBook.Describe()}");

            //        }
            //        else
            //        {
            //            Console.WriteLine("Boek niet gevonden.");
            //        }



            // TODO: logic for switch case find book by title and author

            //Console.WriteLine("Geef de titel van het gewenste boek in:?");
            //string title = Console.ReadLine();
            //Console.WriteLine("Geef de Auteur van het gewenste boek in:");
            //string author = Console.ReadLine();

            //Book? foundedBook = library.FindBookByNameAndAuthor(title, author);

            //if (foundedBook != null)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Boek gevonden! ");
            //    Console.WriteLine();
            //    Console.WriteLine($"Omschirijng \n {foundedBook.Describe()}");
            //}
            //else
            //{
            //    Console.WriteLine("Boek niet gevonden.");
            //}





            // TODO: logic for switch case remove book.

            //    if (library.LibraryAllBooks.Count == 0)
            //    {
            //        Console.WriteLine("Geen boeken in de bibliotheen");
            //        return;
            //    }

            //    library.ShowBooksShort();

            //    Console.WriteLine();
            //    Console.WriteLine("Geef een GUID in om een boek te vewijderen");

            //    string guid = Console.ReadLine() ?? "";

            //    Console.WriteLine();
            //    Console.WriteLine($"{library.RemoveBookFromLibrary(guid)}");

            //    Console.WriteLine();
            //    library.ShowBooksShort();

        }

    }

}
