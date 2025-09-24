namespace Bib_Mulinski_Piotr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var book = new Book(
    "9788324060000",
    "Pan Tadeusz",
    "Adam Mickiewicz",
    "PWN",
    BooksEnums.Genre.History,
    new DateTime(1834, 1, 1),
    340,
    BooksEnums.Language.Polish,
    BooksEnums.Cover.Hardcover,
    BooksEnums.Country.Poland
);

            Console.WriteLine(book.Describe());

        }
    }
}
