using System;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace _0323
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncAwait();
        }
        #region Thread
        static void threadSet() {
            Thread thread = new Thread(new ThreadStart(BlueFlag));

            WriteLine("Start thread..");
            thread.Start();

            for(int i = 0; i < 10; i ++)
            {
                WriteLine($"백기");
                Thread.Sleep(10);
            }
            WriteLine("Waiting until thread stop...");
            thread.Join();  

            WriteLine("Finished");
        }
        static void BlueFlag()
        {
            for (int i = 0; i < 10; i++)
            {
                WriteLine($"청기");
                Thread.Sleep(10);
            }

        }

        #region Ways to stop thread
        #region Exception
        static void thread_Exception()
        {
           

            Thread thread = new Thread(new ThreadStart(BlueFlag));

            WriteLine("Start thread..");
            thread.Start();

            Thread.Sleep(100);

            WriteLine("Aborting thread...");
            thread.Abort(); //Signal이 CLR로 이동후 CLR에서 Exception 발생

            WriteLine("Wating until tthread stop..");
            thread.Join();


            WriteLine("Finished");
        }
        static void BlueFlag_Exception()
        {
            Thread thread = new Thread(new ThreadStart(BlueFlag_Exception));

            WriteLine("Start thread..");
            try
            {

                while (true)
                {
                    WriteLine($"청기");
                    Thread.Sleep(10);
                }
            }
            catch (ThreadAbortException e)
            {
                WriteLine(e);
                Thread.ResetAbort();
            }
            finally
            {
                WriteLine("리소스 해제");
            }
            WriteLine("추가작업");

        }
        #endregion
        #region Flag
        static Boolean setStop = false;
        static void BlueFlag_Flag()
        {
            while (!setStop)
            {
                WriteLine("청기");
                Thread.Sleep(10);
            }
            WriteLine("추가 작업");
        }

        static void thread_Flag()
        {
            Thread thread = new Thread(new ThreadStart(BlueFlag_Flag));
            WriteLine("Start thread..");
            thread.Start();

            Thread.Sleep(100);
            WriteLine("Stop thread...");
            setStop = true;

            WriteLine("Waiting until thread stop...");
            thread.Join();
            WriteLine("Finished");

        }
        #endregion
        #region Interupt
        static void thread_WakeSleepJoin()
        {
            Thread thread = new Thread(new ThreadStart(BlueFlag_WakeSleepJoin));
            WriteLine("Start thread..");
            thread.Start();

            Thread.Sleep(100);

            WriteLine("Interrupting thread...");
            thread.Interrupt();

            WriteLine("Waiting until thread stop...");
            thread.Join();

            WriteLine("Finished");

        }
        static void BlueFlag_WakeSleepJoin()
        {
            try
            {
                while (true)
                {
                    WriteLine("청기");
                    Thread.Sleep(10);
                }
            }
            catch(ThreadInterruptedException e)
            {
                WriteLine(e);
            }
            finally
            {
                WriteLine("리소스 해제");
            }
        }
        #endregion
        #endregion

        #region Ways to Synchronize Thread
        #region No_Sync
        class Counter
        {
            const int LOOP_COUNT = 1000;
            private int count;
            public int Count
            {
                get { return count; }
            }
            public Counter()
            {
                count = 0;
            }
            public void Increase()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    count++;
                    Thread.Sleep(1);
                }
            }
            public void Decrease()
            {
                int loopCount=LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    count--;
                    Thread.Sleep(1);
                }
            }
        }
        static void thread_Nosync()
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine(counter.Count);
        }
        #endregion
        #region Lock
        class Counter_Lock
        {
            const int LOOP_COUNT = 1000;
            private int count;
            readonly object thislock;
            public int Count
            {
                get { return count; }
            }
            public Counter_Lock()
            {
                count = 0;
                thislock = new object();
            }
            public void Increase()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    lock (thislock)
                    {
                        count++;
                    }
                }
            }
            public void Decrease()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    lock (thislock)
                    {
                        count--;
                    }
                }
            }
        }
        static void thread_Lock()
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine(counter.Count);
        }
        #endregion
        #region MonitorEnter
        class Counter_MonitorEner
        {
            const int LOOP_COUNT = 1000;
            private int count;
            readonly object thislock;
            public int Count
            {
                get { return count; }
            }
            public Counter_MonitorEner()
            {
                count = 0;
                thislock = new object();
            }
            public void Increase()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    Monitor.Enter(thislock);
                    try { 
                        count++;
                    }
                    finally
                    {
                        Monitor.Exit(thislock);
                    }
                    Thread.Sleep(1);

                }
            }
            public void Decrease()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    Monitor.Enter(thislock);
                    try
                    {
                        count--;
                    }
                    finally
                    {
                        Monitor.Exit(thislock);
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void thread_MonitorEnter()
        {
            Counter_MonitorEner counter = new Counter_MonitorEner();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine(counter.Count);
        }
        #endregion
        #region LowLevel
        class Counter_LowLevel
        {
            const int LOOP_COUNT = 1000;
            readonly object thisLock;
            bool lockedCount = false;
            private int count;
            public int Count
            {
                get { return count; }
            }
            public Counter_LowLevel()
            {
                count = 0;
                thisLock = new object();
            }
            public void Increase()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    lock (thisLock)
                    {
                        if (count > 0 || lockedCount == true)
                        {
                            Monitor.Wait(thisLock);
                        }
                        lockedCount = true;
                        count++;
                        lockedCount = false;
                        Monitor.Pulse(thisLock);
                    }
                }
            }
            public void Decrease()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    lock (thisLock)
                    {
                        if (count < 0 || lockedCount == true)
                        {
                            Monitor.Wait(thisLock);
                        }
                        lockedCount = true;
                        count--;
                        lockedCount = false;
                        Monitor.Pulse(thisLock);
                    }
                }
            }
        }
        static void thread_LowLevel()
        {
            Counter_LowLevel counter = new Counter_LowLevel();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            WriteLine(counter.Count);
        }
        #endregion
        #endregion
        #endregion
        #region Task
        #region Asynchronism
        static void async_Task(string[] args)
        {
            string srcFile = args[0];

            Action<object> FileCopyAction = (object state) =>
              {
                  string[] paths = (string[])state;
                  File.Copy(paths[0], paths[1]);

                  WriteLine("TaskId{0}, ThreadID:{1}, {2} was copied to {3}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, paths[0], paths[1]);
              };

            Task t1 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy1" });       //Start 실행시 실행(비동기)
            t1.Start();

            Task t2 = Task.Run(() =>                                                                //생성과 동시에 실행(비동기)
              {
                  FileCopyAction(new string[] { srcFile, srcFile + ".copy2" });
              });

            Task t3 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy3" });       //동기방식으로 실행
            t3.RunSynchronously();

            t1.Wait();
            t2.Wait();

        }

        #region Parallel_Task
        static bool IsPrime(long number)
        {
            if (number < 2)
                return false;
            if (number % 2 == 0 && number != 2)
                return false;
            for (long i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        static void parallel_Task(string [] args)
        {
            long from = Convert.ToInt64(args[0]);
            long to = Convert.ToInt64(args[1]);

            int taskCount = Convert.ToInt32(args[2]);


            Func<object, List<long>> FindPrimeFunc = (objRange) =>
             {
                 long[] range = (long[])objRange;
                 List<long> found = new List<long>();

                 for (long i = range[0]; i <= range[1];i++)
                 {
                     if (IsPrime(i))
                         found.Add(i);
                 }
                 return found;
             };

         

            Task<List<long>>[] tasks = new Task<List<long>>[taskCount];
            long currentFrom = from;
            long currentTo = from + (to - from) / tasks.Length;

            for(int i = 0; i < tasks.Length; i++)
            {
                WriteLine("Task[{0}]::{1}~{2}",
                    i, currentFrom, currentTo);

                tasks[i] = new Task<List<long>>(FindPrimeFunc, new long[] { currentFrom, currentTo });
                currentFrom = currentTo + 1;

                if (i == tasks.Length-2)
                    currentTo = to;
                else
                    currentTo += ((to - from) / tasks.Length);
            }

            WriteLine("Please press enter to start...1");
            ReadLine();
            WriteLine("Started...");

            DateTime startTime = DateTime.Now;

            foreach (Task<List<long>> task in tasks)
                task.Start();

            List<long> total = new List<long>();

            foreach(Task<List<long>> task in tasks)
            {
                total.AddRange(task.Result.ToArray());
            }
            DateTime endTime = DateTime.Now;

            TimeSpan ellapsed = endTime - startTime;

            WriteLine("Prime number count between {0} abd {1} : {2}", from, to, total.Count);
            WriteLine("Ellapsed time : {0}", ellapsed);
        }
        #endregion
        #region Parallel_Class
        static void Class_Parallel(string[] args)
        {
            long from = Convert.ToInt64(args[0]);
            long to = Convert.ToInt64(args[1]);
            object thisLock = new object();
            WriteLine("Please press enter to start...");
            ReadLine();
            WriteLine("Started");

            DateTime startTime = DateTime.Now;
            List<long> total = new List<long>();

            Parallel.For(from, to + 1, (i) =>
            {
                if (IsPrime(i))
                {
                    lock (thisLock)
                    {

                        total.Add(i);
                    }
                }
            });
            DateTime endTime = DateTime.Now;
            TimeSpan ellaspsed = endTime - startTime;

            WriteLine("Prime number count between {0} and {1} : {2}",
                from, to, total.Count);
            WriteLine("Ellapsed time : {0}", ellaspsed);
        }
        #endregion
        #region Async,Await
        async static private void MymethodAsync(int count)
        {
            WriteLine("C");
            WriteLine("D");

            await Task.Run(() =>
            {
                for (int i = 1; i <= count; i++)
                {
                    WriteLine($"{i}/{count}...");
                    Thread.Sleep(100);
                }
            });

            WriteLine("G");
            WriteLine("H");
        }

        static void Caller()
        {
            WriteLine("A");
            WriteLine("B");

            MymethodAsync(3);

            WriteLine("E");
            WriteLine("F");
        }

        static void AsyncAwait()
        {
            Caller();
            WriteLine("##########################");
            ReadLine(); //Task가 완전히 종료될 때 까지 대기
        }
        #endregion
        #endregion

        #endregion
    }
}

