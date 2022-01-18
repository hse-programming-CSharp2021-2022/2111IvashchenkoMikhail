using System;

namespace Seminar_13._01
{
    delegate int MyDel(ref int a);
    class Program
    {
        public static int M1(ref int a)
        {
            Console.WriteLine(a);
            a++;
            return a;
        }
        public int M2(ref int a)
        {
            Console.WriteLine(a);
            a++;
            return a;
        }
        static void Main(string[] args)
        {
            int a = 1;
            MyDel myDel1 = new MyDel(M1);
            Console.WriteLine((myDel1(ref a)));
            Console.WriteLine(myDel1.Method);
            Console.WriteLine(myDel1.Target);
            a = 1;
            MyDel myDel2 = (new Program()).M2;
            Console.WriteLine(myDel2.Invoke(ref a));
            Console.WriteLine(myDel2.Method);
            Console.WriteLine(myDel2.Target);
            a = 1;
            MyDel myDel3 = delegate (ref int a)
            {
                Console.WriteLine(a);
                a++;
                return a;
            };
            Console.WriteLine((myDel3(ref a)));
            Console.WriteLine(myDel3.Method);
            Console.WriteLine(myDel3.Target);
            a = 1;
            MyDel myDel4 = (ref int a) =>
            {
                Console.WriteLine(a);
                a++;
                return a;
            };
            Console.WriteLine(myDel4(ref a));
            Console.WriteLine(myDel4.Method);
            Console.WriteLine(myDel4.Target);
            a = 1;
            MyDel myDel5 = myDel3 + myDel1 + myDel2;
            Console.WriteLine(myDel5.Method);
            Console.WriteLine(myDel5.Target);
            //myDel5 += myDel3;
            Console.WriteLine(myDel5(ref a));
            //myDel5 -= myDel3;
            //myDel5();
            //Console.WriteLine();
            //myDel5 -= myDel3;
            //myDel5 -= myDel1;
            //myDel5 -= (new Program()).M2;
            //myDel5?.Invoke();
            MyDel myDel6 = (MyDel)Delegate.Combine(myDel1, myDel2); // +
            a = 1;
            Console.WriteLine();
            Console.WriteLine(myDel6(ref a));
            myDel6 = (MyDel)Delegate.Remove(myDel6, myDel1); // -
            a = 1;
            Console.WriteLine();
            Console.WriteLine(myDel6(ref a));
        }
    }
}