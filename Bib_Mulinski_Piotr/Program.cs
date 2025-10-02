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

            try
            {
                App app = new App();
                app.Run();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }



            //TODO: logic for switch case CSVReading

            //library.ReadBooksFromCsv("csvBooks.txt", library);

            //foreach (var item in library.LibraryAllBooks)
            //{
            //    Console.WriteLine($"{item.Describe()}");

            //}


            //TODO: logic for switch case find book by Language


            //Console.WriteLine("In welke taal boeken zoek jij ?");
            //Console.WriteLine();
            //EnumUtlis.MenuForLang();
            //Console.WriteLine();
            //Console.WriteLine("Maak een keuze");


            //string userInput = Console.ReadLine() ?? "".Trim();

            //if (int.TryParse(userInput, out int langToCast))
            //{
            //    BooksEnums.Language lang = (BooksEnums.Language)langToCast;

            //    if (Enum.IsDefined<BooksEnums.Language>(lang))
            //    {
            //        List<Book>? allBooksByLang = library.AllBooksByLanguage(lang);

            //        if (allBooksByLang != null && allBooksByLang.Count != 0)
            //        {
            //            Console.WriteLine($"Boeken met {lang} als Taal");
            //            Console.WriteLine();
            //            foreach (Book item in allBooksByLang)
            //            {
            //                Console.WriteLine($"{item.Describe()}");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Geen boeken gevonden in {lang}.");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Deze taal bestaat niet.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Geef een geldig getal in.");
            //}





            //TODO: logic for switch case find book by Author

            //Console.WriteLine("Geef het gewenste Author naam van boek in");
            //string authorFromUser = Console.ReadLine() ?? "".Trim();

            //List<Book>? foundedAuthors = library.AllBooksByAuthor(authorFromUser);

            //if (foundedAuthors != null && foundedAuthors.Count != 0)
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
            //string isbnFromUser = Console.ReadLine() ?? "";
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
            //        Console.WriteLine("Geen boeken in de bibliotheek");
            //        return;
            //    }

            //    library.ShowBooksShort();

            //    Console.WriteLine();
            //    Console.WriteLine("Geef een GUID in om een boek te vewijderen");

            //    string guid = Console.ReadLine() ?? "".Trim();

            //    Console.WriteLine();
            //    Console.WriteLine($"{library.RemoveBookFromLibrary(guid)}");

            //    Console.WriteLine();
            //    library.ShowBooksShort();

        }

    }

}
