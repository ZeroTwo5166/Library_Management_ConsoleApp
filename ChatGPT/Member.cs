using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class Member : Indentation
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public int LibraryId { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public int MemberId { get; set; }
        public string MemberPassword { get; set; }
        public bool IsLoggedIn { get; set; } = false;

        //Default Constructor
        public Member()
        {
      
        }


        //Constructor with all parameters
        public Member(string _name, string _address, long _phone, string _email,
            int _libraryId, List<Book> _burrowedBooks, int _memberId, string _memberPassword, bool _isLoggedIn)
        {
            this.Name = _name;
            this.Address = _address;
            this.Phone = _phone;
            this.Email = _email;
            this.LibraryId = _libraryId;
            this.BorrowedBooks = _burrowedBooks;
            this.MemberId = _memberId;
            this.MemberPassword = _memberPassword;
            this.IsLoggedIn = _isLoggedIn;
        }

        //Member check login
        public bool CheckUserLogin(int userId, string userPass)
        {
            Dictionary<int, Member> listOfMembers = Program.MemberLists();

            bool exists = listOfMembers.ContainsKey(userId) ? true : false;

            if (exists && userPass == listOfMembers[userId].MemberPassword)
            {
                Console.WriteLine($"Welcome {listOfMembers[userId].Name}!");
                this.IsLoggedIn = true;
                return IsLoggedIn;
            }

            else
            {
                bool runLoop = true;
                int _id;
                string _pass = string.Empty;
                do
                {
                    Console.WriteLine("\nIncorrect Credentials");
                    Console.Write("Enter User Id --> ");

                    bool checkUserId = int.TryParse(Console.ReadLine(), out int id);

                    _id = id;

                    Console.Write("Enter User Pass --> ");
                    _pass = Console.ReadLine();

                    bool existsAgain = listOfMembers.ContainsKey(_id) ? true : false;

                    if (existsAgain && _pass == listOfMembers[_id].MemberPassword)
                    {
                        runLoop = false;
                        this.IsLoggedIn = true;
                        Console.WriteLine("Login Successfull. Welcome {0}.", listOfMembers[_id].Name);
                        return IsLoggedIn;
                    }
                    else
                    {
                        continue;
                    }

                } while (runLoop);

                return false;
            }


        }

        //List alle borrowedbooks
        public void SeeBorrowedBooks()
        {
            foreach (Book book in BorrowedBooks)
            {
                Console.WriteLine(Indent(3) + "-> " + book.Title);
            }
        }

        //Lån Boger 
        public List<Book> BorrowBook(Book book)
        {
            //Skal tjek først hvis bogen er tilgængelig
            if (book.Availability == true)
            {
                Console.WriteLine($"Book \"{book.Title}\" borrowed.");
                this.BorrowedBooks.Add(book);
                book.Availability= false; //Skift availability fordi bogen er lånt
            }
            else
                Console.WriteLine($"Book \"{book.Title}\" is not available at the moment!!!");

            return this.BorrowedBooks;       
        }

        //Return Boger
        public void ReturnBook(Book book)
        {
            if (this.BorrowedBooks.Contains(book))
            {
                ColorMessage(ConsoleColor.Green, $"Book \"{book.Title}\" returned.", true);
                this.BorrowedBooks.Remove(book);
            }
            else
                ColorMessage(ConsoleColor.Red, $"You have not borrowed this book yet!!",true);
        }

        public void EditBookClassAsMember()
        {
            Console.Clear();
            Console.WriteLine("\nMember Book Option: ");
            Console.WriteLine("1) Loan a book");
            Console.WriteLine("2) Return a book");
            Console.WriteLine("3) List all books");
            Console.WriteLine("4) Go back to Member Menu");
            Console.Write("--> ");
            int memberOption = ValidNumberInput(Console.ReadLine(), 4);

            switch (memberOption)
            {
                case 1:
                    Console.WriteLine("\nLoan Book");
                    Console.Write("Enter book title: ");
                    string bookTitle = Console.ReadLine();

                    Console.Write("Enter book author: ");
                    string bookAuthor = Console.ReadLine();

                    var bookexists = Program.BookExists(bookTitle, bookAuthor);
                    bool exists = bookexists.ContainsKey(true);

                    if (exists)
                    {
                        int bookIndex = Program.bookList.IndexOf(bookexists[true]);
                        Program.bookList[bookIndex].Checkout();
                        BorrowedBooks.Add(Program.bookList[bookIndex]);
                    }
                    else
                    {
                        ColorMessage(ConsoleColor.Red, "Book doesn't exists!!", true);
                    }
                    break;

                case 2:
                    Console.WriteLine("\nReturn Book");
                    Console.Write("Enter book title: ");
                    string returnBookTitle = Console.ReadLine();

                    Console.Write("Enter book author: ");
                    string returnBookAuthor = Console.ReadLine();

                    for (int i = 0; i < BorrowedBooks.Count; i++)
                    {
                        if (BorrowedBooks[i].Title.ToLower() == returnBookTitle.ToLower() && BorrowedBooks[i].Author.ToLower() == returnBookAuthor.ToLower())
                        {
                            ColorMessage(ConsoleColor.Green, "Book returned!", true);
                            BorrowedBooks[i].Return();
                            BorrowedBooks.RemoveAt(i);
                        }
                    }
                    break;

                case 3:

                    break;

                case 4:

                    break;

                default:
                    break;
            }
        }

        public void EditLibraryClassAsMember()
        {

        }

        public void Borrowed()
        {

        }

    }
}
