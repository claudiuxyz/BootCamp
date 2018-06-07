using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    //-------- Traversal -------------------------
    public interface Traversal
    {
        object First();
        object Next();
        object Current();
        bool IsDone();
    }

    public  class TvChannelsTraversal : Traversal
    {
        private TvChannelsCollection m_collection;
        private int m_idx = 0;

        public TvChannelsTraversal(TvChannelsCollection collection)
        {
            m_collection = collection;
        }

        public object First()
        {
            m_idx = 0;
            if (m_collection.Count() > 1)
            {
                return m_collection[m_idx]; 
            }
            return null;
        }

        public bool IsDone()
        {
            return m_collection.Count() == m_idx;
        }

        public object Next()
        {
            m_idx++;
            if (m_idx < m_collection.Count() - 1)
            {
                return m_collection[m_idx];
            }
            return null;
        }

        public object Current()
        {
            return m_collection[m_idx];
        }
    }

    //-------- Collection -------------------------

    public interface Collection
    {
        Traversal CreateTraversal();
    }

    public class TvChannelsCollection : Collection
    {
        private ArrayList m_channels = new ArrayList(); 

        public object this[int index] {
            get {
                return m_channels[index];
            }
            set {
                m_channels.Insert(index, value);
            }
        }

        public Traversal CreateTraversal()
        {
            return new TvChannelsTraversal(this);
        }

        public int Count()
        {
            return m_channels.Count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TvChannelsCollection channels = new TvChannelsCollection();
            channels[0] = "TVR";
            channels[1] = "AXN";
            channels[2] = "PROTV";
            channels[3] = "NATGEO";
            Traversal i = channels.CreateTraversal();
            object elem = i.First();
            while (!i.IsDone())
            {
                Console.WriteLine(i.Current());
                i.Next();
            }
            Console.ReadKey();
        }
    }
}
