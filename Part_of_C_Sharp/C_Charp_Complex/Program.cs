using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Complex
{
    class Program
    {

        struct Com_num
        {
            double vehs { get; }
            double mnim { get; }

            public Com_num(double _vehs, double _mnim)
            {
                vehs = _vehs;
                mnim = _mnim;
            }


            //перегруженные операторы
            public static Com_num operator +(Com_num num1, Com_num num2)
            {
                return new Com_num(num1.vehs + num2.vehs, num1.mnim + num2.mnim);
            }

            public static Com_num operator -(Com_num num1, Com_num num2)
            {
                return new Com_num(num1.vehs - num2.vehs, num1.mnim - num2.mnim);
            }

            public static Com_num operator *(Com_num num1, Com_num num2)
            {
                return new Com_num(num1.vehs * num2.vehs - num1.mnim * num2.mnim, num1.vehs * num2.mnim + num2.vehs * num1.mnim);
            }

            public static Com_num operator /(Com_num num1, Com_num num2)
            {
                return new Com_num((num1.vehs*num2.vehs + num1.mnim*num2.mnim)/(num2.vehs*num2.vehs + num2.mnim * num2.mnim), (num2.vehs*num1.mnim - num1.vehs*num2.mnim)/(num2.vehs * num2.vehs + num2.mnim * num2.mnim));
            }

            ///////////////////////////////////////////////////////////////////////////////////////

            //унарные операторы
            public static Com_num operator -(Com_num num)
            {
                return new Com_num(num.vehs, num.mnim);
            }

            public static Com_num operator +(Com_num num)
            {
                return new Com_num(-num.vehs, -num.mnim);
            }

            //перегруженные Eqals и операторы == и !=
            public static bool operator ==(Com_num num1, Com_num num2)
            {
                if (num1.Equals(num2))//if ((num1.mnim == num2.mnim) && (num1.vehs == num2.vehs))
                {
                    return true;
                }
                return false;
            }

            public static bool operator !=(Com_num num1, Com_num num2)
            {
                if (!num1.Equals(num2))//if ((num1.mnim != num2.mnim) || (num1.vehs != num2.vehs))
                {
                    return true;
                }
                return false;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                if (!(obj is Com_num))
                    return false;
                Com_num complex = (Com_num)obj;

                return vehs.Equals(complex.vehs) && mnim.Equals(complex.mnim);
            }

            public override int GetHashCode()
            {
                return vehs.GetHashCode() * 317 ^ mnim.GetHashCode();
            }


            //перегруженный ToString
            public override string ToString()
            {
               return "This complex number have: " + this.vehs + " - real part and " + this.mnim + " - imaginary part.";
            }

            //методы для двух переменных
            public void Add(Com_num n1, Com_num n2)
            {
                this += n1 + n2;
            }

            public void Sub(Com_num n1, Com_num n2)
            {
                this -= n1 - n2;
            }

            public void Mul(Com_num n1, Com_num n2)
            {
                this *= n1 * n2;
            }

            public void Dev(Com_num n1, Com_num n2)
            {
                this /= n1 / n2;
            }

            //статичные методы для двух параметров
            public static Com_num Add_Stat(Com_num n1, Com_num n2)
            {
                return n1 + n2;
            }

            public static Com_num Sub_Stat(Com_num n1, Com_num n2)
            {
                return n1 - n2;
            }

            public static Com_num Mul_Stat(Com_num n1, Com_num n2)
            {
                return n1 * n2;
            }

            public static Com_num Dev_Stat(Com_num n1, Com_num n2)
            {
                return n1 / n2;
            }

            //статические методы для неопределенного числа параметров
            public static Com_num Add_Stat(params Com_num[] com)
            {
                Com_num com_1 = new Com_num(0.0d, 0.0d);
                foreach (Com_num _com in com)
                {
                    com_1 += _com;
                }
                return com_1;
            }

            public static Com_num Mul_Stat(params Com_num[] com)
            {
                Com_num com_1 = new Com_num(1.0d, 1.0d);
                foreach (Com_num _com in com)
                {
                    com_1 *= _com;
                }
                return com_1;
            }

            //методы для неопрделенного числа параметров
            public void Add(params Com_num[] com)
            {
                foreach (Com_num comp in com)
                {
                    this += comp;
                }
            }

            public void Mul(params Com_num[] com)
            {
                foreach (Com_num comp in com)
                {
                    this *= comp;
                }
            }

            //модуль
            public static double Modul(Com_num com_1)
            {
                return (double)com_1;
            }

            public static explicit operator double(Com_num num)
            {
                return Math.Sqrt(num.vehs * num.vehs + num.mnim * num.mnim);
            }

        }
        static void Main(string[] args)
        {

            Com_num num1 = new Com_num(1.445, 5.44);
            Com_num num2 = new Com_num(1.445, 5.44);
            Com_num num3 = new Com_num(4.32, 1.0);
            Com_num num4 = new Com_num(4.25, 0.5);
            Com_num num5 = new Com_num(1.445, 5.44);
            Com_num num6 = new Com_num(-1.445, -5.44);

            Console.WriteLine(num1 + num3);
            Console.WriteLine(num4 - num3);
            Console.WriteLine(num1 == num2);
            Console.WriteLine(num1 != num4);
            Console.WriteLine(num1 == num4);
            Console.WriteLine(num1.Equals(num5));
            Console.WriteLine((double)num6);
            num3 -= num2;
            num4 += num2;

            Console.WriteLine(num4 != num2);

            Console.ReadKey();
        }
    }
}
