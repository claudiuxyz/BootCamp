using System;
using System.Collections.Generic;

namespace Observer
{
    public abstract class Observer
    {
        protected Subject m_subject;
        public abstract void Update();
    }

    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            m_subject = subject;
            m_subject.AttachObserver(this);
        }
        public override void Update()
        {
            Console.WriteLine($"dec {m_subject.GetValue()} to binary: { Convert.ToString(m_subject.GetValue(), 2)}");
        }
    }

    public class HexObserver : Observer
    {
        public HexObserver(Subject subject)
        {
            m_subject = subject;
            m_subject.AttachObserver(this);
        }
        public override void Update()
        {
            Console.WriteLine($"dec {m_subject.GetValue()} to hex: { Convert.ToString(m_subject.GetValue(), 16)}");
        }
    }

    public class OctalObserver : Observer
    {
        public OctalObserver(Subject subject)
        {
            m_subject = subject;
            m_subject.AttachObserver(this);
        }
        public override void Update()
        {
            Console.WriteLine($"dec {m_subject.GetValue()} to oct: { Convert.ToString(m_subject.GetValue(), 8)}");
        }
    }

    public abstract class Subject
    {
        private List<Observer> m_observers = new List<Observer>();

        public void AttachObserver(Observer observer)
        {
            m_observers.Add(observer);
        }

        public void RemoveObservers(Observer observer)
        {
            m_observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var o in m_observers)
            {
                o.Update();
            }
        }
        public abstract void SetValue(int value);

        public abstract int GetValue();
    }

    public class ConcreteSubject : Subject
    {
        private int m_value = 0;

        public override void SetValue(int value)
        {
            m_value = value;
            NotifyObservers();
        }

        public override int GetValue()
        {
            return m_value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new ConcreteSubject();
            var bin = new BinaryObserver(subject);
            var hex = new HexObserver(subject);
            var oct = new OctalObserver(subject);

            subject.SetValue(32);
            subject.SetValue(255);
            Console.ReadKey();
        }
    }
}
