﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace _200320
{
    class Program
    {
        static void Main(string[] args)
        {
            groupbyLinQ();
        }
        #region Delegate
        #region Anonymous Method
        delegate int Calculate(int a, int b);
        static void anonymousMethod()
        {
            Calculate calc;
            calc = delegate (int a, int b)
              {
                  return a + b;
              };
        }
        #endregion
        #region Anonumous Compare
        delegate int Compare<T>(T a, T b);
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }
        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            //return b.CompareTo(a);
            return a.CompareTo(b) * -1;
        }
        static void BubbleSort<T>(T[] dataSet, Compare<T> compare)
        {
            int i = 0;
            int j = 0;
            T temp;
            for (i = 0; i < dataSet.Length; i++)
            {
                for (j = 0; j < dataSet.Length - (i + 1); j++)
                {
                    if (compare(dataSet[j], dataSet[j + 1]) > 0)
                    {
                        temp = dataSet[j + 1];
                        dataSet[j + 1] = dataSet[j];
                        dataSet[j] = temp;
                    }
                }
            }
        }
        
        static void delegateEx()
        {
            
            int[] array = { 3, 7, 4, 2, 9 };
            WriteLine("Ascending Sort!");
            Compare<int> AscendComp;
            BubbleSort<int>(array, delegate (int a, int b)
             {
                 if (a < b)
                     return 1;
                 else if (a == b) 
                     return 0;
                 else
                     return -1;
             }
             );
            
            for (int i = 0; i < array.Length; i++)
                Write($"{array[i]} ");
            WriteLine();

            WriteLine("Desending Sort!");
            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };
            Compare<string> DescendComp;
            DescendComp = delegate (string a, string b)
              {
                  return b.CompareTo(a);
              };
            BubbleSort(array2,DescendComp);
            for (int i = 0; i < array2.Length; i++)
            {
                Write($"{array2[i]} ");
            }
            WriteLine();
        }

        #endregion
        #region Event
        delegate void EventHandler(string message);
        class MyNotifier
        {
            public event EventHandler DoAlarm;
            public void Get369(int num)
            {
                string s = num.ToString();
                if (s.Contains('3') || s.Contains('6') || s.Contains('9'))
                {
                    DoAlarm(String.Format("{0}: 짝!", num));
                }
            }
        }
        static public void MyHandler(string message)
        {
            WriteLine(message);
        }
        static void eventSet()
        {
            MyNotifier notifier = new MyNotifier();
            notifier.DoAlarm += new EventHandler(MyHandler);

            for (int i = 0; i < 300; i++)
                notifier.Get369(i);
        }
        #endregion
        #region lambdaExpression
        delegate int Calculator(int a, int b);
        static void lamdaExpression()
        {
            Calculator cal = (a, b) => a + b;
            WriteLine($"{3}+{4} : {cal(3, 4)}");
        }
        delegate string Concatenate(string[] args);
        static void lamdaConcat()
        {
            string[] strArr = { "Microsoft ", "C# ", "Language" };
            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string s in arr)
                    result += s;
                return result;
            };
            WriteLine(concat(strArr));
        }
        #endregion
        #region Delegate Library
        static void funcDelegate()
        {
            Func<int> func1 = () => 10;
            WriteLine($"func1() : {func1()}");

            Func<int, int> func2 = (x) => x * 2;
            WriteLine($"func2(4) : {func2(4)}");

            Func<double, double, double> func3 = (x, y) => x / y;
            WriteLine($"func3(23,6) : {func3(23,6)}");
        }
        static void actionDelegate()
        {
            Action act1 = () => WriteLine("Action");
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x;
            act2(3);
            WriteLine($"result : {result}");

            Action<double, double> act3 = (x, y) =>
             {
                 double d = x / y;
                 WriteLine($"Action<T1,T1>({x},{y}) : {d}");
             };
            act3(10.0, 4.0);
        }
        static void predicateDelegate()
        {
            Predicate<int> Pre = (a) => a > 0 ? true : false;
            WriteLine(Pre(-10));
        }
        #endregion
        #endregion
        #region Expression Tree
        static void expressionTree()
        {
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);
            Expression leftExp = Expression.Multiply(const1,const2);

            Expression param1 = Expression.Parameter(typeof(int));
            Expression param2 = Expression.Parameter(typeof(int));
            Expression rightExp = Expression.Subtract(param1, param2);

            Expression exp = Expression.Add(leftExp, rightExp);

            Expression<Func<int, int, int>> expression =
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(
                    exp, new ParameterExpression[]
                    {
                        (ParameterExpression)param1,
                        (ParameterExpression)param2
                    }
                 );
            Func<int, int, int> func = expression.Compile();
            WriteLine($"1 * 2 + ({7}-{8}) = {func(7,8)}");
        }
        static void lambdaTree()
        {
            Expression<Func<int, int, int>> expression = (a, b) => 1 * 2 + (a - b);
            Func<int, int, int> func = expression.Compile();

            WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");
        }
        #endregion
        #region Expression-Bodied-Member
        class FriendList
        {
            private List<String> list = new List<String>();
            public void Add(string name) => list.Add(name);
            public void Remove(string name) => list.Remove(name);
            public void PrintAll()
            {
                foreach (var s in list)
                    WriteLine(s);
            }
            public FriendList() => WriteLine("FriendList()");
            ~FriendList() => WriteLine("~FriendList");

            //public int Capacity => list.Capacity; //읽기 전용
            public int Capacity
            {
                get => list.Capacity;
                set => list.Capacity = value;
            }
            //public string this[int index] => list[index];
            public string this[int index]
            {
                get => list[index];
                set => list[index] = value;
            }
        }
        static void expression_Bodied_Member()
        {
            FriendList obj = new FriendList();
            obj.Add("홍길동");
            obj.Add("이순신");
            obj.Add("유관순");
            obj.Remove("홍길동");
            obj.PrintAll();

            WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            WriteLine($"{obj.Capacity}");

            WriteLine($"{obj[0]}");
            obj[0] = "박문수";
            obj.PrintAll();
        }

        #endregion
        #region LINQ
        static void linqSet()
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };
            var result = from n in numbers
                         where n % 2 == 0
                         orderby n
                         select n;
            foreach (int n in result)
                WriteLine($"짝수 : {n}");
        }
         
        public class Profile
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }
        static void linqEx()
        {
            Profile[] arrProfile = {new Profile() { Name="김철수",Height=186}
            ,new Profile(){Name="바끄네 ",Height=158}
            ,new Profile(){Name="채순시 ",Height=172}
            ,new Profile(){Name="김기출 ",Height=178}
            ,new Profile(){Name="유병우 ",Height=171}
            };

            var profiles = from profile in arrProfile
                           where profile.Height < 175
                           orderby profile.Height
                           select new
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height * 0.39
                           };
            foreach (var profile in profiles)
                WriteLine($"{profile.Name},{profile.InchHeight}");
        }

        public class Class
        {
            public string Name { get; set; }
            public int[] Score { get; set; }
        }
        static void linqClass()
        {
            Class[] arrClass =
            {
                new Class() { Name = "장미반", Score = new int[] { 99, 80, 70, 24 } },
                new Class() { Name = "백합반", Score = new int[] { 60, 45, 87, 72 } },
                new Class() { Name = "개나리반", Score = new int[] { 92, 30, 85, 94 } },
                new Class() { Name = "갈대반", Score = new int[] { 90, 88, 0, 17 } },
            };

            var classes = from c in arrClass
                          from s in c.Score
                          where s < 60
                          orderby s
                          select new { c.Name, Lowest = s };
            foreach (var c in classes)
                WriteLine($"낙제 : {c.Name} ({c.Lowest})");
        }
        class Person
        {
            public string Sex { get; set; }
            public string Name { get; set; }
        }
        static void groupbyLinQ()
        {
            Person[] peopleArr =
            {
                new Person(){Sex="여자",Name="성나정"},
                new Person(){Sex="남자",Name="쓰레기"},
                new Person(){Sex="여자",Name="조윤지"},
                new Person(){Sex="남자",Name="삼천포"}
            };

            var group = from person in peopleArr
                        group person by person.Sex == "남자" into data
                        select new { SexCheck = data.Key, People = data };

            foreach(var element in group)
            {
                if (element.SexCheck)
                {
                    WriteLine("<남자리스트>");
                    foreach (var person in element.People)
                        WriteLine($"이름 : {person.Name}");
                }
                else
                {
                    WriteLine("<여자리스트>");
                    foreach (var person in element.People)
                        WriteLine($"이름 : {person.Name}");
                }
            }
        }


        #endregion

    }
}
 