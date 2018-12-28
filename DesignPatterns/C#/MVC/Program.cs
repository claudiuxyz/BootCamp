using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    public interface Observer
    {
        void Update();
    }

    public interface Observable
    {
        void AttachObserver(Observer observer);
    }

    public interface View
    {
        void ShowContent(string field1, string field2);
        void ShowHeader();
        void ShowFooter();
    }

    //============== Model =========================
    public class Book
    {
        public string Title { set; get; }
        public string Author { set; get; }
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    public class Library: Observable
    {
        private List<Observer> m_observers = new List<Observer>();
        private List<Book> m_books = new List<Book>();

        public void AddBook(Book book)
        {
            m_books.Add(book);
            foreach (var o in m_observers)
            {
                o.Update();
            }
        }

        public Book GetBook(int idx)
        {
            if (idx < m_books.Count)
            {
                return m_books.ElementAt(idx);
            }
            return null;
        }

        public int Count()
        {
            return m_books.Count;
        }

        public LibraryTraversal CreateTraversal()
        {
            return new LibraryTraversal(this);
        }

        public void  AttachObserver(Observer observer)
        {
            m_observers.Add(observer);
        }
    }

    public class LibraryTraversal
    {
        private Library m_collection;
        private int m_idx = -1;

        public LibraryTraversal(Library collection)
        {
            m_collection = collection;
        }

        public Book First()
        {
            if (m_collection.Count() > 0)
            {
                m_idx = 0;
                return m_collection.GetBook(m_idx);
            }

            return null;
        }

        public bool IsDone()
        {
            return m_collection.Count() == m_idx || m_idx == -1;
        }

        public Book Next()
        {
            m_idx++;
            if (m_idx < m_collection.Count())
            {
                return m_collection.GetBook(m_idx);
            }
            return null;
        }

        public Book Current()
        {
            return m_collection.GetBook(m_idx);
        }

    }
    //================== View ===========================

    class ViewLibraryByTitle: View
    {
        public void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine("========= Books list (by title) ========");
        }

        public void ShowFooter()
        {
            Console.WriteLine("========================================");
        }
        public void ShowContent(string field1, string field2)
        {
            Console.WriteLine($"* {field2}, {field1}");
        }
    }

    class ViewLibraryByAuthor : View
    {
        public void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~ Books list (by author) ~~~~~~~~");
        }

        public void ShowFooter()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        public void ShowContent(string field1, string field2)
        {
            Console.WriteLine($"> {field1}: {field2}");
        }
    }

    //-------------------- Controller ---------------------

    class LibraryController : Observer
    {
        private View m_view;
        private Library m_model;

        public LibraryController(Library model, View view)
        {
            m_model = model;
            m_view = view;
            m_model.AttachObserver(this);
        }
        public void Update()
        {
            UpdateView();
        }

        public void AddInModel(string title, string author)
        {
            m_model.AddBook(new Book(title, author));
        }

        public void UpdateView()
        {
            m_view.ShowHeader();
            var traversal = m_model.CreateTraversal();
            var book = traversal.First();
            while(!traversal.IsDone())
            {
                m_view.ShowContent(book.Author, book.Title);
                book=traversal.Next();
            }
            m_view.ShowFooter();
        }
    }
    //---------------------------------------------------

    class Program
    {
        static void Main(string[] args)
        {
            Library model = new Library();
            View view = new ViewLibraryByAuthor();
            LibraryController controller = new LibraryController(model, view);
            controller.AddInModel("Puterea prezentului", "Eckhart Tolle");
            controller.AddInModel("Calatorii in afara corpului", "Robert Monroe");
            controller.AddInModel("Trezirea inteligentei ", "Jiddu Krishnamurti");
            Console.ReadKey();
        }
    }
}
