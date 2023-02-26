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
        public string MemberPassword { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        //Default Constructor
        public Member()
        {
      
        }


        //Constructor with all parameters
        public Member(string _name, string _address, long _phone, string _email,
            int _libraryId, List<Book> _burrowedBooks)
        {
            this.Name = _name;
            this.Address = _address;
            this.Phone = _phone;
            this.Email = _email;
            this.LibraryId = _libraryId;
            this.BorrowedBooks = _burrowedBooks;
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
                Console.WriteLine($"Book \"{book.Title}\" returned.");
                this.BorrowedBooks.Remove(book);
            }
            else
                Console.WriteLine($"You have not borrowed this book yet!!");
        }

 
    }
}
