using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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


		public Library(string name)
		{
			Name = name.Trim();
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
                    throw new ArgumentException($"Regel {i+1}: onjuist CSV-formaat (verwacht minimaal 2 velden: Titel, Auteur). Corrigeer en probeer het opnieuw.");
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
	}
}
