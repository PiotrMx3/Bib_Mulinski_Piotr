using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class BorrowMenuUi
    {
        private Library _library;

        public BorrowMenuUi(Library library)
        {
            this._library = library;
        }



        public void ShowBorrowMenuUi()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Logger.LogInfo("==== Ontleen Menu ====\n\n" +
                    "Om een boek terugbrengen moet je steeds de GUID ingeven");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Toon beschikbare boeken & Leen uit");
                Console.WriteLine("2. Breng een boek terug");
                Console.WriteLine("3. Overzicht van de personen die boeken lenen");
                Console.WriteLine("0. Afsluiten");
                Console.WriteLine();
                Console.Write("Maak een keuze: ");


                string userChoice = (Console.ReadLine() ?? "").Trim();
                Console.WriteLine();

                switch (userChoice)
                {
                    case "1":
                        ShowBorrowBooksUi();
                        break;
                    case "2":
                        ReturnBookUi();
                        break;
                    case "3":
                        ShowUsersWithBorrowedBooksUi();
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

        private void ReturnBookUi()
        {
            Logger.LogInfo("==== Boek Terugbrengen ====");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Geef de naam van de lener: ");
            string userName = (Console.ReadLine() ?? "").Trim();
            Console.WriteLine();

            if (!_library.BorrowBooksByUser.ContainsKey(userName))
            {
                Logger.LogError($"Geen lener gevonden met de naam '{userName}'");
                Console.WriteLine();
                return;
            }

            ICollection<Guid> userBooks = _library.BorrowBooksByUser[userName];


            if (userBooks.Count == 0)
            {
                Logger.LogInfo("Deze gebruiker heeft geen openstaande leningen");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Boeken geleend door {userName}: ");
            Console.WriteLine();


            foreach (Guid bookId in userBooks)
            {

                Book? foundBook;

                foundBook = _library.FindBookByGuid(bookId.ToString());

                if (foundBook is not null)
                {
                    Console.WriteLine($"{"",-5}Titel: {foundBook.Title,-20} | GUID: {bookId}");
                }
                else
                {
                    Console.WriteLine($"{"",-5}Titel: GEEN BOEK GEVONDEN | GUID: {bookId}");
                }

            }
            Console.WriteLine();

            Logger.LogInfo("Geef een Guid in om een boek terug te brengnen: ");

            string guidFromUser = (Console.ReadLine() ?? "").Trim();


            if (Guid.TryParse(guidFromUser, out Guid parsedGuid) && userBooks.Contains(parsedGuid))
            {
                Book? bookToReturn = _library.FindBookByGuid(parsedGuid.ToString());
                Console.WriteLine();

                if (bookToReturn is not null)
                {
                    Logger.LogSuccess($"Boek: {bookToReturn.Title} is succesvol teruggebracht");
                    bookToReturn.Return();

                    // Boeken uit de lijst van de gebruiker verwijderen en als de lijst leeg is,
                    // ook de gebruiker uit de dictionary verwijderen.

                    userBooks.Remove(parsedGuid);

                    if (userBooks.Count == 0)
                    {
                        _library.RemoveUserWithEmptyBorrowList(userName);
                    }

                }
                else
                {
                    Logger.LogError("Boek niet gevonden");
                }
            }
            else
            {
                Console.WriteLine();
                Logger.LogError("Ongeldige GUID !");
                Console.WriteLine();
            }

        }
        private void ShowUsersWithBorrowedBooksUi()
        {
            if (_library.BorrowBooksByUser.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Er zijn geen boeken die geleend zijn");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                return;
            }

            Logger.LogInfo("--- Overzicht van Leners ---");
            Console.WriteLine();

            int count = 1;
            foreach (var user in _library.BorrowBooksByUser)
            {
                Book? foundBook;

                Console.WriteLine();
                Console.Write($"{count}. {user.Key}\n");

                foreach (Guid bookId in user.Value)
                {
                    foundBook = _library.FindBookByGuid(bookId.ToString());

                    if (foundBook is not null)
                    {
                        Console.WriteLine($"{"",-5}Titel: {foundBook.Title,-25} | GUID: {bookId}");
                    }
                    else
                    {
                        Console.WriteLine($"{"",-5}Titel: GEEN BOEK GEVONDEN | GUID: {bookId}");
                    }

                }
                count++;
                Console.WriteLine();
            }

            Console.WriteLine();

        }

        private void ShowBorrowBooksUi()
        {
            var bookGroup = ImmutableDictionary.CreateBuilder<string, BooksGroup>();


            foreach (Book book in _library.LibraryAllBooks)
            {

                if (bookGroup.ContainsKey(book.Isbn))
                {

                    BooksGroup existingBooksGroup = bookGroup[book.Isbn];

                    existingBooksGroup.TotalCount++;


                    if (book.IsAvailable)
                    {
                        existingBooksGroup.AddAvailableBook(book);
                    }

                }
                else
                {

                    BooksGroup newGroup = new();

                    newGroup.Title = book.Title;
                    newGroup.Isbn = book.Isbn;
                    newGroup.TotalCount = 1;

                    if (book.IsAvailable)
                    {
                        newGroup.AddAvailableBook(book);
                    }

                    bookGroup.Add(book.Isbn, newGroup);
                }

            }


            // Hier wordt gefilterd op boekgroepen die effectief een lijst met boeken bevatten
            List<BooksGroup> groupList = new();

            foreach (var group in bookGroup)
            {
                if (group.Value.AvailableBooks.Count > 0)
                {
                    groupList.Add(group.Value);
                }
            }

            if (groupList.Count == 0)
            {
                Logger.LogInfo("Helaas, alle boeken zijn momenteel uitgeleend !");
                Console.WriteLine();
                Console.WriteLine();
                return;
            }


            groupList.Sort((a, b) => a.Title.CompareTo(b.Title));

            Console.WriteLine();
            Logger.LogInfo("Beschikbare Boeken");
            Console.WriteLine();
            Console.WriteLine();


            int counter = 1;
            foreach (var group in groupList)
            {
                string author = group.AvailableBooks[0].Author;

                Console.WriteLine($"{counter}. {author} -- {group.Title}");

                Console.WriteLine($"   ISBN: {group.Isbn} | Beschikbaar: {group.AvailableCount} / {group.TotalCount}");
                Console.WriteLine();
                counter++;
            }

            Logger.LogInfo("Geef het nummer in om een boek te lenen: ");

            string userChoice = (Console.ReadLine() ?? "").Trim();
            Console.WriteLine();


            if (int.TryParse(userChoice, out int parsedResult)
                && parsedResult > 0
                && parsedResult <= groupList.Count)
            {
                int index = parsedResult - 1;

                Book bookToBorrow = groupList[index].AvailableBooks[0];

                bookToBorrow.Borrow();

                // Hier wordt naam gevraagd, om een  dictinary aan te maken met naam en guid van gelende boeken

                Logger.LogInfo("Op wie zijn naam mag dit boek gezet worden?: ");

                string userName = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(userName)) userName = "Onbekend";

                _library.AddBookGuidBorrow(userName, bookToBorrow.LibraryBookGuid);

                Console.WriteLine();
                Logger.LogSuccess($"Boek succesvol uitgeleend aan: {userName}");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($" GUID: {bookToBorrow.LibraryBookGuid}");
                Console.WriteLine(" (Bewaar deze GUID om het boek terug te brengen)");
                Console.WriteLine("--------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine();

            }
            else
            {
                Logger.LogError("Ongeldige keuze probeer het opnieuw!");
                Console.WriteLine();
            }


        }


    }
}
