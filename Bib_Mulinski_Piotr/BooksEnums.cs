using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class BooksEnums
    {
       public enum Genre
       {
            Unknown,
            Fiction, 
            NonFiction,
            SciFi,
            Fantasy,
            Biography,
            History,
            Education,
            Children,
            Crime
       }
       public enum Cover
       {
            Hardcover,
            Paperback
       }


        public enum Language
        {
            Unknown,
            Polish,
            Dutch,
            English,
            German,
            French,
            Spanish,
            Italian,
            Portuguese,
            Russian,
            Chinese,
            Japanese,
            Arabic,
            Turkish,
            Greek,
            Czech,
            Slovak,
            Hungarian,
            Swedish,
            Norwegian,
            Danish,
            Finnish
        }

        /// <summary>
        /// Enum.GetValues<Language>()) geeft een array terug van alle enums is een generice type kan ook met
        /// 
        /// Enum.GetValues(typeof(Language)))
        /// maar moet casting geburen enum.GetValues verwacht een type van values dus typeof(Language)
        /// 
        /// </summary>
        public static void MenuForLang()
        {

            foreach (Language lang in Enum.GetValues<Language>())
            {
                Console.WriteLine($"{(int)lang} - {lang}");
            }

        }


        public enum Country
        {
            Unknown,
            Poland,
            Belgium,
            Netherlands,
            Germany,
            France,
            Spain,
            Italy,
            Portugal,
            UnitedKingdom,
            UnitedStates,
            Canada,
            Russia,
            China,
            Japan,
            Brazil,
            Argentina,
            Mexico,
            Sweden,
            Norway,
            Denmark,
            Finland,
            Egypt,
            Turkey,
            Greece,
            CzechRepublic,
            Slovakia,      
            Hungary
        }

    }
}
