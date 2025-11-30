using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class Library
    {
        private string _name = "";
        private ICollection<Book> _libraryAllBooks = [];
        private Dictionary<DateTime, ReadingRoomItem> _allReadingRoom = new() { { DateTime.Now, new Magazine("Data News", "Roularta", 9, 2023) }, { DateTime.Now, new NewsPaper("Gazet van Antwerpen", "Mediahuis", new DateTime(2025, 03, 01)) } };
        private Dictionary<string, ICollection<Guid>> _borrowBooksByUser = new Dictionary<string, ICollection<Guid>>();

        public ImmutableDictionary<string, ICollection<Guid>> BorrowBooksByUser
        {
            get { return _borrowBooksByUser.ToImmutableDictionary(); }
        }

        public void AddBookGuidBorrow(string name, Guid guid)
        {
            if (!_borrowBooksByUser.ContainsKey(name))
            {
                _borrowBooksByUser.Add(name, new List<Guid>() { guid });

            }
            else
            {
                _borrowBooksByUser[name].Add(guid);            
            }
        }

        public void RemoveUserWithEmptyBorrowList(string key)
        {
            // Hier doen we geen check, want deze key komt uit BorrowMenuUi
            // De key is daar al gecontroleerd 
            _borrowBooksByUser.Remove(key);
        }


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

        public void AcquisitionReadingRoomToday()
        {
            // Geeft een object terug met enkel de datum de tijd staat op 00:00:00
            DateTime dateToday = DateTime.Now.Date;

            var builder = ImmutableList.CreateBuilder<ReadingRoomItem>();


            foreach (var kv in AllReadingRoom)
            {
                if (kv.Key.Date == dateToday) builder.Add(kv.Value);
            }


            ImmutableList<ReadingRoomItem> allToday = builder.ToImmutableList();

            Console.WriteLine();
            Logger.LogSuccess($"Aanwinsten in de leeszaal van {dateToday.ToString("dddd d MMMM yyyy", new CultureInfo("nl-Be"))} :");
            Console.WriteLine();

            if (allToday.Count == 0)
            {
                Logger.LogInfo("Vandaag zijn er geen tijdschriften in de leeszaal");
            }
            else
            {
                foreach (var readingItem in allToday)
                {
                    Console.WriteLine(readingItem.Identification);
                }
            }
            Console.WriteLine();

        }

        public void ShowAllNewspapers()
        {
            var builder = ImmutableList.CreateBuilder<NewsPaper>();

            foreach (var item in AllReadingRoom.Values)
            {
                if (item is NewsPaper newsPaper)
                {
                    builder.Add(newsPaper);
                }
            }

            ImmutableList<NewsPaper> allNewspapers = builder.ToImmutableList();

            Console.WriteLine();
            Logger.LogSuccess("De kranten in de leeszaal:");
            Console.WriteLine();

            if (allNewspapers.Count == 0)
            {
                Logger.LogInfo("Er zijn geen kranten in de leeszaal");
            }
            else
            {
                foreach (NewsPaper newsPaper in allNewspapers)
                {
                    Console.WriteLine(newsPaper);
                }
            }
            Console.WriteLine();

        }


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
            Logger.LogSuccess("Alle maandbladen uit de leeszaal:");
            Console.WriteLine();

            if (allMagazines.Count == 0)
            {
                Logger.LogInfo("Er zijn geen maandbladen in de leeszaal");
            }
            else
            {
                foreach (Magazine magazine in allMagazines)
                {
                    Console.WriteLine(magazine);
                }
            }
            Console.WriteLine();

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

                    Logger.LogSuccess($"Maandblad - {m.Identification} is toegevoegd !");
                    Console.WriteLine();
                }
                catch (BookValidationExceptions e)
                {
                    Logger.LogError("Fout bij het aanmaken van het magazine", e);
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    throw;
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

                    Logger.LogSuccess($"Krant - {np.Identification} is toegevoegd !");
                    Console.WriteLine();

                }
                catch (BookValidationExceptions e)
                {
                    Logger.LogError("Fout bij het aanmaken van de krant", e);
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    throw;
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
           
            if (!Guid.TryParse(guid, out Guid correctGuid))
                return null;

            Book? findedBook = LibraryAllBooks.Find(el => el.LibraryBookGuid == correctGuid);

            if (findedBook != null)
            {

                return findedBook;
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
                    throw new BookValidationExceptions($"Regel {i + 1}: onjuist CSV-formaat (verwacht minimaal 2 velden: Titel, Auteur). Corrigeer en probeer het opnieuw.");
                }

                Book newBook = new Book(booksLine[0], booksLine[1], this);

            }

        }


        public ImmutableList<Book> AllBooksByLanguage(BooksEnums.Language lang)
        {
            return LibraryAllBooks.FindAll(el => el.Language == lang);
        }


        public ImmutableList<Book> AllBooksByAuthor(string author)
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

            Book? bookToRemove = LibraryAllBooks.Find(el => el.LibraryBookGuid == correctGuid);

            if (bookToRemove != null)
            {
                if (!bookToRemove.IsAvailable) return false;

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
