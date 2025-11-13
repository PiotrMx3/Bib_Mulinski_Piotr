using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class NewsPaper : ReadingRoomItem
    {  
        private DateTime _date = DateTime.MinValue;
         
        public DateTime Date
        {
            get { return this._date; }
            private set{ this._date = value; }
        }


        public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            Date = date;
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

                CultureInfo belgiumCI = new CultureInfo("nl-BE");
                idTitle += $" {Date.ToString("dd/MM/yyyy",belgiumCI)}";

                return idTitle;
            }
        }

        public override string Categorie
        {
            get { return "Krant"; }
        }

        public override string ToString()
        {
            return $"{this.Title} van {this.Date.ToString("dddd d MMMM yyyy", new CultureInfo("nl-Be"))} van uitgeverij {this.Publisher}";
        }
    }
}
