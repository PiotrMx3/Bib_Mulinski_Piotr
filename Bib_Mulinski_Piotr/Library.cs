using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bib_Mulinski_Piotr
{
    internal class Library
    {
        private string _name = "";
        private List<Book> _libraryAllBooks = new();
        private Dictionary<DateTime, ReadingRoomItem> _allReadingRoom = new();


        // Bibliotheek
        public Library(string name)
        {
            Name = name.Trim();
        }

        public ImmutableDictionary<DateTime, ReadingRoomItem> AllReadingRoom
        {
            get { return this._allReadingRoom.ToImmutableDictionary(); }
        }

        public ImmutableList<Book> LibraryAllBooks
        {
            get { return _libraryAllBooks.ToImmutableList(); }
        }


        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Naam van Bib mag niet leeg zijn !");
                _name = value;
            }
        }

        // Bibliotheek


        // Leeszaal

        public void ShowAllMagazines()
        {
            var builder = ImmutableList.CreateBuilder<Magazine>();

            foreach (var item in AllReadingRoom.Values)
            {
                if (item is Magazine magazine)
                {
                    builder.Add(magazine);
                }
            }



            ImmutableList<Magazine> allMagazines = builder.ToImmutableList();

            Console.WriteLine();
            Console.WriteLine("Alle maandbladen uit de leeszaal:");
            Console.WriteLine();

            if (allMagazines.Count == 0)
            {
                Console.WriteLine("Er zijn geen magzines in de leeszaal");
            }
            else
            {
                foreach (Magazine magazine in allMagazines)
                {
                    Console.WriteLine(magazine);
                }
            }

        }
        public void AddMagazine()
        {
            Console.WriteLine("Wat is de naam van het maandblad ?");
            string titleFromUser = (Console.ReadLine() ?? "").Trim();

            Console.WriteLine("Wat is de maand van het maanblad ?");
            string monthFromUser = (Console.ReadLine() ?? "").Trim();

            Console.WriteLine("Wat is het jaar van het maanblad ?");
            string yearFromUser = (Console.ReadLine() ?? "").Trim();

            Console.WriteLine("Wat is de uitgeverij van het maandblad ?");
            string publisherFromUser = (Console.ReadLine() ?? "").Trim();

            bool isByte = byte.TryParse(monthFromUser, out byte monthParsed);
            bool isUint = uint.TryParse(yearFromUser, out uint yearParsed);

            Console.WriteLine();

            if (isByte && isUint)
            {
                try
                {
                    Magazine m = new Magazine(titleFromUser, publisherFromUser, monthParsed, yearParsed);
                    _allReadingRoom.Add(DateTime.Now, m);
                }
                catch (ArgumentException e)
                {
                    Logger.LogError("Fout bij het aanmaken van het magazine", e);
                    Console.WriteLine();
                }
            }
            else
            {
                Logger.LogError("Ongeldige invoer voor maand of jaar !");
                Console.WriteLine();
            }

        }

        public void AddNewsPaper()
        {
            Console.WriteLine("Wat is de naam van de krant ?");
            string titleFromUser = (Console.ReadLine() ?? "").Trim();

            Console.WriteLine("Wat is de datum van de krant ? (dd/MM/jjjj)");
            string dateFromUser = (Console.ReadLine() ?? "").Trim();

            Console.WriteLine("Wat is de uitgeverij van de krant ?");
            string publisherFromUser = (Console.ReadLine() ?? "").Trim();

            Console.WriteLine();

            if (DateTime.TryParse(dateFromUser, out DateTime parsedDate))
            {
                try
                {
                    // OPMERKING: DateTime.Now als key is riskant. (ArgumentException)
                    // Enkel 'veilig' omdat de invoer hier manueel (en dus traag) gebeurt.
                    NewsPaper np = new NewsPaper(titleFromUser, publisherFromUser, parsedDate);

                    _allReadingRoom.Add(DateTime.Now, np);

                }
                catch (ArgumentException e)
                {
                    Logger.LogError("Fout bij het aanmaken van de krant", e);
                    Console.WriteLine();
                }
            }
            else
            {
                Logger.LogError("Datum had een verkeerd formaat");
                Console.WriteLine();
            }

        }


        // Leeszaal


        // Boeken

        public Book? FindBookByGuid(string guid)
        {

            if (!Guid.TryParse(guid.Trim(), out Guid correctGuid))
                return null;

            Book? bookToEdit = LibraryAllBooks.Find(el => el.LibraryBookGuid == correctGuid);

            if (bookToEdit != null)
            {

                return bookToEdit;
            }

            return null;
        }



        public void ReadBooksFromCsv(string path)
        {
            string[] booksFromCsv = File.ReadAllLines(path);

            for (int i = 0; i < booksFromCsv.Length; i++)
            {
                string[] booksLine = booksFromCsv[i].Split(',');

                if (booksLine.Length < 2 || string.IsNullOrWhiteSpace(booksLine[0]) || string.IsNullOrWhiteSpace(booksLine[1]))
                {
                    throw new ArgumentException($"Regel {i + 1}: onjuist CSV-formaat (verwacht minimaal 2 velden: Titel, Auteur). Corrigeer en probeer het opnieuw.");
                }

                Book newBook = new Book(booksLine[0], booksLine[1], this);

            }

        }


        public ImmutableList<Book>? AllBooksByLanguage(BooksEnums.Language lang)
        {
            return LibraryAllBooks.FindAll(el => el.Language == lang);
        }


        public ImmutableList<Book>? AllBooksByAuthor(string author)
        {
            return LibraryAllBooks.FindAll(el => el.Author.ToLower() == author.Trim().ToLower());
        }

        public Book? FindBookByIsbn(string isbn)
        {

            if (isbn.Length != 10 && isbn.Length != 13) return null;

            Book? book = LibraryAllBooks.Find(el => el.Isbn.ToLower() == isbn.Trim().ToLower());
            return book;
        }


        public Book? FindBookByNameAndAuthor(string title, string author)
        {
            Book? book = LibraryAllBooks.Find(el => el.Title.ToLower() == title.Trim().ToLower() && el.Author.ToLower() == author.Trim().ToLower());
            return book;
        }


        public bool RemoveBookFromLibraryByGuid(string guid)
        {

            if (!Guid.TryParse(guid.Trim(), out Guid correctGuid))
                return false;

            Book? bookToRemove = _libraryAllBooks.Find(el => el.LibraryBookGuid == correctGuid);

            if (bookToRemove != null)
            {
                _libraryAllBooks.Remove(bookToRemove);
                return true;
            }

            return false;
        }


        public void AddBook(Book book)
        {
            if (book is null) return;

            _libraryAllBooks.Add(book);
        }

        public void RollBack(List<Book> books)
        {
            _libraryAllBooks = books;
        }


        public void ShowBooksShort()
        {
            {
                foreach (Book book in LibraryAllBooks)
                {
                    Console.WriteLine(book.ShortDescribe());
                    Console.WriteLine();
                }

            }
        }

        // Boeken
    }
}
