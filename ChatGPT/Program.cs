using AutoMapper.Features;
using ChatGPT;
using System;
using System.ComponentModel;

public class Program : Indentation
{
    public static List<Book> bookList = new List<Book>();
    public static List<Library> libraryList = new List<Library>();

    static void Main(string[] args)
    {
        Console.WriteLine(@"

░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░
░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██╗
░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██║
░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║
░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝
░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░

███████╗███████╗██████╗░░█████╗░██╗░██████╗  ██╗░░░░░██╗██████╗░██████╗░░█████╗░██████╗░██╗░░░██╗
╚════██║██╔════╝██╔══██╗██╔══██╗╚█║██╔════╝  ██║░░░░░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗░██╔╝
░░███╔═╝█████╗░░██████╔╝██║░░██║░╚╝╚█████╗░  ██║░░░░░██║██████╦╝██████╔╝███████║██████╔╝░╚████╔╝░
██╔══╝░░██╔══╝░░██╔══██╗██║░░██║░░░░╚═══██╗  ██║░░░░░██║██╔══██╗██╔══██╗██╔══██║██╔══██╗░░╚██╔╝░░
███████╗███████╗██║░░██║╚█████╔╝░░░██████╔╝  ███████╗██║██████╦╝██║░░██║██║░░██║██║░░██║░░░██║░░░
╚══════╝╚══════╝╚═╝░░╚═╝░╚════╝░░░░╚═════╝░  ╚══════╝╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░");

        BookLists();
        LibraryList();


        Console.WriteLine("Press any key to enter Menu...");
        Console.ReadKey();
        Console.Clear();
        bool userValid = true;

        do
        {
            Console.WriteLine(@"

    ███╗░░░███╗░█████╗░██╗███╗░░██╗  ███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗
    ████╗░████║██╔══██╗██║████╗░██║  ████╗░████║██╔════╝████╗░██║██║░░░██║
    ██╔████╔██║███████║██║██╔██╗██║  ██╔████╔██║█████╗░░██╔██╗██║██║░░░██║
    ██║╚██╔╝██║██╔══██║██║██║╚████║  ██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║
    ██║░╚═╝░██║██║░░██║██║██║░╚███║  ██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝
    ╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝╚═╝░░╚══╝  ╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░");
            Console.WriteLine("\nLogin Options:");
            Console.WriteLine("1) Administrator");
            Console.WriteLine("2) Member");
            Console.Write("--> ");
            string loginType = Console.ReadLine();
            //Dictionary<int, string> membersList = MemberLists();


            //bool validUser = (loginType == "1" || loginType == "2") ? true : false;
            

            switch (ValidUser(loginType))
            {
                case "Administrator":
                    Console.Clear();
                    Console.WriteLine(@"

░█████╗░██████╗░███╗░░░███╗██╗███╗░░██╗  ███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗
██╔══██╗██╔══██╗████╗░████║██║████╗░██║  ████╗░████║██╔════╝████╗░██║██║░░░██║
███████║██║░░██║██╔████╔██║██║██╔██╗██║  ██╔████╔██║█████╗░░██╔██╗██║██║░░░██║
██╔══██║██║░░██║██║╚██╔╝██║██║██║╚████║  ██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║
██║░░██║██████╔╝██║░╚═╝░██║██║██║░╚███║  ██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝
╚═╝░░╚═╝╚═════╝░╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝  ╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░");
                    Administrator admin = new Administrator(); //Laver et admin object
                    Console.Write("Enter Admin Id --> ");
                    admin.AdminId = Console.ReadLine();

                    Console.Write("Enter Admin Pass --> ");
                    admin.AdminPass = Console.ReadLine();

                    admin.CheckAdminLogin(admin.AdminId, admin.AdminPass); //Tjeker admin userid og pass for at logge ind

                    AdminMenu(admin);

                    break;

                case "User":
                    Console.Clear();
                    Console.WriteLine(@"

███╗░░░███╗███████╗███╗░░░███╗██████╗░███████╗██████╗░  ██╗░░░░░░█████╗░░██████╗░██╗███╗░░██╗
████╗░████║██╔════╝████╗░████║██╔══██╗██╔════╝██╔══██╗  ██║░░░░░██╔══██╗██╔════╝░██║████╗░██║
██╔████╔██║█████╗░░██╔████╔██║██████╦╝█████╗░░██████╔╝  ██║░░░░░██║░░██║██║░░██╗░██║██╔██╗██║
██║╚██╔╝██║██╔══╝░░██║╚██╔╝██║██╔══██╗██╔══╝░░██╔══██╗  ██║░░░░░██║░░██║██║░░╚██╗██║██║╚████║
██║░╚═╝░██║███████╗██║░╚═╝░██║██████╦╝███████╗██║░░██║  ███████╗╚█████╔╝╚██████╔╝██║██║░╚███║
╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═════╝░╚══════╝╚═╝░░╚═╝  ╚══════╝░╚════╝░░╚═════╝░╚═╝╚═╝░░╚══╝");
                    User user = new User();
                    Console.Write("Enter User Id --> ");
                    int id;

                    bool checkUserId = int.TryParse(Console.ReadLine(), out id);

                    user.UserId = id;

                    Console.Write("Enter User Pass --> ");
                    user.Password = Console.ReadLine();

                    user.CheckUserLogin(user.UserId, user.Password);
                    break;

                default:
                    Console.WriteLine("Unknown User");
                    break;
            }

        } while (userValid);
        


    }
    

    static string ValidUser(string user)
    {
        //Trim userInput for mellemrum
        string exactUserInput = user.Trim();
        if (exactUserInput == "1")
            return "Administrator";
        else if (exactUserInput == "2")
            return "User";
        else
        {
            bool runLoop = true;
            string userType = string.Empty;
            do
            {
                Console.WriteLine("Invalid Option Selected!!!");
                Console.WriteLine("\nLogin Options:");
                Console.WriteLine("1) Administrator");
                Console.WriteLine("2) Member");
                Console.Write("--> ");
                userType = Console.ReadLine().Trim();
                if (userType == "1")
                {
                    return "Administrator";
                }

                else if (userType == "2")
                    return "User";

                else
                    continue;

            } while (runLoop);
            return "";
        }

        
    }
    
    public static Dictionary<int, Member> MemberLists()
    {
        Dictionary<int, Member> members = new Dictionary<int, Member>();

        members.Add(1108, new Member() { Name = "Subarna", MemberPassword = "DryOrc5166"});
        members.Add(1145, new Member() { Name = "Bibek", MemberPassword = "HelloWorld23" });
        members.Add(1223, new Member() { Name = "ZeroTwo", MemberPassword = "IamNerd#" });

        return members;
    }

    private static void AdminMenu(Administrator admin)
    {
        bool runLoop = true;

        do
        {
            ColorMessage(ConsoleColor.Cyan, "Admin Main Menu", true);
            Console.WriteLine("Choose Options: ");
            Console.WriteLine("1) Book");
            Console.WriteLine("2) Library");
            Console.WriteLine("3) Member");
            Console.WriteLine("4) Logout");
            Console.Write("--> ");
            int adminOption = ValidNumberInput(Console.ReadLine(), 4);

            switch (adminOption)
            {
                case 1:
                    admin.EditBookClassAsAdmin();
                    break;
                case 2:
                    admin.EditLibraryClassAsAdmin();

                    break;
                case 3:
                    Console.WriteLine(3);

                    break;
                case 4:
                    Console.Clear();
                    runLoop = false;
                    break;
                default:
                    break;
            }

        } while (runLoop);
        
    }

    /*
     public static Dictionary<string, Book> BookDictionary()
    {
        var bookDictionary = new Dictionary<string, Book>();

        foreach (Book book in bookList)
        {
            bookDictionary.Add(book.Title, book);
        }
        return bookDictionary;

    } */

    public static void LibraryList()
     {

        if(libraryList.Count == 0)
        {
            Random random = new Random();

            List<Book> randomziedBookList = bookList.OrderBy(x=> random.Next()).ToList();

            Library library1 = new Library(new List<Book> { randomziedBookList[0], randomziedBookList[5] }, "Library of the Adventure", "Stefansgade 19");
            Library library2 = new Library(new List<Book> { randomziedBookList[2], randomziedBookList[4] }, "Divine Arrow", "Stefansgade 19");
            Library library3 = new Library(new List<Book> { randomziedBookList[1], randomziedBookList[3] }, "The Undeads", "Stefansgade 19");

            libraryList = new List<Library>() { library1, library2, library3 };  
        }

     }

    public static List<Book> BookLists(params Book[] newBook)
    {

        if (bookList.Count == 0)
        {
            Book book1 = new Book("The Adventures of Huckleberry Finn", "Mark Twain", "xxxx", "MT", new DateTime(2013, 12, 19), 300, true);
            Book book2 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "1523", "FSF", new DateTime(2017, 05, 23), 420, true);
            Book book3 = new Book("Anna Karenina", "Leo Tolstoy", "1420", "LT", new DateTime(1995, 02, 17), 200, true);
            Book book4 = new Book("Harry Porter", "JK Rowlings", "1780", "JK", new DateTime(2007, 10, 10), 1500, true);
            Book book5 = new Book("Brave New World", "Aldous Huxley", "xxxx", "AH", new DateTime(2023, 02, 19), 199, true);
            Book book6 = new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", "xxxx", "GGM", new DateTime(2003, 08, 15), 462, true);

            bookList.Add(book1);
            bookList.Add(book2);
            bookList.Add(book3);
            bookList.Add(book4);
            bookList.Add(book5);
            bookList.Add(book6);
        }
        if (newBook.Length > 0)
        {
            for (int i = 0; i <bookList.Count; i++)
            {
                if (bookList[i].Title == newBook[0].Title && bookList[i].Author == newBook[0].Author)
                {
                    ColorMessage(ConsoleColor.Red, "Duplicate detected. Cannot add this book " + newBook[0].Title + "'.", true);
                    return bookList;
                }
            }
            bookList.Add(newBook[0]);
            ColorMessage(ConsoleColor.Green, "Book '" + newBook[0].Title + "' Added", true);
        }
        return bookList;
    }

    public static List<Book> RemoveBook(string bookTitle, string bookAuthor)
    {
        for (int i = 0; i < bookList.Count; i++)
        {
            if (bookList[i].Title.ToLower() == bookTitle.ToLower() && bookList[i].Author.ToLower() == bookAuthor.ToLower())
            {
                ColorMessage(ConsoleColor.Yellow, "Book '" + bookList[i].Title + "' by '" + bookList[i].Author + "' removed", true);
                bookList.RemoveAt(i);
                return bookList;
            }
        }
        ColorMessage(ConsoleColor.Red, "Book doesn't exists. ", true);
        return bookList;
    }

    public static Dictionary<bool, Book> BookExists(string _title)
    {
        Dictionary<bool, Book> bookInBookList = new Dictionary<bool, Book>();
         
        foreach (Book item in bookList)
        {
            if(item.Title.ToLower() == _title.ToLower())
            {
                bookInBookList.Add(true, item);
                return bookInBookList;
            }

        }
        bookInBookList.Add(false, new Book());
        return bookInBookList;
    }

    public static void GetBookDetails(int num)
    {
        Console.WriteLine("\nAll books listed below: ");
        if (num == 1)
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine(" " + (i + 1) + ") " + bookList[i].Title + "| Author - " + bookList[i].Author + "| Availability - " + bookList[i].Availability);
            }
        }
        else if(num == 2)
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine($" {(i+1)}) {bookList[i].Title}| Author - {bookList[i].Author}´| ISBN - {bookList[i].ISBN}| Publisher - {bookList[i].Publisher}| Publication Date - {bookList[i].Publication_Date}| Number of pages - {bookList[i].Number_of_Pages}| Availability - {bookList[i].Availability}");
            }
        }

    }

    public static void LoanABook(string bookTitle)
    {
        var bookexists = Program.BookExists(bookTitle);
        bool exists = bookexists.ContainsKey(true);

        if (exists)
        {
            int bookIndex = Program.bookList.IndexOf(bookexists[true]);
            Program.bookList[bookIndex].Checkout();
        }
        else
        {
            ColorMessage(ConsoleColor.Red,"Book doesn't exists!!",true);
        }
    }

    public static void ReturnBook(string bookTitle)
    {
        var bookexists = Program.BookExists(bookTitle);
        bool exists = bookexists.ContainsKey(true);

        if (exists)
        {
            int bookIndex = Program.bookList.IndexOf(bookexists[true]);
            Program.bookList[bookIndex].Return();
        }
        else
        {
            ColorMessage(ConsoleColor.Red, "Book doesn't exists!", true);
        }
    }

    public static void GetLibraryDetails(int num)
    {
        Console.WriteLine("\nAll libraries listed below: ");
        if (num == 1)
        {
            for (int i = 0; i < libraryList.Count; i++)
            {
                Console.WriteLine(" " + (i + 1) + ") " + libraryList[i].Name + "| Address - " + libraryList[i].Address);
            }
        }
        else if (num == 2)
        {
            for (int i = 0; i < libraryList.Count; i++)
            {
                if (libraryList[i].ListOfBooks.Count != 0) 
                    Console.WriteLine($" {(i + 1)}) {libraryList[i].Name}| Address - {libraryList[i].Address}| List of Books : {libraryList[i].ListOfBooks[0].Title}, {libraryList[i].ListOfBooks[1].Title}");
                else
                    Console.WriteLine($" {(i + 1)}) {libraryList[i].Name}| Address - {libraryList[i].Address}| List of Books : None");
            }
        }
    }


}


/*
 Library l1 = new Library();
        l1.Name = "Libraby One";
        l1.ListOfBooks = new List<Book> { b1, b2, b3 };

        Book[] addedBookList = new Book[10];
        for (int i = 0; i < 10; i++)
        {
            addedBookList[i] = new Book() {Title = $"BA{i}" };
        }
        Book[] boks = new Book[] { };

        l1.SeeBooks();

        l1.AddBook(addedBookList); ;


        l1.SeeBooks();*/