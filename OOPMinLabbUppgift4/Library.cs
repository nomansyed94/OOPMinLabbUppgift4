using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOPMinLabbUppgift4
{
    public class Library
    {
        private List<Library> Books { get; set; }


        public Library()
        {
            Books = new List<Library>();
        }

        public void RunLibraryProgram()
        {
            while (true)
            {
                int sel = ShowMenu();
                if (sel == 1)
                {
                    AddBookToLibrary();
                }
                else if (sel == 2)
                {
                    Console.WriteLine("not implemented yet.");
                    //BorrowBook();
                }
                else if (sel == 3)
                {
                    Console.WriteLine("not implemented yet.");
                    //ReturnBook();
                }
                else
                {
                    break;
                }
            }
        }

        public int ShowMenu()
        {
            Console.WriteLine("MENY");
            Console.WriteLine("1. Skapa en ny bok");
            Console.WriteLine("2. Låna en bok");
            Console.WriteLine("3. Lämna en bok");
            Console.WriteLine("4. Avsluta program");
            return SelectMenu(1, 4);
        }

        public int SelectMenu(int min, int max)
        {
            while (true)
            {
                Console.Write("Välj:");
                int select;
                if (!int.TryParse(Console.ReadLine(), out select) || select < min || select > max)
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
                else
                {
                    return select;
                }
            }
        }

        public void AddBookToLibrary()
        {

            Console.WriteLine("Skriv in namnet på boken du vill skapa");
            var newBook = Console.ReadLine();
            Console.WriteLine("Skriv in hur många du vill lägga till.");
            var numberOfBooks = Convert.ToInt32(Console.ReadLine());

            var newLineToBooksInLibrary = newBook + ":antal i lager," + numberOfBooks;

            string[] allLibBooks = File.ReadAllLines("c:\\Users\\Noman\\source\\repos\\C# kurs Nackademin\\OOPMinLabbUppgift4\\OOPMinLabbUppgift4\\ListOfBooksInLibrary.txt");


            using (StreamWriter addToBookList = File.AppendText("c:\\Users\\Noman\\source\\repos\\C# kurs Nackademin\\OOPMinLabbUppgift4\\OOPMinLabbUppgift4\\ListOfBooksInLibrary.txt"))
            {
                foreach (var books in allLibBooks)
                {
                    var bookTitle = books.Split(':')[0];
                    var bookNumber = books.Split(',')[1];
                    if (newBook == bookTitle)
                    {
                        numberOfBooks += Convert.ToInt32(bookNumber);
                    }
                }
                addToBookList.WriteLine(newLineToBooksInLibrary);
            }
        }

        public void BorrowBook()
        {
            string[] allLibBooks = File.ReadAllLines("c:\\Users\\Noman\\source\\repos\\C# kurs Nackademin\\OOPMinLabbUppgift4\\OOPMinLabbUppgift4\\ListOfBooksInLibrary.txt");

            Console.WriteLine("Skriv in boken du vill låna.");
            var borrowedBook = Console.ReadLine();
            //if (Books.Contains(borrowedBook))
            //{
                
            //}
        }

        public void ReturnBook()
        {
            Console.WriteLine("Skriv in boken du vill lämna.");
            var returnedBook = Console.ReadLine();
        }

    }
}
