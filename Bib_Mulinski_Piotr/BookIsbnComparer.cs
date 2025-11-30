using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class BookIsbnComparer : IEqualityComparer<Book>
    {
        //TODO: UML
        public bool Equals(Book? x, Book? y)
        {
            if (x is null || y is null) return false;

            return x.Isbn == y.Isbn;
        }

        public int GetHashCode(Book obj)
        {
            if (obj is null) return 0;
            return obj.Isbn.GetHashCode();
        }
    }
}
