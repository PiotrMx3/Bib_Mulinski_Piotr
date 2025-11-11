using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class ReadingRoomMenuUi
    {
        private Library _library = null!;

        public ReadingRoomMenuUi(Library library)
        {
            this._library = library;
        }

        public void ShowReadingRoomMenuUi()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Logger.LogInfo("==== Wachtzaal Menu ====");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Boek toevoegen op basis van titel en auteur");
                Console.WriteLine("0. Afsluiten");
                Console.WriteLine();
                Console.Write("Maak een keuze: ");


                string userChoice = (Console.ReadLine() ?? "").Trim();
                Console.WriteLine();

                switch (userChoice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Logger.LogError("Ongeldige keuze");
                        Console.WriteLine();
                        break;
                }

            }

            Console.WriteLine();

        }
    }

}
