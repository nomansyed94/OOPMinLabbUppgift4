using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOPMinLabbUppgift4
{
    public class Library
    {
        private List<Book> Books { get; set; }


        public Library()
        {
            Books = new List<Book>();
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
                    //Console.WriteLine("not implemented yet.");
                    BorrowBook();
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

        public Book FindBook(string name)
        {
            foreach (var book in Books)
                if (book.Title == name)
                {
                    return book;
                }
            return null;
        }

        //public Book GetCountInLibrary(int antalExInne)
        //{
            
        //}

        //public Book GetBorrowedCount(int antalExUte)
        //{

        //}

        public void AddBookToLibrary()
        {

            Console.WriteLine("Skriv in namnet på boken du vill skapa");
            var newBook = Console.ReadLine();
            Console.WriteLine("Skriv in hur många du vill lägga till.");
            var numberOfBooks = Convert.ToInt32(Console.ReadLine());

            Book find = FindBook(newBook);
            if (find == null)
            {
                find = new Book();
                find.Title = newBook;
                find.Antal = numberOfBooks;
                Books.Add(find);
            }
            else
            {
                var booksInLib = find.Antal += numberOfBooks;
                Console.WriteLine($"Det finns nu {booksInLib}st {find.Title} i biblioteket");
            }

        }

        public void BorrowBook()
        {
            Console.WriteLine("Skriv in boken du vill låna.");
            var borrowedBook = Console.ReadLine();
            Book borrowBook = FindBook(borrowedBook);
            if (borrowBook != null)
            {
                Console.WriteLine($"du har lånat {borrowBook.Title}");

            }
            else
            {
                Console.WriteLine("Boken finns inte");
            }
        }

        public void ReturnBook()
        {
            Console.WriteLine("Skriv in boken du vill lämna.");
            var returnedBook = Console.ReadLine();
        }

    }
}
