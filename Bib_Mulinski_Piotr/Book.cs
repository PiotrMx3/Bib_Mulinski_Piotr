﻿using System;
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
		private BooksEnums.Genre _genre = BooksEnums.Genre.Unknown;
		private DateTime _year;
		private int _pages;
		private BooksEnums.Language _language = BooksEnums.Language.Unknown;
		private BooksEnums.Cover _coverType = BooksEnums.Cover.Unknown;
		private BooksEnums.Country _originCountry = BooksEnums.Country.Unknown;
		private Guid _libraryBookId;
		private Library _library;

		public Book (string title, string author, Library library)
		{
			Title = title.Trim();
			Author = author.Trim();
            Library = library;
            LibraryBookGuid = Guid.NewGuid();

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

			Library.AddBook(this);

        }
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
			private set
			{
                if (value.Year < 1400 || value.Year > DateTime.Now.Year) throw new ArgumentException("Ongeldig jaar van boek.");
                _year = value;
			}
		}

		public BooksEnums.Genre Genre
		{
			get { return _genre; }
			private set {  _genre= value; }
		}

        //TODO: UML ANNAPSSEN ChangeGenre()
        public void ChangeGenre(BooksEnums.Genre newGenre)
		{
			Genre = newGenre;
		}

        public string Publisher
        {
            get { return _publisher; }
            private set 
			{
				if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Uitgever van boek mag niet leeg zijn !");
                _publisher = value; 
			}
        }

        //TODO: UML ANNAPSSEN ChangePublisher()

		public void ChangePublisher(string newPublisher)
		{
			Publisher = newPublisher;
		}

        public string Author
		{
			get { return _author; }
			private set
			{
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Auteur van boek mag niet leeg zijn !");
				_author = value; 
			}
		}
        //TODO: UML ANNAPSSEN ChangeAuthor()
        public void ChangeAuthor(string newAuthor)
		{
			Author = newAuthor;
		}

		public string Title
		{
			get { return _title; }
			private set
			{
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Titel van boek mag niet leeg zijn !");
                _title = value;
			}
		}

        //TODO: UML ANNAPSSEN ChangeTitle()
        public void ChangeTitle(string newTitle)
		{
			Title = newTitle;
		}

		public string Isbn
		{
			get { return _isbn; }
			private set
			{
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("ISBN van boek mag niet leeg zijn !");
                if (value.Length != 10 && value.Length != 13) throw new ArgumentException("ISBN moet 10 of 13 karakters lang zijn!");

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
                   $"{"LibraryBookId",-20}: {LibraryBookGuid}\n" +
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
