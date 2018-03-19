using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ObjectPool
{
    class Program
    {
        static Random s_random;

        public class ConnectionToPrinter
        {
            public class PrinterDevice
            {
                private static PrinterDevice m_instance;
                public static PrinterDevice Instance()
                {
                    if (m_instance == null)
                    {
                        m_instance = new PrinterDevice();
                    }
                    return m_instance;
                }

                public void Print(string text)
                {
                    Console.WriteLine(text);
                }
            }

            public void SendData(string text)
            {
                PrinterDevice.Instance().Print(text);
            }
        }

        public class ObjectPool<T> where T : new()
        {
            private readonly int MAX_ITEMS_COUNT = 2;

            private readonly ConcurrentBag<T> items = new ConcurrentBag<T>();

            private int itemsCount = 0;

            private static ObjectPool<T> s_objectPool;

            private ObjectPool() {}

            public static ObjectPool<T> Instance()
            {
                if (s_objectPool == null)
                {
                    s_objectPool = new ObjectPool<T>();
                }
                return s_objectPool;
            }

            public void ReleaseResouce(T item)
            {
                if(itemsCount<MAX_ITEMS_COUNT)
                {
                    items.Add(item);
                    itemsCount++;
                }
            }

            public T Get()
            {
                T item;
                if(items.TryTake(out item))
                {
                    itemsCount--;
                    return item;
                }
                else if (items.Count < MAX_ITEMS_COUNT)
                {
                    T obj = new T();
                    items.Add(obj);
                    itemsCount++;
                    return obj;
                }
                else
                {
                    return default(T);
                }
            }

        }

        static void Main(string[] args)
        {
            ObjectPool<ConnectionToPrinter> objectPool = ObjectPool<ConnectionToPrinter>.Instance();
            s_random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(new ThreadStart(ThreadActivity));
                thread.Start();
                thread.Join();
            }
            Console.ReadKey();
        }

        static void ThreadActivity()
        {
            for (int i = 0; i < 5; i++)
            {
                var mseconds = s_random.Next(1, 2) * 100;
                System.Threading.Thread.Sleep(mseconds);
                var c = ObjectPool<ConnectionToPrinter>.Instance().Get();
                while (c == null)
                {
                    System.Threading.Thread.Sleep(20);
                    c = ObjectPool<ConnectionToPrinter>.Instance().Get();
                }
                c.SendData(string.Format("thread {0} printed something", Thread.CurrentThread.ManagedThreadId));
                ObjectPool<ConnectionToPrinter>.Instance().ReleaseResouce(c);
                Thread.Yield();
            }
        }
    }
}
