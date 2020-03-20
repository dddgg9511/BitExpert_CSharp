using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Constant
{

    class mainClass
    {
        static void Main(string[] args)
        {
            thisCreator();
        }
        static void thisCreator()
        {
            ThisConstructor a = new ThisConstructor();
            a.PrintFields();
            WriteLine();

            ThisConstructor b = new ThisConstructor(10);
            b.PrintFields();
            WriteLine();

            ThisConstructor c = new ThisConstructor(10, 20);
            c.PrintFields();
        }
        static void thisOp()
        {
            Employyee worker = new Employyee();
            worker.SetName("홍길동");
            worker.SetPostion("Guard");
            WriteLine($"{worker.GetName()} {worker.GetPostion()}");
        }
        static void carSet()
        {
            Car myCar = new Car();
            Car yourCar = new Car("SUV", "블랙");

            myCar.ShowStatus();
            yourCar.ShowStatus();
        }
        static void copy()
        {
            WriteLine("Shallow Copy");
            ShallowDeepCopy source = new ShallowDeepCopy();
            source.Field1 = 10;
            source.Field2 = 20;

            ShallowDeepCopy target = source;
            target.Field2 = 30;
            WriteLine($"{source.Field1} { source.Field2}");
            WriteLine($"{target.Field1} { target.Field2}");

            WriteLine("Deep Copy");
            ShallowDeepCopy deepSource = new ShallowDeepCopy();
            deepSource.Field1 = 10;
            deepSource.Field2 = 20;
            ShallowDeepCopy deepTarget = deepSource.DeepCopy();
            deepTarget.Field2 = 30;

            WriteLine($"{deepSource.Field1} { deepSource.Field2}");
            WriteLine($"{deepTarget.Field1} { deepTarget.Field2}");
        }
    }
    class Car
    {
        private string model;
        private string color;

        public Car()
        {
            model = "세단";
            color = "흰색";
        }

        public Car(string m,string c)
        {
            model = m;
            color = c;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Model : {model},    Color : {color}");
        }

        ~Car()
        {
            Console.WriteLine("소멸자 실행");
        }
    }


    class ShallowDeepCopy
    {
        public int Field1;
        public int Field2;

        public ShallowDeepCopy DeepCopy()
        {
            ShallowDeepCopy newClass = new ShallowDeepCopy();
            newClass.Field1 = Field1;
            newClass.Field2 = Field2;

            return newClass;
        }
    }

    class Employyee
    {
        private string name;
        private string position;

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
        public void SetPostion(string position)
        {
            this.position = position;
        }
        public string GetPostion()
        {
            return this.position;
        }
    }

    class ThisConstructor
    {
        private int a, b, c;

        public ThisConstructor()
        {
            a = 1111;
            WriteLine("ThisConstructor()");
        }

        public ThisConstructor(int b) : this()
        {
            this.b = b;
            WriteLine("ThisConstructor(int)");
        }
        public ThisConstructor(int b,int c) : this(b)
        {
            this.c = c;
            WriteLine("ThisConstructor(int,int)");
        }

        public void PrintFields()
        {
            WriteLine($"a : {a} b : {b} c : {c}");
        }
    }
}
