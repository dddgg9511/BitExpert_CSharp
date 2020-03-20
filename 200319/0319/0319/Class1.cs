using System;
using System.Collections;           //IEnumerable,IEnumerator
using System.Collections.Generic;   //IEnumberable<T>,IEnumerator<T>
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace _0319
{
    class Class1
    {
        #region 형식 매개변수 제한
        /*
         * 1. where T : struct
         *  =>T는 값형식
         *  static void CopyArray<T>([] source, T[] targer) where T : struct
         *  CopyArrary<int>(source,target)
         *  
         * 2.where T : class
         *  =>T는 참조 형식
         *  static void CopyArray<T>(T[] source, T[] target) where T : class
         *  copyArray<string>(source, target;
         *  
         * 3.where T : new()
         *  =>T는 매개변수가 없는 생성자가 있어야함
         *  public static T createInstance<T>() where T : new(){
         *      return new T();
         *  }
         * 
         * 4.where T : 베이스 클래스 이름
         *  =>T는 해당 베이스 클래스를 상속한 클래스여야 함
         *  static void CopyArray<T>(T[] source, T[] target) where T : MyList
         *  class childList : MyList
         *  CopyArray<ChildList>(source, target);
         *  
         * 5.where T : 인터페이스 이름
         *  =>T는 해당 인터페이스를 구현해야 함
         *  
         *  static void CopyArray<T>(T[] source, T[] target) where T : ILogger
         *  class ConsoleLogeer : ILogger
         *  CopyArray<ConsoleLogger>(ource, target);
         *  
         * 6. where T : U
         *  =>T는 U를 상속한 클래스여야 함
         *  
         *  class BaseArray<U>
         *  {
         *      public U[] Array{
         *          get; set;
         *  }
         *      public BaseArray(int size)
         *      {
         *          Array = new U[size];
         *      }
         *      public void CopyArray<T>(T[] source) where T : U
         *      {
         *          source.CopyTo(Array, 0);
         *      }
         *  }
         */
        #endregion
        static void Main(string[] args)
        {
            eventHandler();
        }
        static void generic()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (int i in list)
                WriteLine($"{i} ");
            WriteLine();

            list.RemoveAt(2);

            foreach (int i in list)
                WriteLine($"{i} ");
            WriteLine();

            list.Insert(2, 2);

            foreach (int i in list)
                Write($"{i} ");
            WriteLine();

        }
        static void dictionarySet()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["국어"] = 90;
            dic["영어"] = 85;
            dic["수학"] = 95;
            dic["물리"] = 100;
            dic["화학"] = 95;
            foreach (KeyValuePair<string, int> item in dic)
                WriteLine($"{item.Key} : {item.Value}");
        }
        static void genericEnumerator()
        {
            MyEnumeratorList<int> list = new MyEnumeratorList<int>();
            for (int i = 0; i < 5; i++)
                list[i] = i;

            foreach (int e in list)
                WriteLine(e);
        }
        static void exceptionHandling()
        {
            int[] arr = { 1, 2, 3 };
            try
            {
                for (int i = 0; i < 5; i++)
                    WriteLine(arr[i]);
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine($"예외 발생 : {e.Message}");
            }
            WriteLine("종료");

        }
        static void generateException()
        {
            try
            {
                SimpleFunc(5);
                SimpleFunc(12);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        static void SimpleFunc(int arg)
        {
            if (arg <= 10)
                WriteLine($"arg : {arg}");
            else
                throw new Exception("인자값이 10보다 큽니다.");
        }
        static void newThrowException()
        {
            try
            {
                int? a = null;
                int b = a ?? throw new ArgumentNullException();
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
            try
            {
                int[] array = new[] { 1, 2, 3 };
                int index = 4;
                int value = array[index >= 0 && index < 3 ?
                    index : throw new IndexOutOfRangeException()];
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine(e);
            }
        }
        static void trySet()
        {
            try
            {

            Write("제수 입력 : ");
            string temp = ReadLine();
            int divisor = Convert.ToInt32(temp);

            Write("피제수 입력 : ");
            temp = ReadLine();
            int dividend = int.Parse(temp);

            WriteLine("{0}/{1} = {2}", divisor, dividend, Divide(divisor, dividend));
            }
            catch(FormatException e) 
            {
                WriteLine("에러 : " + e.Message);
            }
            catch(DivideByZeroException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            finally
            {

            }
        }
        static int Divide(int divisor, int dividend)
        {
            try
            {
                WriteLine("Divide() 시작");
                return divisor / dividend;
            }
            catch (DivideByZeroException e)
            {
                WriteLine("Divide() 예외 발생");
                throw e;
            }
            finally
            {
                WriteLine("Divide() 종료");
            }
        }
        static void customException()
        {
            try
            {
                WriteLine("0x{0:X8}", MergeARGB(255, 100, 100, 100));
                WriteLine("0x{0:X8}", MergeARGB(1, 165, 190, 125));
                WriteLine("0x{0:X8}", MergeARGB(0, 255, 255, 260));
            }
            catch(InvalidArgumentException e)
            {
                WriteLine(e.Message);
                WriteLine($"Argument: {e.Argument}, Range: {e.Range}");
            }
        }
        static uint MergeARGB(uint alpha,uint red,uint green,uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue };
            foreach(uint arg in args)
            {
                if (arg > 255)
                    throw new InvalidArgumentException() { Argument = arg, Range = "0~255" };
            }
            return (alpha << 24 & 0xFF00_00_00) | (red << 16 & 0x00FF0000) | (green << 8 & 0x0000FF00) | (blue & 0x000000FF);
        }
        static void exceptionFilter()
        {
            WriteLine("Enter number between 0~10: ");
            string input = ReadLine();
            try
            {
                int num = int.Parse(input);
                if (num < 0 || num > 10)
                    throw new FilterableException() { ErrorNo = num };
                else WriteLine($"Output : {num}");
            }
            catch(FilterableException e)when (e.ErrorNo < 0)
            {
                WriteLine("음수는 허용되지 않습니다.");
            }
            catch(FilterableException e) when (e.ErrorNo > 10)
            {
                WriteLine("10보다 큰 수는 허용되지 않습니다.");
            }
        }
        static void delegateSet()
        {
            Calculator cal = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(cal.Plus);
            WriteLine(Callback(3, 4));

            Callback = new MyDelegate(cal.Minus);
            WriteLine(Callback(8, 3));
        }
        #region 표준
        /*
        delegate int Compare(int a, int b);
        static int AscendCompare(int a,int b)
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }
        static int DescendCompare(int a,int b)
        {
            if (a < b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }
        static void BubbleSort(int[] dataSet,Compare compare)
        {
            int i = 0;
            int j = 0;
            int temp = 0;
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
            BubbleSort(array, new Compare(AscendCompare));
            for(int i=0;i<array.Length;i++)
                Write($"{array[i]} ");
            WriteLine();

            WriteLine("Desending Sort");
            BubbleSort(array, new Compare(DescendCompare));
            for (int i = 0; i < array.Length; i++)
                Write($"{array[i]} ");
            WriteLine();
        }
        */
        #endregion

        #region genericType
        delegate int Compare<T>(T a, T b);
        static int AscendCompare<T>(T a, T b) where T :IComparable<T>
        {
            return a.CompareTo(b);
        }
        static int DescendCompare<T>(T a, T b) where T :IComparable<T>
        {
            //return b.CompareTo(a);
            return a.CompareTo(b)*-1;
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
            BubbleSort(array, new Compare<int>(AscendCompare));
            for (int i = 0; i < array.Length; i++)
                Write($"{array[i]} ");
            WriteLine();

            WriteLine("Desending Sort!");
            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };
            BubbleSort(array2, new Compare<string>(DescendCompare));
            for (int i = 0; i < array2.Length; i++)
            {
                Write($"{array2[i]} ");
            }
            WriteLine();
        }

        #endregion

        #region DelegateChain
        delegate void OnlineShopping(string location);
        static void OrderGoods(string location)
        {
            WriteLine($"장바구니내 물건을 {location}으로 가져다 주세요!");
        }
        static void SpecialOrder(string location)
        {
            WriteLine($"{location}에 사람이 없으면 문앞에 두시고 문자주세요!");
        }
        static void delegateChain()
        {
            OnlineShopping shopper = new OnlineShopping(OrderGoods) + new OnlineShopping(SpecialOrder);
            shopper("우리집");
        }
        #endregion

        #region EventHandler
        delegate void Notify(string message);
        class Notifier
        {
            public Notify EnventOccured;
        }
        class EventListener
        {
            private string name;
            public EventListener(string name)
            {
                this.name = name;
            }
            public void SomethingHappend(string message)
            {
                WriteLine($"{name}.SomethingHappend : {message}");
            }
        }
        static void eventHandler()
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");

            notifier.EnventOccured += listener1.SomethingHappend;
            notifier.EnventOccured += listener2.SomethingHappend;
            notifier.EnventOccured += listener3.SomethingHappend;
            notifier.EnventOccured("You'be got mail.");
            WriteLine();

            notifier.EnventOccured -= listener2.SomethingHappend;
            notifier.EnventOccured("Download completed.");
            WriteLine();

            Notify notify1 = new Notify(listener1.SomethingHappend);
            Notify notify2 = new Notify(listener2.SomethingHappend);
            notifier.EnventOccured = (Notify)Delegate.Remove(notifier.EnventOccured, notify2);
            notifier.EnventOccured("Game Over");
        }
        #endregion
    }

    class MyEnumeratorList<T> : IEnumerable<T>, IEnumerator<T>
    {
        //IEnumerable   => GetEnumerator() 구현
        //IEnumerator   => 
        //boolean MoveNext()
        //void Reset()
        //Object Current{get;}
        //구현
        private T[] array;
        private int position = -1;
        public MyEnumeratorList()
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

        public object Current
        {
            get { return array[position]; }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return array[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return array[position];
            }
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
        public void Dispose()
        {

        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return array[i];
        }

    }
    class InvalidArgumentException: Exception
    {
        public InvalidArgumentException() { }
        public InvalidArgumentException(string message) : base(message){ }
        public object Argument
        {
            get;set;
        }
        public string Range
        {
            get;set;
        }
    }
    class FilterableException : Exception
    {
        public int ErrorNo { get; set; }
    }
    delegate int MyDelegate(int a, int b);
    class Calculator
    {
        public int Plus(int a,int b)
        {
            return a + b;
        }
        public int Minus(int a,int b)
        {
            return a - b;
        }
    }
}

