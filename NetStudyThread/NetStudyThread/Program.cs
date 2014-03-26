using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace NetStudyThread
{
    public class Program
    {
        public static void Main()
        {
           // TestTask();

            //TestBoxingAndUnboxing();
           // TestBoxingAndUnboxingUsingList();
           

           // TestTaskWithForm();
            //TestCancelTask();
            TestParallel();
          
        }

        private static void TestParallel()
        {
            List<String> data = new List<String>(){"There","were", "many" ,"animal","at","the","zoo"};
            Parallel.For(0,10,x=>Console.WriteLine(x));
            Parallel.ForEach(data,x => Console.WriteLine(x));
            Console.Read();
        }

        private static void TestCancelTask()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Task<List<int>> taskWithFactoryAndState =
                Task.Factory.StartNew<List<int>>(stateObjec =>
                {
                    List<int> ints = new List<int>();
                    for (int i = 0; i < (int)stateObjec; i++)
                    {
                        ints.Add(i);
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine("TaskwithFactoryAndState, creating item: {0}",i);
                    }
                    return ints;
                }, 2000,token);

            Console.WriteLine("Task Cancelled? {0}", taskWithFactoryAndState.IsCanceled);
            tokenSource.Cancel();

            if (taskWithFactoryAndState.IsCanceled == false && taskWithFactoryAndState.IsFaulted == false)
            {
                try
                {
                    if (!taskWithFactoryAndState.IsFaulted)
                    {
                        Console.WriteLine("Managed to get {0} items", taskWithFactoryAndState.Result.Count);
                    }
                }
                catch (AggregateException aggEx)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (Exception ex in aggEx.InnerExceptions)
                    {
                        sb.AppendFormat("Caught exception '{0}'", ex.Message);
                        sb.AppendLine();
                    }

                    Console.WriteLine(sb.ToString());
                }
                finally
                {
                    taskWithFactoryAndState.Dispose();
                }
            }
            else
            {
                Console.WriteLine("Task Cancelled? {0}", taskWithFactoryAndState.IsCanceled);
            }

            Console.Read();

        }

        private static void TestTaskWithForm()
        {
            Application.Run(new TestForm());
        }

        private static void TestBoxingAndUnboxingUsingList()
        {
            List<A> values = new List<A>();
            A a = new A();
            a.Val = 20;
            a.Person = new Person();
            a.Person.Name = "YY";
            a.Person.Age = 200;
            values.Add(a);
            Console.WriteLine("A value is: ");
            Console.WriteLine(a.ToString());

            Console.WriteLine("Change  value of A in list, value is: ");
            A a1= values[0];
            a1.Person.Name = "yy";
            a1.Val = 10;
            Console.WriteLine("A value is: ");
            Console.WriteLine(a.ToString());
            Console.WriteLine("A1 value is: ");
            Console.WriteLine(a1.ToString());
            Console.WriteLine("values[0] value is: ");
            Console.WriteLine(values[0].ToString());

            Console.WriteLine("Change  value of A, value is: ");
            A a2 = values[0];
            a.Person.Name = "abc";
            a.Val = 10;
            Console.WriteLine("A value is: ");
            Console.WriteLine(a.ToString());
            Console.WriteLine("A1 value is: ");
            Console.WriteLine(a2.ToString());
            Console.WriteLine("values[0] value is: ");
            Console.WriteLine(values[0].ToString());
            Console.Read();
        }

        private static void TestBoxingAndUnboxing()
        {
            A a = new A();
            a.Val = 20;
            a.Person = new Person();
            a.Person.Name = "YY";
            a.Person.Age = 200;

            Console.WriteLine("A value is: ");
            Console.WriteLine(a);

            Object o = a;
            Console.WriteLine("Boxed value is: ");
            Console.WriteLine(o);

            Console.WriteLine("Change  value of A, value is: ");
            a.Person.Name = "yy";
            a.Val = 10;
            Console.WriteLine(a);

            Console.WriteLine("Previous boxed value is: ");
            Console.WriteLine(o);

            Console.WriteLine("Unboxed value is: ");
            A a1 = (A)o;
            Console.WriteLine(a1);

            Console.WriteLine("Change  value of A1, A1 value is: ");
            a1.Person.Name = "win";
            a1.Val = 100;
            Console.WriteLine(a1);

            Console.WriteLine("Boxed value is: ");
            Console.WriteLine(o);

            Console.WriteLine("A value is: ");
            Console.WriteLine(a);
            Console.Read();
        }


        private static void TestTask()
        {
            Stopwatch watch = new Stopwatch();
            int maxWaitHandleWaitAllAllowed = 64;
            ManualResetEventSlim[] mres = new ManualResetEventSlim[maxWaitHandleWaitAllAllowed];
            for (int i = 0; i < mres.Length; i++)
            {
                mres[i] = new ManualResetEventSlim(false);
            }

            long threadTime = 0;
            long taskTime = 0;
            watch.Start();
            for (int i = 0; i < mres.Length; i++)
            {
                int idx = i;
                Thread t = new Thread(state =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine(string.Format("Thread : {0}, outputing {1}", state, j));

                    }
                    mres[idx].Set();
                });
                t.Start(string.Format("Thread{0}", i));
            }

            WaitHandle.WaitAll((from x in mres select x.WaitHandle).ToArray());
            threadTime = watch.ElapsedMilliseconds;
            watch.Reset();
            for (int i = 0; i < mres.Length; i++)
            {
                mres[i].Reset();
            }

            watch.Start();
            for (int i = 0; i < mres.Length; i++)
            {
                int idx = i;
                Task t = Task.Factory.StartNew(state =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine(string.Format("Thread : {0}, outputing {1}", state, j));

                    }
                    mres[idx].Set();
                }, string.Format("Thread{0}", i));
            }

            WaitHandle.WaitAll((from x in mres select x.WaitHandle).ToArray());
            taskTime = watch.ElapsedMilliseconds;

            Console.WriteLine("Thread Time waited : {0}ms", threadTime);
            Console.WriteLine("Task Time waited : {0}ms", taskTime);

            for (int i = 0; i < mres.Length; i++)
            {
                mres[i].Reset();
            }
            Console.WriteLine("All done, press Enter to Quit");

            Console.ReadLine();
        }
    }

    public class Person {
        public String Name{get;set;}
        public int Age { get; set; }
    }

    public struct A {
        public Person Person{get;set;}
        public int Val { get; set; }
        //public A()
        //{
        //    Person = new Person();
        //    Person
        //}

        public override string ToString()
        {
            string result = "Val = " + Val.ToString();
            if (Person != null)
            {
                result += "[Person.Name = " + Person.Name  +", Person.Age = " + Person.Age.ToString() +"]";
            }
           
            return result;
        }
    }
}
