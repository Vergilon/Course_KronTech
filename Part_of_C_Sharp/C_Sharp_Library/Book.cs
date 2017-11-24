using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Test
{
    public class Book
    {

        public String author { get; private set; }
        public String name { get;  private set; }
        public bool status_rare { get; private set; }   //статус редкости: 1 - редкий 0 - нет
        //public bool status_of_issue { get; set; }  //статус наличия в бибилиотеке: 1 - у абонента 0 - в библиотеке
        public Abonent abonent { get; set; }
        public DateTime date_issue { get; set; }  //дата выдачи
        public DateTime date_return { get { return date_issue.AddDays(14); }} // дата окончания срока


        public Book(String _Author, String _Name, bool _Status_rare)
        {
            author = _Author;
            name = _Name;
            status_rare = _Status_rare;
            //status_of_issue = false;
            abonent = null;
            date_issue = DateTime.MinValue;
            //date_return = DateTime.MinValue;
        }

        public string Get_Inf()  //получение основной информации
        {
            String s = (String.Format($"Named book {name} by {author}. Rare = {status_rare}"));
            return s;
        }

        public bool Get_Info_Where_Book()  //где находится книга
        {
            return (abonent != null);
        }

        public bool Overdue_Book()  //просрочена ли книга
        { 
            return Library.date_now.DayOfYear - date_issue.DayOfYear >= 14;
        }

        public DateTime Date_of_Issue()  //узнать дату выдачи книги
        {
            if (abonent != null)
                return date_issue;
            else
            {
                Console.WriteLine("Nobody take this book");
                return date_issue;
            }
        }

    }
}
