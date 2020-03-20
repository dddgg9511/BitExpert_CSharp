using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
using System.Collections;

namespace Constant
{
    class Constant
    {
        //static void Main(string[] args)
        //{
        //    localFunction();
        //}

        static void int_size()
        {
            const int MAX_INT = 2147483647;
            const int MIN_INT = -2147483648;

            Console.WriteLine(MAX_INT);
            Console.WriteLine(MIN_INT);
        }

        //  enum 열거형 이름 : 기반 자료형 {...}
        //  기반 자료형은 정수 계열만 사용가능
        //  기반 자료형 생략 시 default 값은 int
        //  값을 지정하지 않으면 0부터 차례로 할당

        //enum ColorCode : int { RED, BLUE, GREEN, ORANGE }
        //시험에 낼지도 모른다.
        enum ColorCode : int { RED = 10, BLUE, GREEN, ORANGE = 100 }
        static void enumType()
        {
            Console.WriteLine((int)ColorCode.RED);
            Console.WriteLine((int)ColorCode.BLUE);
            Console.WriteLine((int)ColorCode.GREEN);
            Console.WriteLine((int)ColorCode.ORANGE);
        }

        static void enumTypeEx()
        {
            ColorCode cCode = ColorCode.RED;

            Console.WriteLine(cCode == ColorCode.BLUE);
            Console.WriteLine(cCode == ColorCode.RED);
        }

        [Flags] //Attribute
        enum Border
        {
            None = 0,
            Top = 1,
            Right = 2,
            Bottom = 4,
            Left = 8,
        }

        static void flagEnum()
        {
            //OR 연산자로 다중 플래그 할당
            Border b = Border.Top | Border.Bottom;

            //&연산자로 플래그 체크
            if ((b & Border.Top) != 0)
            {
                //HasFlag 이용 플래그 체크

                if (b.HasFlag(Border.Bottom))
                {
                    //  "Top, Bottom" 출력
                    Console.WriteLine(b.ToString());
                }
            }
        }


        static void nullAbleType()
        {
            int? a = null;

            Console.WriteLine(a.HasValue);
            Console.WriteLine(a != null);

            a = 3;
            Console.WriteLine(a.HasValue);
            Console.WriteLine(a != null);
            Console.WriteLine(a.Value);
        }

        static void varType()
        {
            var a = 20;
            Console.WriteLine("Type:{0},Value: {1}", a.GetType(), a);

            var b = 3.141592;
            Console.WriteLine("Type:{0},Value: {1}", b.GetType(), b);

            var c = "Hello World";
            Console.WriteLine("Type:{0},Value: {1}", c.GetType(), c);

            var d = new int[] { 10, 20, 30 };
            Console.Write("Type: {0}, Value: ", d.GetType());
            foreach (var e in d)
                Console.Write("{0}", e);
            Console.WriteLine();
        }

        static void stringChange()
        {
            string str = "This is string search sample";
            WriteLine(str);
            WriteLine();

            Console.WriteLine("Index of 'search' : {0}", str.IndexOf("search"));
            Console.WriteLine("Index of  'h' : {0}", str.IndexOf('h'));

            Console.WriteLine("StartsWith 'This' : {0}", str.StartsWith("This"));
            Console.WriteLine("StartsWith 'string' : {0}", str.StartsWith("string"));

            Console.WriteLine("EndsWith 'This' : {0}", str.EndsWith("This"));
            Console.WriteLine("EndsWith 'sSample' : {0}", str.EndsWith("sample"));

            Console.WriteLine("Contains 'search' : {0}", str.Contains("search"));
            Console.WriteLine("Contains 'school : {0}", str.Contains("school"));

            Console.WriteLine("Replace 'sample' with 'example':{0}", str.Replace("sample", "example"));
        }

        static void stringSex()
        {
            WriteLine("ToLower() : {0}", "Hello World".ToLower());
            WriteLine("ToUpper() : {0}", "Hello World".ToUpper());

            WriteLine("Insert() : {0}", "Hello World".Insert(6, "Wonderful "));
            WriteLine("Remove() : {0}", "Hello Wonderful World".Remove(6, 10));

            WriteLine("Trim() : {0}", " I am Tom ".Trim());
            WriteLine("TrimStart() : {0}", " I am Tom ".TrimStart());
            WriteLine("TrimEnd() : {0}", " I am Tom ".TrimEnd());
        }

        static void stringSplit()
        {
            string str = "Welcome to the C# world!";

            WriteLine(str.Substring(15, 2));
            WriteLine(str.Substring(8));
            WriteLine();

            string str1 = "Wel#come#to#the#c##world!";
            string[] arr = str1.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
            WriteLine("Word count : {0}", arr.Length);

            foreach (string element in arr)
                WriteLine("{0}", element);
        }

        static void stringSort()
        {
            string fmt = "{0,-10}{1,-5}{2,20}";

            WriteLine(fmt, "Type", "Size", "Explain");
            WriteLine(fmt, "byte", "1", "byte 타입");
            WriteLine(fmt, "short", "2", "Short 타입");
            WriteLine(fmt, "int", "4", "int 타입");
            WriteLine(fmt, "long", "8", "long 타입");
        }

        static void numberSort()
        {
            WriteLine("10진수: {0:D}", 123);
            WriteLine("10진수: {0:D5}", 123);

            WriteLine("8진수: 0X{0:X}", 0XFF1234);
            WriteLine("8진수: 0X{0:X8}", 0XFF1234);

            WriteLine("숫자: {0:N}", 123456);
            WriteLine("숫자: {0:N0}", 123456);

            WriteLine("고정소수점: {0:F}", 123.456);
            WriteLine("고정소수점: {0:F5}", 123.456);

            WriteLine("공학: {0:E}", 123.456789);
            WriteLine("공학: {0:E5}", 123.456789);
        }

        static void dateTimeSet()
        {
            DateTime dt = DateTime.Now;

            WriteLine("12시간 형식: {0:yyyy-MM-dd tt hh:mm:ss(ddd)}", dt);
            WriteLine("24시간 형식: {0:yyyy-MM-dd tt HH:mm:ss(dddd)}", dt);

            CultureInfo ciKr = new CultureInfo("ko-KR");
            WriteLine();
            WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss(ddd)", ciKr));
            WriteLine(dt.ToString("yyyy-MM-dd tt HH:mm:ss(dddd)", ciKr));
            WriteLine(dt.ToString(ciKr));

            CultureInfo ciUs = new CultureInfo("en-US");
            WriteLine();
            WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss(ddd)", ciUs));
            WriteLine(dt.ToString("yyyy-MM-dd tt HH:mm:ss(dddd)", ciUs));
            WriteLine(dt.ToString(ciUs));
        }

        static void printSet()
        {
            string name = "홍길동";
            int age = 25;
            WriteLine($"{name,-10},{age:D3}");

            name = "김유신";
            age = 30;
            WriteLine($"{name,-10},{age,-10:D3}");

            name = "박문수";
            age = 15;
            WriteLine($"{name}, {(age > 20 ? "성인" : "미성년자")} ");
        }

        static void ArrayListset()
        {
            ArrayList a = null;
            a?.Add("C++");  //if(a!=null) a.add(c++)
            a?.Add("C#");
            WriteLine($"Count : {a?.Count}");
            WriteLine($"{ a?[0]}");
            WriteLine($"{ a?[1]}");

            a = new ArrayList();
            a?.Add("C++");
            a?.Add("C#");
            WriteLine($"Count : {a?.Count}");
            WriteLine($"{ a?[0]}");
            WriteLine($"{ a?[1]}");
        }

        static void bitShift()
        {
            int a = 1;
            WriteLine("a        :{0:D5} (0x{0:X8})", a);
            WriteLine("a << 1   :{0:D5} (0x{0:X8})", a << 1);
            WriteLine();

            int b = 255;
            WriteLine("b        :{0:D5} (0x{0:X8})", b);
            WriteLine("b >> 1   :{0:D5} (0x{0:X8})", b >> 1);
            WriteLine();
            int c = -255;
            WriteLine("c        :{0:D5} (0x{0:X8})", c);
            WriteLine("c >> 1   :{0:D5} (0x{0:X8})", c >> 1);
            WriteLine();

        }

        static void bitOperator()
        {
            int a = 9;
            int b = 10;

            WriteLine($"{a} & {b} : {a & b}");
            WriteLine($"{a} | {b} : {a | b}");
            WriteLine($"{a} ^ {b} : {a ^ b}");

            int c = 255;
            WriteLine("~{0}(0x{0:x8}) : {1}(0x{1:X8})", c, ~c);
        }

        //?중의 하나는 시험에 낼거 같다
        static void questionMark()
        {
            int? num = null;
            WriteLine($"{num ?? 0}");

            num = 10;
            WriteLine($"{num ?? 0}");

            string str = null;
            WriteLine($"{str ?? "Default"}");

            str = "I study C#";
            WriteLine($"{str ?? "Default"}");
        }

        static void typeSwitch()
        {
            object obj = null;

            string str = ReadLine();
            if (int.TryParse(str, out int int_num))
                obj = int_num;
            else if (float.TryParse(str, out float float_num))
                obj = float_num;
            else
                obj = str;

            switch (obj)
            {
                case int i:
                    Console.WriteLine($"{obj}는 Int 형식입니다.");
                    break;
                case float f:
                    Console.WriteLine($"{obj}는 Float 형식입니다.");
                    break;
                default:
                    Console.WriteLine($"{obj}는 object 형식입니다.");
                    break;
            }
        }

        static void foreachset()
        {
            int[] arr = new int[] { 0, 1, 2, 3, 4 };

            foreach (int i in arr)
                WriteLine(i);
        }

        static void classControll()
        {
            int result = Calculator.Plus(2, 5);
            WriteLine(result);

            result = Calculator.Minus(10, 3);
            WriteLine(result);
        }


        #region 시험 문제 후보
        public void swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }
        public void reference()
        {
            int x = 3;
            int y = 5;

            WriteLine($"x:{x}, y:{y}");
            swap(ref x, ref y);
            WriteLine($"x:{x}, y:{y}");
        }
        #endregion

        public static void refReturn()
        {
            Product carrot = new Product();

            ref int ref_price = ref carrot.GetPrice();
            int normal_price = carrot.GetPrice();

            carrot.printPrice();
            WriteLine(ref_price);
            WriteLine(normal_price);

            ref_price = 200;
            carrot.printPrice();
            WriteLine(ref_price);
            WriteLine(normal_price);
        }
        static void Divide(int a,int b,out int quotient,out int remainder)
        {
            quotient = a / b;                                                   
            remainder = a % b;
        }
        static void refOut()
        {
            int a = 20, b = 3, c;
            Divide(a, b, out c, out int d);
            WriteLine($"a:{a},b:{b},a/b:{c},a%d:{d}");

        }
        static int Sum(params int[] args)
        {
            int sum = 0;
            for(int i = 0; i < args.Length; i++)
            {
                if (i > 0)
                    Write(", ");
                Write(args[i]);
                sum += args[i];
            }
            WriteLine();
            return sum;
        }

        static void paramsSet()
        {
            int sum = Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            WriteLine($"Sum: {sum}");
        }

        static void PrintProfile(string name,string phone="")
        {
            WriteLine($"Name:{name},Phone: {phone}");
        }

        static void namingParam()
        {
            PrintProfile(name: "이순신", phone: "010-1111-2222");
            PrintProfile(phone: "010-1111-4444", name: "연개소문");
            PrintProfile("박찬호");
            PrintProfile("홍길동",phone:"010-5555-2222");
        }

        static string ToLowerString(string str)
        {
            var arr = str.ToCharArray();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }
            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90)
                    return arr[i];
                else
                    return (char)(arr[i]+32);
            }
            return new string(arr);
        }

        static void localFunction()
        {
            WriteLine(ToLowerString("Hello"));
            WriteLine(ToLowerString("World"));
            WriteLine(ToLowerString("C# Programming"));
        }
    }

        class Calculator
        {
            public static int Plus(int a, int b)
            {
                return a + b;
            }

            public static int Minus(int a, int b)
            {
                return a - b;
            }
        }

        class Product
        {
            private int Price = 100;
            public ref int GetPrice()
            {
                return ref Price;
            }

            public void printPrice()
            {
                WriteLine($"Price : {Price}");
            }
        }
    }


