using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class Book : ILendable
    {
        private string _isbn;
        private string _title;
        private string _author;
        private string _publisher;
        private BooksEnums.Genre _genre = BooksEnums.Genre.Unknown;
        private DateTime _year;
        private int _pages;
        private BooksEnums.Language _language = BooksEnums.Language.Unknown;
        private BooksEnums.Cover _coverType = BooksEnums.Cover.Unknown;
        private BooksEnums.Country _originCountry = BooksEnums.Country.Unknown;
        private Guid _libraryBookId;
        private Library _library;
        private bool _isAvailable;
        private DateTime _borrowingDate;
        private int _borrowDays;


        public Book(string title, string author, Library library)
        {
            Title = title.Trim();
            Author = author.Trim();
            Library = library;
            LibraryBookGuid = Guid.NewGuid();

            IsAvailable = true;
            Library.AddBook(this);
        }

        public Book
        (
            string isbn, string title, string author, string publisher, BooksEnums.Genre genre, DateTime year,
            int pages, BooksEnums.Language language, BooksEnums.Cover coverType, BooksEnums.Country originCountry, Library library
        )

        {

            Isbn = isbn.Trim();
            Title = title.Trim();
            Author = author.Trim();
            Publisher = publisher.Trim();
            Genre = genre;
            Year = year;
            Pages = pages;
            Language = language;
            CoverType = coverType;
            OriginCountry = originCountry;
            LibraryBookGuid = Guid.NewGuid();
            Library = library;

            IsAvailable = true;
            Library.AddBook(this);

        }

        // Interface ILendable
        public bool IsAvailable
        {
            get { return this._isAvailable; }
            set { this._isAvailable = value; }
        }
        public DateTime BorrowingDate
        {
            get { return this._borrowingDate; }
            set { this._borrowingDate = value; }
        }
        public int BorrowDays
        {
            get { return this._borrowDays; }
            set { this._borrowDays = value; }
        }

        public void Borrow()
        {
            if (!IsAvailable)
            {
                Logger.LogError("Deze boek is niet beschikbaar !");
                Console.WriteLine();
                return;
            }

            BorrowDays = Genre is BooksEnums.Genre.Education ? 20 : 10;

            BorrowingDate = DateTime.Now;
            IsAvailable = false;

            Logger.LogSuccess($"Het boek dient ten laatste teruggebracht te worden op {BorrowingDate.AddDays(BorrowDays).ToString("dddd d MMMM yyyy", new CultureInfo("nl-BE"))}.");


        }

        public void Return()
        {
            IsAvailable = true;

            DateTime deadline = BorrowingDate.AddDays(BorrowDays);

            if(DateTime.Now > deadline)
            {
                int daysLate = (int)(DateTime.Now - deadline).TotalDays;

                if (daysLate == 0) daysLate = 1;

                Logger.LogError($"Het boek is {daysLate} dag(en) te laat teruggebracht!");
            }
            else
            {
                Logger.LogSuccess($"Het boek is op tijd teruggebracht !");
            }


        }

        //

        public Library Library
        {
            get { return _library; }
            private set { _library = value; }
        }

        public Guid LibraryBookGuid
        {
            get { return this._libraryBookId; }
            private set { this._libraryBookId = value; }
        }

        public BooksEnums.Country OriginCountry
        {
            get { return _originCountry; }
            private set { _originCountry = value; }
        }

        public BooksEnums.Cover CoverType
        {
            get { return _coverType; }
            private set { _coverType = value; }
        }

        public BooksEnums.Language Language
        {
            get { return _language; }
            private set { _language = value; }
        }

        public int Pages
        {
            get { return _pages; }
            private set
            {
                if (value < 0) throw new BookValueOutOfRangeException("Aantal paginas kan niet negatief zijn.");

                _pages = value;
            }
        }

        public DateTime Year
        {
            get { return _year; }
            private set
            {
                if (value.Year < 1400 || value.Year > DateTime.Now.Year) throw new BookValueOutOfRangeException("Ongeldige jaar van boek");
                _year = value;
            }
        }

        public BooksEnums.Genre Genre
        {
            get { return _genre; }
            private set { _genre = value; }
        }

        public void ChangeGenre(BooksEnums.Genre newGenre)
        {
            Genre = newGenre;
        }

        public string Publisher
        {
            get { return _publisher; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new BookRequiredFieldException("Uitgever van boek mag niet leeg zijn !");
                _publisher = value;
            }
        }

        public void ChangePublisher(string newPublisher)
        {
            Publisher = newPublisher;
        }

        public string Author
        {
            get { return _author; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new BookRequiredFieldException("Auteur van boek mag niet leeg zijn !");
                _author = value;
            }
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public string Title
        {
            get { return _title; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new BookRequiredFieldException("Titel van boek mag niet leeg zijn !");
                _title = value;
            }
        }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }

        public string Isbn
        {
            get { return _isbn; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new BookRequiredFieldException("ISBN van boek mag niet leeg zijn !");
                if (value.Length != 10 && value.Length != 13) throw new InvalidIsbnException("ISBN moet 10 of 13 karakters lang zijn!");

                _isbn = value;
            }
        }

        public string ShortDescribe()
        {
            return $"{Title} - {Author} | ISBN: {Isbn ?? "[LEEG]"} | GUID: {LibraryBookGuid}";
        }

        public string Describe()
        {
            return $"Boek info:\n" +
                   $"{"Bibliotheek",-20}: {Library.Name}\n" +
                   $"{"LibraryBoekId",-20}: {LibraryBookGuid}\n" +
                   $"{"Titel",-20}: {Title}\n" +
                   $"{"Auteur",-20}: {Author}\n" +
                   $"{"Uitgever",-20}: {Publisher ?? "[LEEG]"}\n" +
                   $"{"Genre",-20}: {EnumUtlis.ToDutchGenre(Genre)}\n" +
                   $"{"Jaar",-20}: {Year}\n" +
                   $"{"Paginas",-20}: {(Pages == 0 ? "[LEEG]" : Pages)}\n" +
                   $"{"Taal",-20}: {EnumUtlis.ToDutchLang(Language)}\n" +
                   $"{"ISBN",-20}: {Isbn ?? "[LEEG]"}\n" +
                   $"{"Cover",-20}: {EnumUtlis.ToDutchCover(CoverType)}\n" +
                   $"{"Land oorspr.",-20}: {EnumUtlis.ToDutchCountry(OriginCountry)}\n" +
                   $"";
        }

    }
}
