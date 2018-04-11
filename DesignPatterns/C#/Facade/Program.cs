using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    // ------------ Complex system ----------------
    public class Book
    {
        public Author Author { set; get; }
        public Publisher Publisher { set; get; }
        public Content Content { set; get; }
        public Book() { }
        public Book(Author author, Publisher publisher, Content content)
        {
            Author = author;
            Publisher = publisher;
            Content = content;
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public Author() { }
        public Author(string name)
        {
            Name = name;
        }

        public bool HasAuthor(Book book)
        {
            return !string.IsNullOrEmpty(book.Author.Name);
        }
    }

    public class Publisher
    {
        public string Name { get; set; }
        public Publisher() { }
        public Publisher(string name)
        {
            Name = name;
        }

        public bool HasPublisher(Book book)
        {
            return !string.IsNullOrEmpty(book.Publisher.Name);
        }
    }

    public class Content
    {
        public string Title { get; set; }
        public Content() { }
        public Content(string title)
        {
            Title = title;
        }

        public bool HasContent(Book book)
        {
            return !string.IsNullOrEmpty(book.Content.Title);
        }
    }

    // ------------- Facade -------------------
    public class FacadeBook
    {
        internal Author Author { get; set; } = new Author();
        internal Content Content { get; set; } = new Content();
        internal Publisher Publisher { get; set; } = new Publisher();


        public string  IsPublishable(Book book)
        {
            return Author.HasAuthor(book) &&
                   Content.HasContent(book) &&
                   Publisher.HasPublisher(book) ? "" : "not ";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var facade = new FacadeBook();
            var book1 = new Book(new Author(""), new Publisher(""), new Content("Arta razboiului"));
            var book2 = new Book(new Author("Eckhart Tolle"), new Publisher("WestPubicHeer"), new Content("Puterea prezentului"));
            Console.WriteLine($"Book '{book1.Content.Title}' is {facade.IsPublishable(book1)}publishable");
            Console.WriteLine($"Book '{book2.Content.Title}' is {facade.IsPublishable(book2)}publishable");
            Console.ReadKey();
        }
    }
}
