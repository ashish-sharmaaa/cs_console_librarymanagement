using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Channels;
using System.Linq;

namespace capstoneproject2
{
    //Creating a class book
    class Book
    {
        public int bookId;
        public string bookName;
        public int bookPrice;
        public int bookCount;
        public int x;
    }
    //Creating  a class Borrow
    class BorrowDetails
    {
        public int userId;
        public string userName;
        public string userAddress;
        public int borrowBookId;
        public DateTime borrowDate;
        public int borrowCount;
    }

    class Program
    {
        static List<Book> bookList = new List<Book>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        static Book book = new Book();
        static BorrowDetails borrow = new BorrowDetails();
        static void Main(string[] args)
        {
            Console.WriteLine("---------************WELCOME TO LIBRARY MANAGEMENT SYSTEM************---------");
            Console.WriteLine("---------*********NORTH INDIA'S BIGGEST LIBRARY*********---------");

            Console.Write("Welcome !!!\nEnter your password :");
            string password = Console.ReadLine();
            Console.Write("enter your name :");
            string NAME = Console.ReadLine();

            if (password == "ash@123" && NAME == "ashish")
            {
                bool close = true;

                while (close)
                {
                    Console.WriteLine("\nMenu\n" +
                    "1)librarian\n" +
                    "2)borrower\n" +
                    "3)exit\n");
                    Console.Write("Choose your option from menu :");

                    int option = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("------- LIBRARIAN-------- \n");

                            Console.WriteLine("\nMenu\n" +
                            "1)Add book\n" +
                            "2)Delete book\n" +
                            "3)Search book\n" +
                            "4)View books\n" +
                            "5)Close\n\n");
                            Console.WriteLine("choose the option");
                            int option2 = int.Parse(Console.ReadLine());
                            switch (option2)
                            {
                                case 1:
                                    Console.WriteLine("ADD A BOOK :-\n");
                                    GetBook();
                                    Console.Clear();
                                    break;

                                case 2:
                                    Console.Write("DELETE A BOOK :-\n");
                                    RemoveBook();
                                    break;
                                case 3:
                                    Console.WriteLine("SEARCH A BOOK:-\n");
                                    SearchBook();
                                    break;
                                case 4:
                                    Console.WriteLine("VIEW BOOKS:-\n");
                                    viewbook();
                                    break;
                                case 5:
                                    Console.WriteLine("-------------THANK YOU---------");
                                    close = false;
                                    break;
                            }
                            break;

                        case 2:
                            Console.WriteLine("--------BORROWER------- \n");
                            Console.WriteLine("\nMenu\n" +
                            "1)View Book\n" +
                            "2)Borrow book\n" +
                            "3)Return book\n" +
                            "4)Search book\n" +
                            "5)Close\n"
                            );
                            Console.WriteLine("choose the option");
                            int option3 = int.Parse(Console.ReadLine());
                            switch (option3)
                            {
                                case 1:
                                    Console.WriteLine("VIEW BOOK :-\n");
                                    viewbook();

                                    break;
                                case 2:
                                    Console.WriteLine("BORROW BOOK :-\n");
                                    Borrow();
                                    Console.Clear();
                                    break;
                                case 3:
                                    Console.WriteLine("RETURN BOOK :-\n");
                                    ReturnBook();
                                    Console.Clear();
                                    break;
                                case 4:
                                    Console.WriteLine("SEARCH A BOOK :-\n");
                                    SearchBook();
                                    Console.Clear();
                                    break;

                                case 5:
                                    Console.WriteLine("---------THANK YOU--------");
                                    close = false;
                                    break;

                            }
                            break;
                        case 3:
                            Console.WriteLine("---------THANK YOU----------");
                            close = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid password or name");
            }
            Console.ReadLine();
        }

        //To add book details to the Library database
        public static void GetBook()
        {
            Book book = new Book();
            Console.WriteLine("Book Id:{0}", book.bookId = bookList.Count + 1);
            Console.Write("Book Name:");
            book.bookName = Console.ReadLine();
            Console.Write("Book Price:");
            book.bookPrice = int.Parse(Console.ReadLine());
            Console.Write("Number of Books:");
            book.x = book.bookCount = int.Parse(Console.ReadLine());
            bookList.Add(book);
        }
        public static void viewbook()
        {

            var query = from b in bookList
                        orderby b.bookPrice
                        select b;
            Console.WriteLine("{0,5} {1,-20} {2,5} {3,15}", "bookId", " bookName", " bookPrice", "  bookCount");
            foreach (Book b in query)
            {

                Console.WriteLine("{0,5} {1,-20} {2,5} {3,15}", b.bookId, b.bookName, b.bookPrice, b.bookCount);
            }


        }


        //To delete book details from the Library database
        public static void RemoveBook()
        {
            Book book = new Book();
            Console.Write("Enter Book id to be deleted : ");

            int Del = int.Parse(Console.ReadLine());

            if (bookList.Exists(x => x.bookId == Del))
            {
                bookList.RemoveAt(Del - 1);
                Console.WriteLine("Book id - {0} has been deleted", Del);
            }
            else
            {
                Console.WriteLine("Invalid Book id");
            }

            bookList.Add(book);
        }

        //To search book details from the Library database using Book id
        public static void SearchBook()
        {
            Book book = new Book();
            Console.Write("Search by BOOK id :");
            int find = int.Parse(Console.ReadLine());

            if (bookList.Exists(x => x.bookId == find))
            {
                foreach (Book searchId in bookList)
                {
                    if (searchId.bookId == find)
                    {
                        Console.WriteLine("Book id :{0}\n" +
                        "Book name :{1}\n" +
                        "Book price :{2}\n" +
                        "Book Count :{3}", searchId.bookId, searchId.bookName, searchId.bookPrice, searchId.bookCount);
                    }
                    break;
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", find);
            }
        }

        //To borrow book details from the Library
        public static void Borrow()
        {
            Book book = new Book();
            BorrowDetails borrow = new BorrowDetails();
            Console.WriteLine("User id : {0}", (borrow.userId = borrowList.Count + 1));
            Console.Write("Name :");

            borrow.userName = Console.ReadLine();

            Console.Write("Book id :");
            borrow.borrowBookId = int.Parse(Console.ReadLine());
            Console.Write("Number of Books : ");
            borrow.borrowCount = int.Parse(Console.ReadLine());
            Console.Write("Address :");
            borrow.userAddress = Console.ReadLine();
            borrow.borrowDate = DateTime.Now;
            Console.WriteLine("Date - {0} and Time - {1}", borrow.borrowDate.ToShortDateString(), borrow.borrowDate.ToShortTimeString());

            if (bookList.Exists(x => x.bookId == borrow.borrowBookId))
            {
                foreach (Book searchId in bookList)
                {
                    if (searchId.bookCount >= searchId.bookCount - borrow.borrowCount && searchId.bookCount - borrow.borrowCount >= 0)
                    {
                        if (searchId.bookId == borrow.borrowBookId)
                        {
                            searchId.bookCount -= borrow.borrowCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Only {0} books are found", searchId.bookCount);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", borrow.borrowBookId);
            }
            borrowList.Add(borrow);
        }

        //To return borrowed book to the library
        public static void ReturnBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter following details :");

            Console.Write("Book id : ");
            int returnId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books:");
            int returnCount = int.Parse(Console.ReadLine());

            if (bookList.Exists(y => y.bookId == returnId))
            {
                foreach (Book addReturnBookCount in bookList)
                {
                    if (addReturnBookCount.x >= returnCount + addReturnBookCount.bookCount)
                    {
                        if (addReturnBookCount.bookId == returnId)
                        {
                            addReturnBookCount.bookCount += returnCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Count exists the actual count");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", returnId);
            }
        }
    }
}
