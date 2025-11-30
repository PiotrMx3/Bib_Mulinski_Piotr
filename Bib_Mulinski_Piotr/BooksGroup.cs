using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class BooksGroup
    {
        private string _title = "";
        private string _isbn = "";
        private int _totalCount;

        // IEnumerable is read-only. Je kunt er alleen doorheen loopen (foreach).
        // ICollection erft van IEnumerable en voegt functionaliteit toe om data te WIJZIGEN (Add, Remove, Count).
        private ICollection<Book> _availableBooks = new List<Book>();


        public void AddAvailableBook(Book book)
        {
            _availableBooks.Add(book);
        }

        public ImmutableList<Book> AvailableBooks
        {
            get { return _availableBooks.ToImmutableList(); }
            
        }

        
        public int AvailableCount
        {
            get { return _availableBooks.Count; }
        }


        public int TotalCount
        {
            get { return this._totalCount; }
            set { this._totalCount = value; }
        }


        public string Isbn
        {
            get { return this._isbn; }
            set { this._isbn = value; }
        }


        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

    }
}
