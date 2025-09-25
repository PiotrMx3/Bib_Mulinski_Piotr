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


            Book book1 = new Book(
                "9788324060000",
                "Pan Tadeusz",
                "Adam Mickiewicz",
                "PWN",
                BooksEnums.Genre.History,
                new DateTime(1834, 1, 1),
                340,
                BooksEnums.Language.Polish,
                BooksEnums.Cover.Hardcover,
                BooksEnums.Country.Poland,
                library
            );

            Book book2 = new Book(
                "9780007525546",
                "In de Ban van de Ring",
                "J.R.R. Tolkien",
                "HarperCollins",
                BooksEnums.Genre.Fantasy,
                new DateTime(1954, 7, 29),
                423,
                BooksEnums.Language.English,
                BooksEnums.Cover.Paperback,
                BooksEnums.Country.UnitedKingdom,
                library
            );

            Book book3 = new Book(
                "9789027439642",
                "Max Havelaar",
                "Multatuli",
                "Uitgeverij Bert Bakker",
                BooksEnums.Genre.Fiction,
                new DateTime(1860, 1, 1),
                312,
                BooksEnums.Language.Dutch,
                BooksEnums.Cover.Hardcover,
                BooksEnums.Country.Netherlands,
                library
            );

            Book book4 = new Book(
                "9782070408503",
                "Les Misérables",
                "Victor Hugo",
                "Gallimard",
                BooksEnums.Genre.History,
                new DateTime(1862, 1, 1),
                1232,
                BooksEnums.Language.French,
                BooksEnums.Cover.Hardcover,
                BooksEnums.Country.France,
                library
            );

            Book book5 = new Book(
                "9780140449136",
                "De Odyssee",
                "Homer",
                "Penguin Classics",
                BooksEnums.Genre.Fiction,
                new DateTime(1401, 1, 1),
                541,
                BooksEnums.Language.Greek,
                BooksEnums.Cover.Paperback,
                BooksEnums.Country.Greece,
                library
            );

            // TODO: logic for switch case find book by ISBN


            //Console.WriteLine("Geef het ISBN-nummer van het gewenste boek in");
            //string isbnFromUser = Console.ReadLine();
            //Book? foundedBook = library.FindBookByIsbn(isbnFromUser);

            //if (foundedBook != null)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Boek gevonden! ");
            //    Console.WriteLine();
            //    Console.WriteLine($"{foundedBook.Describe()}");

            //}
            //else
            //{
            //    Console.WriteLine("Boek niet gevonden.");
            //}



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
