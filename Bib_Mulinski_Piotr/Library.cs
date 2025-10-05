using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class Library
    {
		private string _name = "";
		private List<Book> _libraryAllBooks = new();


		public Library(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Naam van Bib mag niet leeg zijn !");
			Name = name.Trim();
		}
		public List<Book> LibraryAllBooks
		{
			get { return _libraryAllBooks; }
			private set { _libraryAllBooks = value; }
		}

        public string Name
		{
			get { return _name; }
			private set { _name = value; }
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



        public void ReadBooksFromCsv(string path, Library library)
		{
			string[] booksFromCsv = File.ReadAllLines(path);

			for (int i = 0; i < booksFromCsv.Length; i++)
			{
				string[] booksLine = booksFromCsv[i].Split(',');

				Book newBook = new Book(booksLine[0], booksLine[1], library);
				
			}

		}

        public List<Book>? AllBooksByLanguage(BooksEnums.Language lang)
        {
            return LibraryAllBooks.FindAll(el => el.Language == lang);
        }


        public List<Book>? AllBooksByAuthor(string author)
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
                LibraryAllBooks.Remove(bookToRemove);
				return true;
            }

            return false;
        }


        public void AddBook(Book book)
		{ 
			if (book is null) return;

			LibraryAllBooks.Add(book);
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
