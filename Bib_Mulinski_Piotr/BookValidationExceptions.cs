using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    // Hier zien we de kracht van overerving en polymorfisme
    // We hebben een basisclass BookValidationException : ApplicationException
    //
    // Op basis daarvan maken we drie custom exceptions die van BookValidationException overerven
    // We throwen deze custom exceptions waar nodig en we vangen ze op in try/catch
    // via de parentclass BookValidationException omdat alle childclasses daarvan erven

    internal class BookValidationExceptions : ApplicationException
    {
        public BookValidationExceptions(string message) : base(message)
        {
        }
    }

    internal class BookRequiredFieldException : BookValidationExceptions
    {
        public BookRequiredFieldException(string message) : base(message)
        {
        }
    }

    internal class InvalidIsbnException : BookValidationExceptions
    {
        public InvalidIsbnException(string message) : base(message)
        {
        }
    }

    internal class BookValueOutOfRangeException : BookValidationExceptions
    {
        public BookValueOutOfRangeException(string message) : base(message)
        {
        }
    }




}
