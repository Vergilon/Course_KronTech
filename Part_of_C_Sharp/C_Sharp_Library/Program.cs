using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Test
{
    class Program
    {


        static void Main(string[] args)
        {
            Library lib = new Library();
            List<Book> books = new List<Book>();
            List<Abonent> abonents = new List<Abonent>();
            EventHandler<string> add = (sender, str) => Console.WriteLine(str);
            lib.nb += add;
            void Main_menu()
            {
                Console.Clear();
                Console.WriteLine("Main menu");
                Console.WriteLine("0 - Add new book");
                Console.WriteLine("1 - Add new Abonent");
                Console.WriteLine("2 - Give some information");
                Console.WriteLine("3 - Search book");
                Console.WriteLine("4 - Give book");
                Console.WriteLine("5 - Return book");
                Console.WriteLine("6 - Exit");
                Console.WriteLine();
                Console.WriteLine("Enter number: ");
                int i = Int32.Parse(Console.ReadLine());
                switch (i)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Enter Name Author, Name Book and status of rare (true or false)");
                        String _name_a = Console.ReadLine();
                        String _name_b = Console.ReadLine();
                        bool _rare = Boolean.Parse(Console.ReadLine());
                        books.Add(new Book(_name_a, _name_b, _rare));
                        lib.Add_Book(books.Last());
                        Console.Clear();
                        Main_menu();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter Name and telephone");
                        String _name = Console.ReadLine();
                        int _tel = Int32.Parse(Console.ReadLine());
                        abonents.Add(new Abonent(_name, _tel));
                        lib.Add_Abonent(abonents.Last());
                        Console.Clear();
                        Main_menu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter number: ");
                        Console.WriteLine("0 - Info about books");
                        Console.WriteLine("1 - Info about abonent");
                        Console.WriteLine("2 - Info about library books");
                        int c = Int32.Parse(Console.ReadLine());
                        switch (c)
                        {
                            case 0:
                                List<Book> bk = new List<Book>();
                                Console.WriteLine("Enter Name book");
                                String s = Console.ReadLine();
                                Console.WriteLine(lib.Find(s, true).First().Get_Inf());
                                Console.ReadKey();
                                break;
                            case 1:
                                Console.WriteLine("Enter Name");
                                String s1 = Console.ReadLine();
                                foreach (Abonent ab in abonents)
                                    if (ab.name.Equals(s1))
                                        Console.WriteLine(ab.Get_Inf());
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("In Library");
                                foreach (Book b in books)
                                    Console.WriteLine(b.Get_Inf());
                                Console.ReadKey();
                                break;
                        }
                        Console.Clear();
                        Main_menu();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("How you want search book?");
                        Console.WriteLine("'true' - name book, 'false' - name author");
                        bool o = Boolean.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name: ");
                        String s_name = Console.ReadLine();
                        if (o)
                        {
                            if (lib.Find(s_name, o)[0].name != null)
                                Console.WriteLine("This book is here.");
                            else
                                Console.WriteLine("Not found");
                        }
                        else
                        {
                            if (lib.Find(s_name, o)[0].name != null)
                                Console.WriteLine("This book is here.");
                            else
                                Console.WriteLine("Not found");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        Main_menu();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter Name and telephone");
                        String _name_2 = Console.ReadLine();
                        int _tel_2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name book");
                        String ser_1 = Console.ReadLine();
                        foreach (Abonent abon in abonents)
                        {
                            if (abon.name == _name_2 && abon.telephon_number == _tel_2)
                            {
                                lib.Return_Book(abon, lib.Find(ser_1, true)[0]);
                                Console.WriteLine("Yes");
                            }

                        }
                        Console.ReadKey();
                        Console.Clear();
                        Main_menu();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter Name and telephone");
                        String _name_1 = Console.ReadLine();
                        int _tel_1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name book");
                        String ser = Console.ReadLine();
                        foreach (Abonent abon in abonents)
                        {
                            if (abon.name == _name_1 && abon.telephon_number == _tel_1)
                            {
                                lib.Give_Book(abon, lib.Find(ser, true)[0]);
                                Console.WriteLine("Yes");
                            }

                        }
                        Console.ReadKey();
                        Console.Clear();
                        Main_menu();
                        break;

                    case 6:
                        break;
                }
            }

            Console.WriteLine("If you want just look at programs' work enter 'true'");
            Console.WriteLine("If you want work entered all data all alone enter 'false'");
            bool opi = Boolean.Parse(Console.ReadLine());
            if (!opi)
            
            

            try { Main_menu(); }
            catch (ArgumentOutOfRangeException)
            { }
            catch (FormatException)
            { }


            else {
                Book book1 = new Book("Gilbert", "I don't know", true);
                Book book2 = new Book("Gilbert_2", "I don't know_2", true);
                lib.Add_Book(book1, book2);

                Console.WriteLine(lib["Gilbert", "I don't know"].name);
                Console.WriteLine(lib.FullList().ElementAt(1).author);
                Console.WriteLine(lib.Find("Gilbert_2", false)[0].name);
                Abonent ab1 = new Abonent("John", 214875);
                ab1.Get_Inf();
                lib.Give_Book(ab1, book1);
                Console.WriteLine(ab1.OverdueBooks()[0].name);
                Console.WriteLine(book1.Overdue_Book());

                Console.ReadKey();
            }

        }

    }
}
