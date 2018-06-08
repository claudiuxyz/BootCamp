using System;
using System.Collections.Generic;
using Interpreter;
namespace Memento
{
    public class Memento
    {
        public Memento(string expression)
        {
            ArithmeticExpression = expression;
        }
        public string ArithmeticExpression { set; get; }
    }

    public class CareTaker
    {
        private CalculatorExt m_calculator;
        private List<Memento> m_list = new List<Memento>();

        public CareTaker(CalculatorExt calculator)
        {
            m_calculator = calculator;
        }

        public void AddMemento()
        {
            m_list.Add(m_calculator.CreateMemento());
        }

        public void GetMemento(int idxOffset)
        {
           m_calculator.RestoreMemento(idxOffset < m_list.Count - 1 ? m_list[m_list.Count - idxOffset - 1] : null);
        }
    }

    public class CalculatorExt : Calculator
    {
        public Memento CreateMemento()
        {
            return new Memento(m_arithmeticExpression);
        }

        public void RestoreMemento(Memento memento)
        {
            m_arithmeticExpression = memento.ArithmeticExpression;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var calculator = new CalculatorExt();
            var careTaker = new CareTaker(calculator);
            calculator.SetArithmeticExpression("7 3 -");
            careTaker.AddMemento();
            calculator.SetArithmeticExpression("8 2 +");
            careTaker.AddMemento();
            calculator.SetArithmeticExpression("10 4 *");
            careTaker.AddMemento();
            calculator.SetArithmeticExpression("7 3 - 6 *");
            careTaker.AddMemento();
            Console.WriteLine($"{calculator.GetArithmeticExpression()} = {calculator.Compute()}");
            careTaker.GetMemento(2);
            Console.WriteLine($"{calculator.GetArithmeticExpression()} = {calculator.Compute()}");
            Console.ReadKey();
        }
    }
}
