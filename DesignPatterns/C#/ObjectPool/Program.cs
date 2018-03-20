using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectPool
{
    class Program
    {
        static Random s_random;

        public class ConnectionToPrinter
        {
            public void SendData(string text)
            {
                Console.WriteLine(text);
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
                    Console.WriteLine("--> reuse connection <---");
                    return item;
                }
                else if (items.Count < MAX_ITEMS_COUNT)
                {
                    T obj = new T();
                    items.Add(obj);
                    itemsCount++;
                    Console.WriteLine("--> new connection <--");
                    return obj;
                }
                else
                {
                    Console.WriteLine("--> no available connection <--");
                    return default(T);
                }
            }

        }

        static void Main(string[] args)
        {
            ObjectPool<ConnectionToPrinter> objectPool = ObjectPool<ConnectionToPrinter>.Instance();
            s_random = new Random();
            for (int i = 0; i < 20; i++)
            {
                var thread = new Thread(new ThreadStart(ThreadActivity));
                thread.Start();
                thread.Join();
            }
            Console.ReadKey();
        }

        static void ThreadActivity()
        {
            Parallel.For(0, 5, action =>
             {
                 var c = ObjectPool<ConnectionToPrinter>.Instance().Get();
                 while (c == null)
                 {
                     Thread.Sleep(20);
                     c = ObjectPool<ConnectionToPrinter>.Instance().Get();
                 }
                 c.SendData(string.Format("thread {0} printed something", Thread.CurrentThread.ManagedThreadId));
                 ObjectPool<ConnectionToPrinter>.Instance().ReleaseResouce(c);
                 Thread.Yield();
                 var mseconds = s_random.Next(1, 3) * 1000;
                 Thread.Sleep(mseconds);
             });
        }
    }
}
