using System;
using System.Collections.Concurrent;

namespace ObjectPool
{
    class Program
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

        public class ConnectionToPrinter
        {
            public void SendData(string text)
            {
                PrinterDevice.Instance().Print(text);
            }
        }

        public class ObjectPool<T> where T : new()
        {
            private readonly int MAX_ITEMS_COUNT = 5;

            private readonly ConcurrentBag<T> items = new ConcurrentBag<T>();

            private int itemsCount = 0;

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
                else
                {
                    T obj = new T();
                    items.Add(obj);
                    itemsCount++;
                    return obj;
                }
            }

        }

        static void Main(string[] args)
        {
            ObjectPool<ConnectionToPrinter> objectPool = new ObjectPool<ConnectionToPrinter>();
            var c = objectPool.Get();
            c.SendData("Test");
            objectPool.ReleaseResouce(c);
            Random random = new Random();
            Console.ReadKey();
        }

        static void ThreadActivity(Random random, string message, ObjectPool<ConnectionToPrinter> op)
        {
            var mseconds = random.Next(3, 10) * 1000;
            System.Threading.Thread.Sleep(mseconds);
            op.Get().SendData(message);
        }
    }
}
