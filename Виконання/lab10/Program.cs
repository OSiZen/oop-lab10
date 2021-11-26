using System;
using System.Linq;

namespace lab10
{
    class Overload
    {
        public char [] element = new char[4];
        public char[] element2 = new char[5];
        protected char a, b, c, d;

        public Overload (char a, char b, char c, char d)
        {
            element[0] = a;
            element[1] = b;
            element[2] = c;
            element[3] = d;
        }

        public Overload(char a, char b, char c, char d, char f)
        {
            element2[0] = a;
            element2[1] = b;
            element2[2] = c;
            element2[3] = d;
            element2[4] = f;
        }

        public static Overload operator -(Overload x, char y)
        {
            x.element = x.element.Except(new char[] { y }).ToArray();
            foreach (char i in x.element)
            {
                Console.WriteLine(i);
            }
            return x;
        }

        public static Overload operator *(Overload x, Overload y)
        {
            var result = x.element.Intersect(y.element);            
            foreach (char s in result)
            {
                Console.WriteLine(s);
            }
            return x;
        }

        public static Overload operator >(Overload x, Overload y)
        {
            return x;
        }

        public static Overload operator <(Overload x, Overload y)
        {
            if (x.element.Length < y.element2.Length)
            {
                foreach (char i in y.element2)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Цю операцiю не можливо застосувати, тому що, або 2 множини рiвнi або перша множина не бiльша за другу!");
            }
            return y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Overload ov, ov1, ov2;
            ov1 = new Overload('a', 'b', 'z', 'c');
            Console.WriteLine("Видалення елемента з множини: ");
            ov = ov1 - 'z';
            Console.WriteLine();
            ov1 = new Overload('a', 'b', 'z', 'c');
            ov2 = new Overload('k', 'c', 'm', 'a');
            Console.WriteLine("Перетин множин: ");
            ov = ov1 * ov2;
            Console.WriteLine();
            ov1 = new Overload('a', 'b', 'z', 'c', 'q');
            ov2 = new Overload('k', 'c', 'm', 'a');
            Console.WriteLine("Порiвняння множин: ");
            ov = ov2 < ov1;
            Console.WriteLine();
        }
    }
}
