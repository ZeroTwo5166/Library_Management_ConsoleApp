using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class Book : Indentation
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string ISBN { get; set; } = "";
        public string Publisher { get; set; } = "";
        public DateTime Publication_Date { get; set; }
        public int Number_of_Pages { get; set; } = 0;
        public bool Availability { get; set; } = true;

        //Constructor uden parameter
        public Book()
        {

        }

        //Constructor med alle parameter
        public Book(string _title, string _author, string _ISBN,
            string _Publisher, DateTime _publishedDate, int _numberOfPages, bool _avaibility)
        {
            this.Title = _title;
            this.Author = _author;
            this.ISBN = _ISBN;
            this.Publisher = _Publisher;
            this.Publication_Date = _publishedDate;
            this.Number_of_Pages = _numberOfPages;
            this.Availability = _avaibility;
        }

        //Personer tager Boger 
        public bool Checkout()
        {
            if (this.Availability) 
                ColorMessage(ConsoleColor.Green, $"Book \"{this.Title}\" Checkedout!", true);

            else
                ColorMessage(ConsoleColor.Red, $"Book \"{this.Title}\" is not available at the moment...", true);

            return this.Availability = false;
        }

        //Personer aflever Boger
        public bool Return()
        {
            if(this.Availability)
                ColorMessage(ConsoleColor.Yellow, $"Book \"{this.Title}\" is not borrowed yet to return it back!", true);
            else
                ColorMessage(ConsoleColor.Green, $"Book \"{this.Title}\" Returned!!", true);

            return this.Availability = true;
        }

    }
}

