using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Test
{
    public class Library
    {
        public event EventHandler<string> nb;

        List<Book> books = new List<Book>();
        public static DateTime date_now = new DateTime(2017, 9, 9);
        List<Abonent> abonents = new List<Abonent>();

        // добавление книги
        public void Add_Book(params Book[] bk)
        {
            foreach (Book b in bk)
            {
                books.Add(b);
                nb(this, "Add book: " + b.name);
               
            }
        }

        // индексатор
        public Book this[string author, string name]
        {
                get
                {
                    List<Book> find = Find(author, false);
                    foreach (Book book in Find(name, true))
                        if (find.Contains(book))
                            return book;
                        return null;
                }

        }

        public List<Book> FullList()
        {
            List<Book> full = new List<Book>();
            full.AddRange(books);
            foreach (Abonent ab in abonents)
            {
                full.AddRange(ab.ListBooks());
            }
            return full;
        }

        // поиск по имени или названию
        public List<Book> Find(string name, bool isName)
        {
                List<Book> find = new List<Book>();

                foreach (Book book in FullList())
                    if (isName)
                    {
                        if (book.name == name) find.Add(book);
                    }
                    else
                        if (book.author == name)
                        find.Add(book);
                return find;
        }

        public void Add_Abonent (Abonent ab)
        {
            abonents.Add(ab);
            nb(this, "Add new abonent: " + ab.name);
        }

        //выдача книги
        public void Give_Book(Abonent ab, Book book)
        {
            int count_abonent = 0;
            foreach (Abonent ab1 in abonents)
                if (ab1.name == ab.name && ab1.telephon_number == ab1.telephon_number)
                    count_abonent++;
            if (count_abonent == 0)
                Add_Abonent(ab);
            
            if (ab.OverdueBooks().Count == 0 && ab.ListBooks().Count < 5 && (ab.has_rare == false || (ab.has_rare == true && book.status_rare == false)))
            {
                bool hasBook = false;
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i] == book)
                    {
                        books.Remove(book);
                        hasBook = true;
                        break;
                    }
                }
                if (!hasBook)
                {
                    Console.WriteLine("Abonent {0}, no book {1} in library ", ab.name, book.author + " " + book.name);
                    return;
                }
                book.abonent = ab;
                book.date_issue = DateTime.Now;
                //book.date_return = DateTime.Now.AddDays(14);
                //book.status_of_issue = true;
                ab.books.Add(book);
                nb(this, $"Change book status: {book.name} by {book.author} was taken {ab.name}");
                if (book.status_rare)
                    ab.has_rare = true;
            }
            else
            {
                Console.WriteLine("Abonent {0}, return {1} books", ab.name, ab.OverdueBooks().Count > 0 ? "overdue" : "excees");
            }

        }

        public void Return_Book(Abonent ab, Book book)
        {
            ab.ReturnBook(this, book);
            nb(this, $"Change book status: {book.name} by {book.author} is returned to the Library");
        }

        
    }
}
