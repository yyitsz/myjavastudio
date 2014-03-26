using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;
using Framework.Utils;

namespace Biz.Test
{
    [TestFixture]
    public class TestReflection
    {
        [Test]
        [Ignore]
        public void TestPerformance()
        {
            ReflectionMemberAccessor rma = new ReflectionMemberAccessor();
            ExpressionMemberAccessor ema = new ExpressionMemberAccessor();
            TestClassForInvoking target = new TestClassForInvoking();
           
            
            int count = 1000;


            Stopwatch sw = new Stopwatch();
            sw.Reset();
            Console.WriteLine();
            Console.WriteLine("Test expression .....");
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                ema.InvokeMethod(target, "Test1", null, new PersonDto());
                ema.InvokeMethod(target, "Test2", null, new PersonDto());
                ema.InvokeMethod(target, "Test3", new Type[] { typeof(PersonDto) }, null, new PersonDto());
                ema.InvokeMethod(target, "Test3", new Type[] { typeof(PersonDto) }, null);
                ema.InvokeMethod(target, "Test3", null);
            }
            sw.Stop();
            Console.WriteLine("Total:" + sw.ElapsedMilliseconds);

            Console.WriteLine();
            Console.WriteLine("Test Reflection.....");
            sw.Reset();
            sw.Start();

            for (int i = 0; i < count; i++)
            {
                rma.InvokeMethod(target, "Test1", null, new PersonDto());
                rma.InvokeMethod(target, "Test2", null, new PersonDto());
                rma.InvokeMethod(target, "Test3", new Type[] { typeof(PersonDto) }, null, new PersonDto());
                rma.InvokeMethod(target, "Test3", new Type[] { typeof(PersonDto) }, null);
                rma.InvokeMethod(target, "Test3", null);
            }

            sw.Stop();
            Console.WriteLine("Total:" + sw.ElapsedMilliseconds);

           

        }
        [Test]
        [Ignore]
        public void TestPerformance2()
        {
            ReflectionMemberAccessor rma = new ReflectionMemberAccessor();
            ExpressionMemberAccessor ema = new ExpressionMemberAccessor();
            TestClassForInvoking target = new TestClassForInvoking();
            Console.WriteLine();
            Console.WriteLine("Test Reflection.....");
            Stopwatch sw = new Stopwatch();
            //sw.Start();
            //for (int i = 0; i < 1000; i++)
            //{
            //    rma.InvokeMethod(target, "Test1", null, new PersonDto());
            //    rma.InvokeMethod(target, "Test2", null, new PersonDto());
            //    //rma.InvokeMethod(target, "Test3", new Type[] { typeof(PersonDto) }, null, new PersonDto());
            //    rma.InvokeMethod(target, "Test3", new Type[] { typeof(PersonDto) }, null);
            //}

            //sw.Stop();
            //Console.WriteLine("Total:" + sw.ElapsedMilliseconds);

            sw.Reset();
            Console.WriteLine();
            Console.WriteLine("Test Reflection.....");
            sw.Start();
            //for (int i = 0; i < 1000; i++)
            //{
                //ema.InvokeMethod(target, "Test1", null, new PersonDto());
                //ema.InvokeMethod(target, "Test2", null, new PersonDto());
            ema.InvokeMethod(target, "Test3", new Type[] { typeof(PersonDto) }, new Type[] { typeof(PersonDto) }, null, null);
           
               // ema.InvokeMethod(target, "Test3", new Type[] { typeof(PersonDto) }, null);
               // ema.InvokeMethod(target, "Test3", null);
            //}
            sw.Stop();
            Console.WriteLine("Total:" + sw.ElapsedMilliseconds);

        }
    }

    public class TestClassForInvoking
    {
        public Object Test1(Object a)
        {
            return a;
        }

        public int Test2(Object b)
        {
            int i = 10 * 10 * 10;
            return i;
        }

        public Object Test3()
        {
            return "ABC";
        }
        public T Test3<T>()
        {
            int i = 10 * 10 * 10;
            int j = i * 10;
            return default(T);
        }

        public T Test3<T>(T input)
        {
            int i = 10 * 10 * 10;
            int j = i * 10;
            return input;
        }
    }
}
