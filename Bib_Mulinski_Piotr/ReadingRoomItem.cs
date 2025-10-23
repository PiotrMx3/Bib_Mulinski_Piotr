using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    abstract class ReadingRoomItem
    {
		private string _title = "";
		private string _publisher = "";
		abstract public string Identification { get; }
		abstract public string Categorie { get; }

        public ReadingRoomItem(string title, string publisher)
		{
			Title = title;
			Publisher = publisher;

		}

		public string Publisher
		{
			get { return this._publisher; }
			private set 
			{
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Uitgever mag niet leeg zijn !");

                this._publisher = value;
			}
		}

		public string Title
		{
			get { return _title; }
			private set
			{
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Titel mag niet leeg zijn !");

                this._title = value;
			}
		}



	}
}
