using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Two_Forked
{
    class Program
    {
        static void Main(string[] args)
        {

            Two_Forked_List<int> new_list = new Two_Forked_List<int>();
            new_list.Expended_Add(1);
            new_list.Add(2);
            new_list.Add(3);
            new_list.Add(4);
            new_list.Add(5);
            new_list.Add(6);
            new_list.Expended_Add(2);

            void Show()

            { Node<int> current = new_list.first;
                foreach (int it in new_list)
                {
                    Console.WriteLine(current.item);
                    current = current.next;
                }
            }

            Show();
            new_list.Delete();
            Show();
            Console.WriteLine(new_list.Contains(5));
            Console.WriteLine(new_list.Remove(2));
            Show();
            new_list.Expended_Add(123);
            new_list.Expended_Add(123);
            Show();
            new_list.Clear();
            Show();
            Console.ReadKey();
        }
    }
}
