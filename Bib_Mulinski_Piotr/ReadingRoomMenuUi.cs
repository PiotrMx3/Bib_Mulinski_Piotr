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
                Logger.LogInfo("==== Leeszaal Menu ====");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Een krant toevoegen");
                Console.WriteLine("2. Een maandblad toevoegen");
                Console.WriteLine("3. Alle kranten tonen");
                Console.WriteLine("4. Alle maandbladen tonen");
                Console.WriteLine("5. Aanwisten van de leeszaal (Vandaag)");
                Console.WriteLine("0. Afsluiten");
                Console.WriteLine();
                Console.Write("Maak een keuze: ");


                string userChoice = (Console.ReadLine() ?? "").Trim();
                Console.WriteLine();

                switch (userChoice)
                {
                    case "1":
                        _library.AddNewsPaper();
                        break;
                    case "2":
                        _library.AddMagazine();
                        break;
                    case "3":
                        _library.ShowAllNewspapers();
                        break;
                    case "4":
                        _library.ShowAllMagazines();
                        break;
                    case "5":
                        _library.AcquisitionReadingRoomToday();
                        break;
                    case "clear":
                        Console.Clear();
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
