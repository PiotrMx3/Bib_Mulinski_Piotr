using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class Magazine : ReadingRoomItem
    {
        //TODO: Mocking 5 Magazines
        private byte _month;
        private uint _year;

        public Magazine(string title, string publisher, byte month, uint year) : base(title, publisher)
        {
            Month = month;
            Year = year;
        }


        public uint Year
        {
            get { return this._year; }
            private set
            {
                if(value > 2500) throw new ArgumentException("Het jaartal is maximaal 2500.");
                this._year = value;
            }
        }


        public byte Month
        {
            get { return this._month; }
            private set
            {
                if (value < 1 || value > 12) throw new ArgumentException("De maand moet tussen 1 en 12 zijn.");
                this._month = value;
            }
        }
        public override string Identification
        {
            get
            {
                string[] separatedTitle = Title.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string idTitle = "";

                for (int i = 0; i < separatedTitle.Length; i++)
                {
                    idTitle += char.ToUpper(separatedTitle[i][0]);
                }

                DateTime date = new DateTime((int)Year, (int)Month, DateTime.Today.Day);

                idTitle += $" {date.Month}/{date.Year}";

                return idTitle;
            }
        }

        public override string Categorie
        {
            get { return "Maandblad" ; }
        }
    }
}
