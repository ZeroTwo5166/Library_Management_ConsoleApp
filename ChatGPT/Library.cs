using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class Library : Indentation
    {
        public List<Book> ListOfBooks { get; set; } = new List<Book>() { };
        public string Name { get; set; }
        public string Address { get; set; }

        //Original Constructor
        public Library() 
        {
        }

        //Constructor med parameters
        public Library(List<Book> bookList, string _name, string _address)
        {
            this.ListOfBooks = bookList;
            this.Name = _name;
            this.Address = _address;
        }

        //Viser alle Books i Library
        public void SeeBooks()
        {
            if(ListOfBooks.Count > 0)
            {
                Console.WriteLine("Library Contains:");
                foreach (var book in ListOfBooks)
                {
                    Console.WriteLine(Indent(3) + "-> " + book.Title);
                }
            }
            else
            {
                Console.WriteLine("Library is Empty!!! ");
            }
        }

        //Tilføje boger ind i List/Library
        public List<Book> AddBook(params Book[] books) //Tager params array fordi why not?
        {
            if(books.Length > 0)
            {
                //Laver en ny array af boger der indholder alle boger der skal tilføjes
                Book[] _listofbooks = new Book[books.Length];

                //Bare for index. Kunne har brugt for loop i sted for
                int bookIndex = 0;
                foreach (var book in books)
                {
                    _listofbooks[bookIndex] = book;
                    bookIndex += 1;
                }
                /*
                for (int i = 0; i < books.Length; i++)
                {
                    _listofbooks[i] = books[i];
                } */

                //Convert array til List fordi vores hoved Library er "LIST"
                List<Book> addedBooks = _listofbooks.ToList();
                //Concat begge to list
                ListOfBooks.AddRange(addedBooks);
                ColorMessage(ConsoleColor.Green, "\nBooks added:", true);
                foreach (var book in addedBooks)
                {
                    Console.WriteLine(Indent(3) + "-> " + book.Title); ;
                }
                //return ny List/Library med tilføjede boger
                return ListOfBooks;
            }
            else //Hvis er der ingen boger i parameter, retunere bare original array
            {
                ColorMessage(ConsoleColor.Yellow, "No books added... ", true);
                return this.ListOfBooks;
            }
        }

        //Søg boger ind i List/Library
        public Book SearchBook(Book book)
        {
            //Book searchedResult = this.ListOfBooks.Find(x => x.Title == book.Title);

            if (this.ListOfBooks.Contains(book))
            {
                Console.WriteLine("Book \"{book.Title}\" found!");
                return book;
            }
            Console.WriteLine("Book \"{book.Title}\" not found!!!");
            return new Book();
            //return null;
        }

        //Fjern boger fra listen/Library
        public List<Book> RemoveBook(Book book)
        {
            if (this.ListOfBooks.Contains(book)){
                this.ListOfBooks.Remove(book);
                Console.WriteLine($"Book \"{book.Title}\" removed!");
            }
            else
            {
                Console.WriteLine($"Book \"{book.Title}\" not found!");
            }
            return this.ListOfBooks;
        }

    }

}

