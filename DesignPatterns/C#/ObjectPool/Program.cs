using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectPool
{
    class Program
    {
        static Random s_random;

        private static Mutex mutex = new Mutex();

        public class ConnectionToPrinter
        {
            public void SendData(string text)
            {
                Console.WriteLine(text);
            }
        }

        public class ObjectPool<T> where T : new()
        {
            private readonly int MAX_ITEMS_COUNT = 5;

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
                Console.WriteLine($"\n--> resource released <---");
                items.Add(item);
            }

            public T Get()
            {
                T item;
                
                if (items.TryTake(out item))
                {
                    Console.WriteLine("\n--> reuse connection <---");
                    return item;
                }
                else if (itemsCount < MAX_ITEMS_COUNT)
                {
                    T obj = new T();
                    itemsCount++;
                    Console.WriteLine("\n--> new connection <--");
                    return obj;
                }
                else
                {
                    Console.Write(".");
                    return default(T);
                }

            }

        }

        static void Main(string[] args)
        {
            s_random = new Random();
            for (int i = 0; i < 10; i++)
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
                 mutex.WaitOne();
                 var c = ObjectPool<ConnectionToPrinter>.Instance().Get();
                 mutex.ReleaseMutex();
                 while (c == null)
                 {
                     Thread.Sleep(100);
                     mutex.WaitOne();
                     c = ObjectPool<ConnectionToPrinter>.Instance().Get();
                     mutex.ReleaseMutex();
                 }
                 c.SendData(string.Format("\nthread {0} printed something", Thread.CurrentThread.ManagedThreadId));
                 var mseconds = s_random.Next(1, 3) * 1000;
                 Thread.Sleep(mseconds);
                 Thread.Yield();
                 mutex.WaitOne();
                 ObjectPool<ConnectionToPrinter>.Instance().ReleaseResouce(c);
                 mutex.ReleaseMutex();
             });
        }
    }
}
