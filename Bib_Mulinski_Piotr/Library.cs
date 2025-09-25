using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class Library
    {
		private string _name;
		private List<Book> _libraryAllBooks = new();

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

		public Library(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Naam van Bib mag niet leeg zijn !");
			Name = name;
		}

		public Book? FindBookByNameAndAuthor(string title, string author)
		{
			Book? book = LibraryAllBooks.Find(el => el.Title == title && el.Author == author);
			return book;
		}
        public string RemoveBookFromLibrary(string guid)
        {	
	
            if (!Guid.TryParse(guid.Trim(), out Guid correctId))
                return "GUID is niet correct.";

            Book? bookToRemove = LibraryAllBooks.Find(el => el.LibraryBookId == correctId);

            if (bookToRemove != null)
            {
                LibraryAllBooks.Remove(bookToRemove);
                return $"Boek met GUID {bookToRemove.LibraryBookId} is succesvol verwijderd.";
            }

            return "Geen boek gevonden met dit GUID.";
        }

        public void AddBook(Book book) 
		{
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
