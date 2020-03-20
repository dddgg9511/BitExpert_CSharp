using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Helloworld
    {
        static void Main(string[] args)                 //객체 생성 없이 실행시키기 위해 static으로 정의
        {
            parsing();
        }

        static void hello()
        {
            Console.WriteLine("HelloWorld!!");
        }

        static void integer()
        {
            sbyte a = -10;
            byte b = 40;

            WriteLine($"a={a},b={b}");

            short c = -30000;
            ushort d = 60000;

            WriteLine($"c={c},d={d}");

            int e = -10_000_000;
            uint f = 300_000_000;

            Console.WriteLine($"e={e},f={f}");

            long g = 500_000_000_000;
            ulong h = 2_000_000_000_000_000_000;

            Console.WriteLine($"g={g},h={h}");
        }

        static void floats()
        {
            byte a = 240;

            WriteLine($"a={a}");

            byte b = 0b1111_0000;

            WriteLine($"b={b}");

            byte c = 0xF0;

            WriteLine($"c={c}");

            uint d = 0x1234_abcd;
            WriteLine($"d={d}");
        }

        static void decimals()
        {
            float a = 3.1415_9265_3589_7932_3846_2643_3832_79f;
            double b= 3.1415_9265_3589_7932_3846_2643_3832_79;
            decimal c= 3.1415_9265_3589_7932_3846_2643_3832_79m;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }

        static void character()
        {
            char a = '프';
            char b = '로';
            char c = '그';
            char d = '래';
            char e = '밍';

            WriteLine(a);
            WriteLine(b);
            WriteLine(c);
            WriteLine(d);
            WriteLine(e);
        }

        static void stringType()
        {
            string a = "독도는 우리땅";
            string b ="대마도도 우리땅";

            WriteLine(a);
            WriteLine(b);
        }

        static void boolType()
        {
            bool a = true;
            bool b = false;

            WriteLine(a);
            WriteLine(b);
        }

        static void objectType()
        {
            object a = 123;
            object b = 3.14159m;
            object c = true;
            object d = "문자열";

            WriteLine(a);
            WriteLine(b);
            WriteLine(c);
            WriteLine(d);
        }

        static void boxing()
        {
            int a = 123;
            object b = (object)a;   //boxing
            int c = (int)b;         //unboxing

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            double x = 3.141592;
            object y = x;           //묵시적 object 타입으로 변환
            double z = (double)y;   //Unboxing

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
        }

        static void casting()
        {
            float a = 67.6875f;
            Console.WriteLine("a,{0}", a);

            double b = (double)a;
            Console.WriteLine("b,{0}", b);

            Console.WriteLine("69.6875==b : {0}", 69.6875 == b);

            float x = 0.1f;
            Console.WriteLine("x : {0}",x);

            double y = (double)x;
            Console.WriteLine("y : {0}", y);


            Console.WriteLine("0.1==y : {0}", 0.1 == y);
        }

        static void parsing()
        {
            int a = 123;
            string b = a.ToString();
            Console.WriteLine(b);

            float c = 3.14f;
            string d = c.ToString();
            Console.WriteLine(d);

            string e = "123456";
            int f = int.Parse(e);
            Console.WriteLine(f);

            string g = "1.23456";
            float h = float.Parse(g);
            Console.WriteLine(h);
        }
    }
}
