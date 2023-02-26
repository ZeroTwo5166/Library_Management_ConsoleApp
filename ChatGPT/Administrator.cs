using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class Administrator : Indentation
    {
        public string AdminId { get; set; }
        public string AdminPass { get; set; }
        public bool IsLoggedIn { get; set; } = false;
        public Administrator()
        {
        }

        public bool CheckAdminLogin(string adminUser, string adminPass)
        {
            if (adminUser == "root" && adminPass == "toor")
            {
                this.IsLoggedIn = true;
                Console.Clear();
                ColorMessage(ConsoleColor.Green, "Login Successfull. Welcome Admin#", true);
                return IsLoggedIn;
            }
            else
            {
                bool runLoop = true;
                string Id = string.Empty;
                string Pass = string.Empty;
                do
                {
                    ColorMessage(ConsoleColor.Red, "\nIncorrect Credentials", true);
                    Console.Write("Enter Admin Id --> ");
                    Id = Console.ReadLine();
                    Console.Write("Enter Admin Password --> ");
                    Pass = Console.ReadLine();

                    if (Id == "root" && Pass == "toor")
                    {
                        runLoop = false;
                        this.IsLoggedIn = true;
                        Console.Clear();
                        ColorMessage(ConsoleColor.Green, "Login Successfull. Welcome Admin#", true);
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

        public void EditBookClassAsAdmin()
        {
            bool runLoop = true;
            do
            {
                ColorMessage(ConsoleColor.Cyan, "\nAdmin Book Menu", true);
                Console.WriteLine("Choose option: ");
                Console.WriteLine("1) Create a book");
                Console.WriteLine("2) Delete a book");
                Console.WriteLine("3) Edit a book");
                Console.WriteLine("4) Loan a book");
                Console.WriteLine("5) Return a book");
                Console.WriteLine("6) List all book");
                Console.WriteLine("7) Go back to Admin Menu");
                Console.Write("Option --> ");
                int bookOption = ValidNumberInput(Console.ReadLine(), 7);

                switch (bookOption)
                {
                    case 1:
                        Console.WriteLine("\nEnter Book information:");
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
              
                        Console.Write("Author: ");
                        string author = Console.ReadLine();

                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine();

                        Console.Write("Publisher: ");
                        string publisher = Console.ReadLine();

                        Console.WriteLine("Publication Date: ");
                        DateTime publicationDate = GetDate();

                        Console.Write("Number of Pages: ");
                        int numberOfPages = ValidNumberInput(Console.ReadLine(), 100000);

                        Console.Write("Availability ('yes' or 'no'): ");
                        bool availability = GetBoolean(Console.ReadLine());

                        Book newBook = new Book(title, author, isbn, publisher, publicationDate, numberOfPages, availability);

                        Program.BookLists(newBook);
                        break;


                    case 2:
                        Console.WriteLine("Enter book title.");
                        Console.Write("--> ");
                        string titleRemove = Console.ReadLine();

                        Console.WriteLine("Enter book author.");
                        Console.Write("--> ");
                        string authorRemove = Console.ReadLine();
                        Program.RemoveBook(titleRemove, authorRemove);
                        break;


                    case 3:
                        Console.WriteLine("\nEnter book title to edit it.");
                        Console.Write("--> ");
                        string editTitle = Console.ReadLine();

                        Console.WriteLine("\nEnter book author to edit it.");
                        Console.Write("--> ");
                        string editAuthor = Console.ReadLine();

                        EditBook(editTitle, editAuthor);
                        break;

                    case 4:
                        Console.WriteLine("Enter book title to loan it. ");
                        Console.Write("--> ");
                        Program.LoanABook(Console.ReadLine());
                        break;

                    case 5:
                        Console.WriteLine("Enter book title to return it.");
                        Console.Write("-->");
                        Program.ReturnBook(Console.ReadLine());
                        break;

                    case 6:
                        Console.WriteLine("List all books below.");
                        Console.WriteLine("1) Less detail | 2) More detail");
                        Console.Write("--> ");
                        int detailOption = ValidNumberInput(Console.ReadLine(), 2);
                        Program.GetBookDetails(detailOption);                    
                        break;

                    case 7:
                        runLoop = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("---");
                        break;
                }

            } while (runLoop);
            
            
        }

        public void EditLibraryClassAsAdmin()
        {
            bool runLoop = true;
            do
            {
                ColorMessage(ConsoleColor.Cyan, "\nAdmin Library Menu", true);
                Console.WriteLine("1) Create a Library");
                Console.WriteLine("2) Delete a Library");
                Console.WriteLine("3) Edit a Library");
                Console.WriteLine("4) List all Libraries");
                Console.WriteLine("5) Go back to Admin Menu");
                Console.Write("Option --> ");
                int bookOption = ValidNumberInput(Console.ReadLine(), 5);

                switch (bookOption)
                {
                    case 1:
                        CreateLibrary();
                        break;

                    case 2:
                        Console.WriteLine("Enter following details to remove library: ");
                        Console.Write("Library Name: ");
                        string libName = Console.ReadLine();

                        Console.Write("Library Address: ");
                        string libAddress = Console.ReadLine();

                        RemoveLibrary(libName, libAddress);
                        break;

                    case 3:
                        break;

                    case 4:
                        Console.WriteLine("List all libraries below.");
                        Console.WriteLine("1) Less detail | 2) More detail");
                        Console.Write("--> ");
                        int detailOption = ValidNumberInput(Console.ReadLine(), 2);
                        Program.GetLibraryDetails(detailOption);
                        break;

                    case 5:
                        runLoop= false;
                        Console.Clear();
                        break;

                    default:
                        break;
                }


            } while (runLoop);
        }

        private void EditMemberClassAsAdmin()
        {

        }

        private static DateTime GetDate()
        {
            Console.Write("Day: ");
            var day = ValidNumberInput(Console.ReadLine(), 31);

            Console.Write("Month: ");
            var month = ValidNumberInput(Console.ReadLine(), 12);

            Console.Write("Year: ");
            var year = ValidNumberInput(Console.ReadLine(), 2023);

            return new DateTime(year, month, day, 0, 0, 0, 0);
        }

        static bool GetBoolean(string input)
        {
            do
            {
                if (input.ToLower() == "y" || input.ToLower() == "yes" || input.ToLower() == "ye")
                    return true;

                else if (input.ToLower() == "n" || input.ToLower() == "no")
                    return false;

                Console.Write("Enter correct input. ('y' or 'n') --> ");
                string secondInput = Console.ReadLine();

                if (secondInput.ToLower() == "y" || secondInput.ToLower() == "yes" || secondInput.ToLower() == "ye")
                    return true;

                else if (secondInput.ToLower() == "n" || secondInput.ToLower() == "no")
                    return false;

                else
                    continue;

            } while (true);
        }

        private Book EditBook(string bookTitle, string bookAuthor)
        {
            Book changedBook = new Book();

            for (int i = 0; i < Program.bookList.Count; i++)
            {
                if (Program.bookList[i].Title.ToLower() == bookTitle.ToLower() && Program.bookList[i].Author.ToLower() == bookAuthor.ToLower())
                {
                    changedBook = EditBookParams(Program.bookList[i]);
                    return changedBook;
                }
            }
            Console.WriteLine("Book doesn't exists!");
            return changedBook;
        }

        private Book EditBookParams(Book bookThatNeedsToBeChanged)
        {
            Console.WriteLine("Enter values that needed to be changed or just press enter to have the same previous value.");

            Console.Write("Edit Title: ");
            string editTitle = Console.ReadLine();
            if (editTitle != "")
                bookThatNeedsToBeChanged.Title = editTitle;

            Console.Write("Edit Author: ");
            string editAuthor = Console.ReadLine();
            if (editAuthor != "")
                bookThatNeedsToBeChanged.Author = editAuthor;

            Console.Write("Edit ISBN: ");
            string editISBN = Console.ReadLine();
            if (editISBN != "")
                bookThatNeedsToBeChanged.ISBN = editISBN;

            Console.Write("Edit Publisher: ");
            string editedPublisher = Console.ReadLine();
            if (editedPublisher != "")
                bookThatNeedsToBeChanged.Publisher = editedPublisher;

            Console.Write("Edit Publication Date ('y' or 'n'): ");
            bool editPubDate = GetBoolean(Console.ReadLine());
            if (editPubDate)
            {
                DateTime editedDate = GetDate();
                bookThatNeedsToBeChanged.Publication_Date = editedDate;
            }

            Console.Write("Edit Number of Pages: ");
            string editedPageNum = Console.ReadLine();
            if(editedPageNum != "")
            {
                int editedPageNumber = ValidNumberInput(editedPageNum, 100000);
                bookThatNeedsToBeChanged.Number_of_Pages= editedPageNumber;
            }

            Console.Write("Edit Availability ('y' or 'n'): ");
            string editedAvailabilityString = Console.ReadLine();
            if (editedAvailabilityString != "")
            {
                bool check = GetBoolean(editedAvailabilityString);
                if (check)
                {
                    Console.Write("Enter new availability ('y' or 'n'): ");
                    bool newAvailability = GetBoolean(Console.ReadLine());
                    if(newAvailability)
                    {
                        bookThatNeedsToBeChanged.Availability = true;
                    }
                    else
                        bookThatNeedsToBeChanged.Availability= false;
                }
            }

            return bookThatNeedsToBeChanged;
        }

        private void CreateLibrary()
        {
            Console.WriteLine("\nAdd Library Option -->");
            Console.Write("Name: ");
            string libraryName = Console.ReadLine();

            Console.Write("Address: ");
            string libraryAddress = Console.ReadLine();


            Library newLibrary = new Library();
            newLibrary.Name = libraryName;
            newLibrary.Address = libraryAddress;

            var libDict = LibraryExists(newLibrary);

            bool libExists = libDict.ContainsKey(true);

            if (libExists)
            {
                ColorMessage(ConsoleColor.Red, "Library already exists. Cannot add this library again.", true);
            }
            else
            {
                ColorMessage(ConsoleColor.Green, "Library Added", true);
                ColorMessage(ConsoleColor.Yellow, "To add Books in this library, edit the library from the Admin Library Menu", true);
                Program.libraryList.Add(newLibrary);
            }

        }

        private Dictionary<bool,Library> LibraryExists(Library newLib)
        {
            var libDict = new Dictionary<bool,Library>();

            for (int i = 0; i < Program.libraryList.Count; i++)
            {
                if (Program.libraryList[i].Name.ToLower() == newLib.Name.ToLower() && Program.libraryList[i].Address.ToLower() == newLib.Address.ToLower())
                {
                    libDict.Add(true, newLib);
                }

            }
            libDict.Add(false, new Library());
            return libDict;
        }

        private List<Library> RemoveLibrary(string libName, string libAddress)
        {
            for (int i = 0; i < Program.libraryList.Count; i++)
            {
                if (Program.libraryList[i].Name.ToLower() == libName.ToLower() && Program.libraryList[i].Address.ToLower() == libAddress.ToLower())
                {
                    ColorMessage(ConsoleColor.Yellow, "Library '" + Program.libraryList[i].Name + "' at address " + Program.libraryList[i].Address +  " removed", true);
                    Program.libraryList.RemoveAt(i);
                    return Program.libraryList;
                }
            }
            ColorMessage(ConsoleColor.Red, "Library doesn't exists. ", true);
            return Program.libraryList;
        }


    }  

}

