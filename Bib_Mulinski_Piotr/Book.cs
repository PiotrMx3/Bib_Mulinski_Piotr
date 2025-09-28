using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class Book
    {
		private string _isbn;
		private string _title;
		private string _author;
		private string _publisher;
		private BooksEnums.Genre _genre;
		private DateTime _year;
		private int _pages;
		private BooksEnums.Language _language;
		private BooksEnums.Cover _coverType;
		private BooksEnums.Country _originCountry;
		private Guid _libraryBookId;
		private Library _library;





		public Book (string title, string author, Library library)
		{
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Titel van boek mag niet leeg zijn !");
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Auteur van boek mag niet leeg zijn !");

            Title = title;
            Author = author;
            LibraryBookId = Guid.NewGuid();
            Library = library;

            Library.AddBook(this);
        }

        public Book
		(
			string isbn, string title, string author, string publisher, BooksEnums.Genre genre, DateTime year,
			int pages, BooksEnums.Language language, BooksEnums.Cover coverType, BooksEnums.Country originCountry, Library library
		)

		{

			if(string.IsNullOrWhiteSpace(isbn)) throw new ArgumentException("ISBN van boek mag niet leeg zijn !");
			if(isbn.Length != 10 && isbn.Length != 13) throw new ArgumentException("ISBN moet 10 of 13 karakters lang zijn!");

			if(string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Titel van boek mag niet leeg zijn !");
            if(string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Auteur van boek mag niet leeg zijn !");
            if(string.IsNullOrWhiteSpace(publisher)) throw new ArgumentException("Uitgever van boek mag niet leeg zijn !");
			if(year.Year < 1400 || year.Year > DateTime.Now.Year) throw new ArgumentException("Ongeldig jaar van boek.");


            Isbn = isbn;
            Title = title;
            Author = author;
            Publisher = publisher;
            Genre = genre;
            Year = year;
            Pages = pages;
            Language = language;
            CoverType = coverType;
            OriginCountry = originCountry;
            LibraryBookId = Guid.NewGuid();
			Library = library;

			Library.AddBook(this);

        }
		public Library Library
		{
			get { return _library; }
			private set { _library = value; }
		}

        public Guid LibraryBookId
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
			set { _language = value; }
		}

		public int Pages
		{
			get { return _pages; }
			private set { _pages = value; }
		}

		public DateTime Year
		{
			get { return _year; }
			private set { _year = value; }
		}

		public BooksEnums.Genre Genre
		{
			get { return _genre; }
			private set {  _genre= value; }
		}
        public string Publisher
        {
            get { return _publisher; }
            private set { _publisher = value; }
        }

        public string Author
		{
			get { return _author; }
			private set { _author = value; }
		}

		public string Title
		{
			get { return _title; }
			private set { _title = value; }
		}

		public string Isbn
		{
			get { return _isbn; }
			private set { _isbn = value; }
		}


        public string ShortDescribe()
        {
            return $"{Title} - {Author} | ISBN: {Isbn} | GUID: {LibraryBookId}";
        }

        public string Describe()
        {
            return $"Boek info:\n" +
                   $"{"Bibliotheek",-20}: {Library}\n" +
                   $"{"LibraryBookId",-20}: {LibraryBookId}\n" +
                   $"{"Titel",-20}: {Title}\n" +
                   $"{"Auteur",-20}: {Author}\n" +
                   $"{"Uitgever",-20}: {Publisher ?? "Geen Uitgever"}\n" +
                   $"{"Genre",-20}: {Genre}\n" +
                   $"{"Jaar",-20}: {Year.Year}\n" +
                   $"{"Paginas",-20}: {Pages}\n" +
                   $"{"Taal",-20}: {Language}\n" +
                   $"{"ISBN",-20}: {Isbn}\n" +
                   $"{"Cover",-20}: {CoverType}\n" +
                   $"{"Land oorspr.",-20}: {OriginCountry}\n" +
				   $"";
        }


    }
}
