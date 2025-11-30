using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bib_Mulinski_Piotr.BooksEnums;

namespace Bib_Mulinski_Piotr
{
    internal class EnumUtils
    {

        public static string ToDutchLang(Language lang)
        {
            switch (lang)
            {
                case Language.Polish: return "Pools";
                case Language.Dutch: return "Nederlands";
                case Language.English: return "Engels";
                case Language.German: return "Duits";
                case Language.French: return "Frans";
                case Language.Spanish: return "Spaans";
                case Language.Italian: return "Italiaans";
                case Language.Portuguese: return "Portugees";
                case Language.Russian: return "Russisch";
                case Language.Chinese: return "Chinees";
                case Language.Japanese: return "Japans";
                case Language.Arabic: return "Arabisch";
                case Language.Turkish: return "Turks";
                case Language.Greek: return "Grieks";
                case Language.Czech: return "Tsjechisch";
                case Language.Slovak: return "Slowaaks";
                case Language.Hungarian: return "Hongaars";
                case Language.Swedish: return "Zweeds";
                case Language.Norwegian: return "Noors";
                case Language.Danish: return "Deens";
                case Language.Finnish: return "Fins";
                default: return "Onbekend";
            }
        }

        public static string ToDutchGenre(Genre genre)
        {
            switch (genre)
            {
                case Genre.Fiction: return "Fictie";
                case Genre.NonFiction: return "Non-fictie";
                case Genre.SciFi: return "Sciencefiction";
                case Genre.Fantasy: return "Fantasy";
                case Genre.Biography: return "Biografie";
                case Genre.History: return "Geschiedenis";
                case Genre.Education: return "Educatie";
                case Genre.Children: return "Kinderboeken";
                case Genre.Crime: return "Misdaad";
                default: return "Onbekend";
            }
        }

        public static string ToDutchCover(Cover cover)
        {
            switch (cover)
            {
                case Cover.Hardcover: return "Hardcover";
                case Cover.Paperback: return "Softcover";
                default: return "Onbekend";
            }
        }

        public static string ToDutchCountry(Country country)
        {
            switch (country)
            {
                case Country.Poland: return "Polen";
                case Country.Belgium: return "België";
                case Country.Netherlands: return "Nederland";
                case Country.Germany: return "Duitsland";
                case Country.France: return "Frankrijk";
                case Country.Spain: return "Spanje";
                case Country.Italy: return "Italië";
                case Country.Portugal: return "Portugal";
                case Country.UnitedKingdom: return "Verenigd Koninkrijk";
                case Country.UnitedStates: return "Verenigde Staten";
                case Country.Canada: return "Canada";
                case Country.Russia: return "Rusland";
                case Country.China: return "China";
                case Country.Japan: return "Japan";
                case Country.Brazil: return "Brazilië";
                case Country.Argentina: return "Argentinië";
                case Country.Mexico: return "Mexico";
                case Country.Sweden: return "Zweden";
                case Country.Norway: return "Noorwegen";
                case Country.Denmark: return "Denemarken";
                case Country.Finland: return "Finland";
                case Country.Egypt: return "Egypte";
                case Country.Turkey: return "Turkije";
                case Country.Greece: return "Griekenland";
                case Country.CzechRepublic: return "Tsjechië";
                case Country.Slovakia: return "Slowakije";
                case Country.Hungary: return "Hongarije";
                default: return "Onbekend";
            }
        }



        /// <summary>
        /// 
        /// Enum.GetValues<Language>()) geeft een array terug van alle enums is een generice type kan ook met
        /// 
        /// Enum.GetValues(typeof(Language)))
        /// maar moet casting geburen enum.GetValues verwacht een type van values dus typeof(Language)
        /// 
        /// </summary>


        public static void EnumMenuForLang()
        {

            foreach (BooksEnums.Language lang in Enum.GetValues<BooksEnums.Language>())
            {
                Console.WriteLine($"{(int)lang} - {ToDutchLang(lang)}");
            }

        }

        public static void EnumMenuForGenre()
        {

            foreach (BooksEnums.Genre genre in Enum.GetValues<BooksEnums.Genre>())
            {
                Console.WriteLine($"{(int)genre} - {ToDutchGenre(genre)}");
            }

        }

    }
}
