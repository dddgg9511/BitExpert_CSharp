using System;
using static System.Console;
using System.Collections;
namespace _0318
{
    class Class1
    {
        #region 콜렉션 초기화
        /*
         * <컬렉션 초기화>
         * 
         * int[] arr = {123,456,789}
         * 
         * ArrayList list = nwe ArrayList(arr);
         * ArrayList list = new ArrayList() {123, 456, 789};
         * 
         * Queue que = new Queue(arr);
         * 
         * Hashtable ht= new Hashtable() // 딕셔너리 이니셜라이저
         * {
         *      ["하나"] = 1,
         *      ["둘"]   = 2;
         *      ["셋"]   = 3;
         * };
         * 
         * Hashtable ht = new Hashtable() // 컬렉션 이니셜라이저
         * {
         *      {"하나",1},
         *      {"둘",2},
         *      {"셋",3}
         * }
         */
        #endregion
     
        static void Main(string[] args)
        {
            genricClass();
        }
        static void propertySet()
        {
            BirthdayInfo birth = new BirthdayInfo();
           
            WriteLine($"Name : {birth.Name}");
            WriteLine($"BirthDay : {birth.BirthDay}");
            WriteLine($"Age : {birth.Age}");
            WriteLine();
            birth.Name = "홍길동";
            birth.BirthDay = new DateTime(1995, 11, 18);
            WriteLine($"Name : {birth.Name}");
            WriteLine($"BirthDay : {birth.BirthDay}");
            WriteLine($"Age : {birth.Age}");
        }
        static void anonymousType()
        {
            var a = new { Name = "홍길동", Age = 20 };
            WriteLine($"Name:{a.Name}, Age:{a.Age}");

            var b = new { Subject = "수학", Score = new int[] { 90, 85, 80, 75 } };
            Write($"Subject: {b.Subject}, Score: ");
            foreach (var score in b.Score)
                Write($"{score} ");

            WriteLine();
        }
        static void interfaceProperty()
        {
            NameValue name =
                new NameValue() { Name = "이름", Value = "홍길동" };
            NameValue height =
                new NameValue() { Name = "키", Value = "170cm" };
            NameValue weight =
                new NameValue() { Name = "키", Value = "80kg" };
            WriteLine($"{name.Name}, {name.Value}");
            WriteLine($"{height.Name}, {height.Value}");
            WriteLine($"{weight.Name}, {weight.Value}");
        }
        static void abstractProperty()
        {
            MyProduct product1 = new MyProduct()
            {
                ProductDate = new DateTime(2018, 09, 09)
            };
            WriteLine("Product: {0}, Product Date{1}", product1.SerialID, product1.ProductDate);

            MyProduct product2 = new MyProduct()
            {
                ProductDate = new DateTime(2018, 03, 03)
            };
            WriteLine("Product: {0}, Product Date{1}", product1.SerialID, product2.ProductDate);
        }

        static void arraySet()
        {
            string[] array1 = new string[3] {"C++", "C#", "Java" };
            foreach (string subject in array1)
                Console.WriteLine($"{subject}");
            Console.WriteLine();

            string[] array2 = new string[] { "C++", "C#", "Java" };
            foreach (string subject in array2)
                WriteLine($"{subject}");
            WriteLine();

            string[] array3 = { "C++", "C#", "Java" };
            foreach (string subject in array3)
                Console.WriteLine($"{subject}");
        }
        static void arrayType()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            WriteLine($"Type of array : {array.GetType()}");
            WriteLine($"Base type of array : {array.GetType().BaseType}");
        }
        private static bool CheckPassed(int score)
        {
            if (score >= 60)
                return true;
            else
                return false;
        }
        static void usefulArray()
        {
            int[] scores = new int[] { 90, 75, 80, 94, 50 };
            foreach (int score in scores)
                Write($"{score} ");
            WriteLine();

            Array.Sort(scores);
            foreach (int score in scores)
                Write($"{score} ");
            WriteLine();

            WriteLine($"Number of dimensions : {scores.Rank}");

            WriteLine("Binary search : 80 is at {0}", Array.BinarySearch<int>(scores, 80));
            WriteLine("Linear Search : 94 is at {0}", Array.IndexOf(scores, 94));

            WriteLine("Everyone passed ? : {0}", Array.TrueForAll<int>(scores, CheckPassed));

            WriteLine($"Old length of scores : {scores.GetLength(0)}");

            Array.Resize<int>(ref scores, 10);
            WriteLine($"New length of scores : {scores.Length}");

            foreach (int score in scores)
                Write($"{score} ");
            WriteLine();

            Array.Clear(scores, 3, 7);
            foreach (int score in scores)
                Write($"{score} ");
            WriteLine();
        }
        static void twoDimensionArray()
        {
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Write($"[{i}, {j}] : {arr[i, j]} ");
                WriteLine();
            }
            WriteLine();

            int[,] arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            for(int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                    Write($"[{i}, {j}] : {arr2[i, j]} ");
                WriteLine();
            }
            WriteLine();
            int[,] arr3= { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < arr3.GetLength(0); i++)
            {
                for (int j = 0; j < arr3.GetLength(1); j++)
                    Write($"[{i}, {j}] : {arr3[i, j]} ");
                WriteLine();
            }
        }
        static void strangeArray()
        {
            int[][] jagged = new int[3][];
            jagged[0] = new int[5] { 1, 2, 3, 4, 5 };
            jagged[1] = new int[] { 10, 20, 30 }; 
            jagged[2] = new int[] { 100, 200 };

            foreach(int[] arr in jagged)
            {
                Write($"Length : {arr.Length}, ");
                foreach (int e in arr)
                    Write($"{e} ");
                WriteLine();
            }
            WriteLine();

            int[][] jagged2 = new int[2][]
            {
                new int[]{100,200},
                new int[4]{6,7,8,9}
            };
            foreach(int[] arr in jagged2)
            {
                Write($"Length : {arr.Length}, ");
                foreach (int e in arr)
                    Write($"{e} ");
                WriteLine();
            }
        }
        static void ArrayListSet()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 5; i++)
                list.Add(i);
            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();
            list.RemoveAt(2);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.Insert(2, 2);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.Add("abc");
            list.Add("def");

            for (int i = 0; i < list.Count; i++)
                Write($"{list[i]} ");
            WriteLine();
        }
        static void queueSet()
        {
            Queue que = new Queue();
            que.Enqueue(1);
            que.Enqueue(2);
            que.Enqueue(3);
            que.Enqueue(4);
            que.Enqueue(5);

            while (que.Count > 0)
                WriteLine(que.Dequeue());
        }
        static void hashTableSet()
        {
            Hashtable hashtable = new Hashtable();

            hashtable["하나"] = "one";
            hashtable["둘"] = "two";
            hashtable["셋"] = "three";
            hashtable["넷"] = "four";
            hashtable["다섯"] = "five";

            WriteLine(hashtable["하나"]);
            WriteLine(hashtable["둘"]);
            WriteLine(hashtable["셋"]);
            WriteLine(hashtable["넷"]);
            WriteLine(hashtable["다섯"]);
        }
        static void indexer()
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
                list[i] = i;
            for (int i = 0; i < list.Length; i++)
                WriteLine(list[i]);
        }        
        static void enumeratorSet()
        {
            var obj = new MyEnumerator();
            foreach (int i in obj)
                WriteLine(i);
            
        }
        static void requireEnum()
        {
            MyEnumeratorList list= new MyEnumeratorList();
            for (int i = 0; i < 5; i++)
                list[i] = i;
            foreach (int e in list)
                WriteLine(e);
        }
        static void genericMethod()
        {
            int[] source = { 1, 2, 3, 4, 5 };
            int[] target = new int[source.Length];

            CopyArray<int>(source, target);

            foreach (int i in target)
                WriteLine(i);

            string[] source2 = { "C++", "C#", "Java" };
            string[] target2 = new string[source2.Length];
            CopyArray<string>(source2, target2);

            foreach (string s in target2)
                WriteLine(s);
        }
        static void CopyArray<T>(T[] source,T[] target)
        {
            for (int i = 0; i < source.Length; i++)
                target[i] = source[i];
        }
        static void genricClass()
        {
            MyGenericList<string> str_list = new MyGenericList<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            for (int i = 0; i < str_list.Length; i++)
                WriteLine(str_list[i]);
            WriteLine();
            MyGenericList<int> int_list = new MyGenericList<int>();
            for (int i = 0; i < 5; i++)
                int_list[i] = i;
            for (int i = 0; i < int_list.Length; i++)
                WriteLine(int_list[i]);
        }
    }
    //================================================
    class BirthdayInfo
    {
        #region 프로퍼티
        //private string name;
        //private DateTime birthDay;
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}
        //public DateTime BirthDay
        //{
        //    get
        //    {
        //        return birthDay;
        //    }
        //    set
        //    {
        //        birthDay = value;
        //    }
        //}
        //public int Age
        //{
        //    get
        //    {
        //        return new DateTime(DateTime.Now.Subtract(birthDay).Ticks).Year;
        //    }
        //}
        #endregion
        #region 자동 구현 프로퍼티 Auto Implemented Property
        //Default Property
        public string Name { get; set; } = "Anonymous";
        public DateTime BirthDay { get; set; } = new DateTime(1, 1, 1);
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(BirthDay).Ticks).Year;
            }
        }
        #endregion
    }
    interface INameValue
    {
        string Name { get;set; }
        string Value{ get;set; }
    }
    class NameValue : INameValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    abstract class Prodect
    {
        private static int serial = 0;
        public string SerialID
        {
            get { return String.Format("{0:d5}", serial++); }
        }
        abstract public DateTime ProductDate
        {
            get;set;
        }
    }
    class MyProduct : Prodect
    {
        public override DateTime ProductDate { get ; set ; }
        
    }
    class MyList
    {
        private int[] array;
        public MyList()
        {
            array = new int[3];
        }
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value;
            }
        }
        public int Length
        {
            get { return array.Length; }
        }
    }
    class MyEnumerator
    {
        private int[] numbers = { 1, 2, 3, 4 };

        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield return numbers[3];
        }
    }
    class MyEnumeratorList:IEnumerable,IEnumerator
    {
        //IEnumerable   => GetEnumerator() 구현
        //IEnumerator   => 
        //boolean MoveNext()
        //void Reset()
        //Object Current{get;}
        //구현
        private int[] array;
        private int position = -1;
        public MyEnumeratorList()
        {
            array = new int[3];
        }
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value;
            }
        }

        public object Current
        {
            get { return array[position]; }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return array[i];
        }

        public bool MoveNext()
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }
            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class MyGenericList<T>
    {
        private T[] array;
        public MyGenericList()
        {
            array = new T[3];
        }
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);
                    WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value;
            }
        }
        public int Length
        {
            get { return array.Length; }
        }
    }
}
