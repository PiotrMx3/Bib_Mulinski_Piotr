using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class NewsPaper : ReadinRoomItem
    {
        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            private set { _date = value; }
        }


        public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            _date = date;
        }

        public override string Identification
        {
            get
            {
                string[] separatedTitle = Title.Split(" ");
                string idTitle = "";

                for (int i = 0; i < separatedTitle.Length; i++)
                {
                    idTitle += char.ToUpper(separatedTitle[i][0]);
                }

                CultureInfo belgiumCI = new CultureInfo("nl-BE");
                idTitle += $"\n{Date.ToString("dd/MM/yyyy",belgiumCI)}";

                return idTitle;
            }
        }

        public override string Categorie
        {
            get { return "Krant"; }
        }
    }
}
