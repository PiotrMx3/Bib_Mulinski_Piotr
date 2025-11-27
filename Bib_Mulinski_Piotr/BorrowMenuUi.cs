using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bib_Mulinski_Piotr
{
    internal class BorrowMenuUi
    {
        private Library _library = null!;

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
                    "Om een boek te lenen / terugbrengen moet je steeds de GUID ingeven");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Toon beschikbare boeken & Leen uit ");
                Console.WriteLine("2. Breng een boek terug");
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
                        break;
                    case "3":
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

            bookGroup.ToImmutable();

            Console.WriteLine();
            Logger.LogInfo("Beschikbaare Boeken");
            Console.WriteLine();
            Console.WriteLine();
            int counter = 1;

            // TODO: Maak een lijst aan van de groepen om selectie via index mogelijk te maken.

            foreach (BooksGroup group in bookGroup.Values)
            {
                Console.WriteLine($"{counter}. {group.Title}");
                Console.WriteLine($"   ISBN: {group.Isbn} | Beschikbaar: {group.AvailableCount} / {group.TotalCount}");
                counter++;
            }


        }


    }
}
