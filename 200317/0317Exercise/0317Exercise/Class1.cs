using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace _0317Exercise
{
    //시험 문제 내기 딱 좋다~
    //<접근 제한자>
    //1. public: 클래스의 내부/외부 모든 곳에서 접근 가능
    //2. protected : 클래스의 외부에서 접근 불가능, 자식 클래스에서는 접근 가능
    //3. private :클래스의 내부에서만 접근 가능
    //4. internal : 같은 어셈블리에 있는 코드에서만 public 으로 접근 가능
    //5. protected internal : 같은 어셈블리에 잇는 코드에서 protected로 접근 가능

    //<sealed>
    //-클래스의 상속을 불가능하게 만듬
    //sealed class AAA{}
    //함수에 붙이면 자식클래스에서 override 불가능

    //<구조체>
    //구조체는 값형식( 클래그슨 참조 형식
    //선언만으로도 생성가능
    //Deep Copy
    //매개변수 없는 생성자 선언 불가능
    //상속 불가능

    //<튜플>
    //1,Unnamed Tuple
    //var a= (123, 456);
    //writeLine($"{a.item1}, {a.item2}");

    //2.Named Tuple
    //var a=(Name : "홍길동", Age: 20);
    //WriteLine($"{a.Name}, {a.Age}");

    //3.튜플 분해
    //var a=(Name: "홍길동", Age: 20);
    //var (name, age) = a;
    //WriteLine($"{name}, {age}");

    //4.필드 무시
    //var a=(Name: "홍길동", Age: 20);
    //var (name,_) = a;
    //WriteLine($"{name}");

    //5. System.Value Type 패키지 설치
    //[도구] -> [Nuget 패키지 관리자] -> [패키지 관리자 콘솔]
    //PM-> Install-Package "System.ValueTuple"

    //<인터페이스>
    //메소드, 이벤트, 인덱서, 프로퍼티만 가짐
    //접근제한자를 사용하지 않으며 모든 것이 public 으로 선언됨

    class Class1
    {
        static void Main(string[] args)
        {
            interfaceInherit();
        }   
        public static void inherit()
        {
            Parent parent = new Parent("홍길동아버지");
            parent.ParentMethod();
            WriteLine();

            Child child = new Child("홍길동");
            child.ParentMethod();
            child.ChildMethod();
            WriteLine();

            Child child2 = new Child();
            child2.ParentMethod();
            child2.ChildMethod();
            WriteLine();
        }

        public static void casting()
        {
            Mammal mammal = new Mammal();
            mammal.Nurse();
            WriteLine();

            mammal = new Dog();
            mammal.Nurse();
            WriteLine();

            if(mammal is Dog)
            {
                Dog dog = (Dog)mammal;
                dog.Nurse();
                dog.Bark();
                WriteLine();
            }

            mammal = new Human();
            mammal.Nurse();
            WriteLine();

            Human human = mammal as Human;
            if (human != null)
            {
                human.Nurse();
                human.Speak();
            }
        }

        public static void virtualFun()
        {
            //Car gasolineCar = new GasolineCar("소나타", "가솔린엔진");
            //gasolineCar.drive();

            //Car hybridCar = new HybridCar("프리우스", "가솔린엔진, 전기모터");
            //hybridCar.drive();


            GasolineCar gasolineCar = new GasolineCar("소나타", "가솔린엔진");
            gasolineCar.drive();

            HybridCar hybridCar = new HybridCar("프리우스", "가솔린엔진, 전기모터");
            hybridCar.drive();

        }
        public static void overlaid()
        {
            Configuration config = new Configuration();
            config.SetConfig("Version", "V5.0");
            config.SetConfig("Size", "655,324 KB");

            WriteLine(config.GetConfig("Version"));
            WriteLine(config.GetConfig("Size"));

            config.SetConfig("Version", "V5.1");
            WriteLine(config.GetConfig("Version"));
        }

        public static void partialClass()
        {
            AAA obj = new AAA();
            obj.Method1();
            obj.Method2();
            obj.Method3();
            obj.Method4();
        }

        public static void enhancedclass()
        {
            WriteLine($"3^2 : {3.Square()}");
            WriteLine($"3^4 : {3.Power(4)}");
            WriteLine($"2^10 : {2.Power(10)}");
        }
        public static void csharpStructure()
        {
            Point3D point1;
            point1.x = 10;
            point1.y = 20;
            point1.z = 30;

            WriteLine(point1.ToString());

            Point3D point2 = new Point3D(100, 200, 300);
            Point3D point3 = point2;
            point3.z = 400;

            WriteLine(point2.ToString());
            WriteLine(point3.ToString());
        }
        public static void tuple()
        {
            var a = ("홍길동", 20);
            WriteLine($"{a.Item1}, {a.Item2}");

            var b = (Name: "홍길동",Age: 20);
            WriteLine($"{b.Name}, {b.Age}");

            b = a;
            WriteLine($"{b.Name},{b.Age}");
        }
        public void abstractClass()
        {
            AbstractBase obj = new Derived();
            obj.AbstractMethodA();
            obj.PublicMethodA();
        }
        public static void interfaceset()
        {
            WriteLine("FileLogger Start");
            ClimateMonitor monitor = new ClimateMonitor(new FileLogger("D:/MyLog.txt"));
            monitor.start();

            WriteLine("ConsoleLogger Start");
            ClimateMonitor monitor2 =
                new ClimateMonitor(new ConsolLogger());
            monitor2.start();
        }
        public static void interfaceInherit()
        {
            IFormattableLogger logger = new ConsoleLogger();
            logger.WriteLog("This is the first WriteLog method");
            logger.WriteLog("---{0}---", "This is second WriteLog method");
        }
    }
    //===================================================
    class Parent
    {
        protected string name;
       
        public Parent()
        {
            name = "김철수";
            WriteLine($"{this.name}.Parent()");
        }

        public Parent(string name)
        {
            this.name = name;
            WriteLine($"{this.name}.Parent(string)");
        }

        ~Parent()
        {
            WriteLine($"{this.name}.~Parent()");
        }

        public void ParentMethod()
        {
            WriteLine($"{this.name}.ParentMethod()");
        }
    }

    class Child : Parent
    {
        public Child()
        {
            WriteLine($"{this.name}.Child()");
        }
        public Child(string name) : base(name)
        {
            WriteLine($"{this.name}.Child(string)");
        }

        ~Child()
        {
            WriteLine($"{this.name}.~Child()");
        }
        public void ChildMethod()
        {
            WriteLine($"{this.name}.ChildeMethod()");
        }
       
    }
    //===================================================
    class Mammal
    {
        public void Nurse()
        {
            WriteLine("Nursing~~");
        }
    }

    class Dog : Mammal
    {
        public void Bark()
        {
            WriteLine("Barking~~");
        }
    }

    class Human : Mammal
    {
        public void Speak()
        {
            WriteLine("Speaking~~");
        }
    }

    //=========================================================
    class Car
    {
        protected string model;
        protected string powerTrain;

        public Car(string model,string powerTrain)
        {
            this.model = model;
            this.powerTrain = powerTrain;
        }

        //public virtual void drive()
        //{
        //    WriteLine("달린다~~~");
        //}
        public void drive()
        {
            WriteLine("달린다~~~");
        }
    }
    class GasolineCar : Car
    {
        public GasolineCar(string model,string powerTrain)
            : base(model, powerTrain)
        {

        }
        //public override void drive()
        //{
        //    WriteLine($"{model} {powerTrain} 부르릉~~~");
        //}
        public new void drive()
        {
            WriteLine($"{model} {powerTrain} 부르릉~~~");
        }
    }

    class HybridCar : Car
    {
        public HybridCar(string model,string powerTrain)
            : base(model, powerTrain) { }
        //public override void drive()
        //{
        //    WriteLine($"{ model}  { powerTrain} 드르륵~~~");
        //}
        public new void drive()
        {
            WriteLine($"{ model}  { powerTrain} 드르륵~~~");
        }
    }

    class Configuration
    {
        List<ItemValue> listConfig = new List<ItemValue>();

        public void SetConfig(string item,string value)
        {
            ItemValue iv = new ItemValue();
            iv.SetValue(this, item, value);
        }
        public string GetConfig(string item)
        {
            foreach(ItemValue iv in listConfig)
            {
                if (iv.GetItem() == item)
                    return iv.GetValue();
            }
            return "";
        }
        private class ItemValue
        {
            string item;
            string value;
            public void SetValue(Configuration config,string item,string value)
            {
                this.item = item;
                this.value = value;

                bool found = false;
                for(int i = 0; i < config.listConfig.Count; i++)
                {
                    if (item == config.listConfig[i].item)
                    {
                        config.listConfig[i] = this;
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    config.listConfig.Add(this);
                }
            }
            public string GetItem()
            {
                return item;
            }
            public string GetValue()
            {
                return value;
            }
        }
    }

    partial class AAA
    {
        public void Method1()
        {
            WriteLine("Method1()");
        }
        public void Method2()
        {
            WriteLine("Method2()");
        }
    }
    partial class AAA
    {
        public void Method3()
        {
            WriteLine("Method3()");
        }
        public void Method4()
        {
            WriteLine("Method4()");
        }
    }

    public static class EnhancedInteger
    {
        public static int Square(this int input)
        {
            return input * input;
        }

        public static int Power(this int input,int exponent)
        {
            int result = input;
            for (int i = 1; i < exponent; i++)
                result *= input;
            return result;
        }
    }

    struct Point3D
    {
        public int x;
        public int y;
        public int z;

        public Point3D(int x,int y,int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return string.Format($"{x}, {y}, {z}");
        }
    }

    abstract class AbstractBase
    {
       
        protected void ProtectedMethodA()
        {
            Console.WriteLine("AbstractBase.ProtectedMethodA()");
        }
        public void PublicMethodA()
        {
            Console.WriteLine("AbstractBase.PublicMethodA()");
        }
        public abstract void AbstractMethodA();
    }

    class Derived : AbstractBase
    {
        public override void AbstractMethodA()
        {
            Console.WriteLine("Derived.AbstarctMethodA()");
            ProtectedMethodA();
        }
    }

    interface ILogger
    {
        void WriteLog(string message);
    }
    class ConsolLogger : ILogger
    {
        public void WriteLog(string message)
        {
            WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
    }
    class FileLogger : ILogger
    {
        private StreamWriter writer;
        public  FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }

        public void WriteLog(string message)
        {
            writer.WriteLine("{0}, {1}", DateTime.Now.ToLocalTime(), message);
        }
    }

    class ClimateMonitor
    {
        private ILogger logger;
        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }
        
        public void start()
        {
            while (true)
            {
                Write("온도 입력: ");
                string temperature = ReadLine();
                if (temperature == "")
                    break;
                logger.WriteLog("현재 온도: " + temperature);
            }
        }
    }
    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params object[] args);
    }
    class ConsoleLogger : IFormattableLogger
    {
        public void WriteLog(string format, params object[] args)
        {
            string message = string.Format(format, args);
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }

        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
        
    }
}
