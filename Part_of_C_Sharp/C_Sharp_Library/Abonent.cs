using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Test
{
    public class Abonent
    {
        public String name { get; private set; }
        public int telephon_number { get; set; }
        public List<Book> books { get; }
        public bool has_rare { get; set; }

        public Abonent(String _name, int _telephone)
        {
            name = _name;
            telephon_number = _telephone;
            books = new List<Book>();
            has_rare = false;
        }

        //мтеод для изменения конатактного номера абонента
        public void Change_number()
        {
            Console.Write("Enter new number: ");
            try
            {
                int t = Int32.Parse(Console.ReadLine());
                telephon_number = t;
                Console.WriteLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("You enter not a number. Try again.");
                Change_number();
            }
        }

        //индексатор для получения книги по индексу
        public Book this[int k]
        {
            get { return books[k]; }
        }
        // Информация о абоненте
        public String Get_Inf()
        {
            String str = "Name " + name + " with telephone " + telephon_number;
            return str;
        }

        // Список книг
        public List<Book> ListBooks()
        {
            return books;
        }

        // Список просроченных книг
        public List<Book> OverdueBooks()
        {
            List<Book> ob = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Overdue_Book())
                    ob.Add(book);
            }
            return ob;
        }

        // Получение книги
        public void Give_book(Library library, Book book)
        {
            library.Give_Book(this, book);
        }

        // Возврат книги
        public void ReturnBook(Library library, Book book)
        {
            books.Remove(book);
            book.date_issue = DateTime.MinValue;
            //book.date_return = DateTime.MinValue;
            book.Overdue_Book();

            if (book.status_rare)
                has_rare = false;
            library.Add_Book(book);
        }

    }
}
