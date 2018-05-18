using System;
using System.Collections.Generic;

namespace Interpreter
{
    public interface Expression
    {
        int  Interpret();
    }

    public class Add : Expression
    {
        private Expression m_left;
        private Expression m_right;
        public Add(Expression left, Expression right)
        {
            m_left = left;
            m_right = right;
        }
        public int Interpret()
        {
            return m_left.Interpret() + m_right.Interpret();
        }
    }

    public class Substract : Expression
    {
        private Expression m_left;
        private Expression m_right;
        public Substract(Expression left, Expression right)
        {
            m_left = left;
            m_right = right;
        }
        public int Interpret()
        {
            return m_left.Interpret() - m_right.Interpret();
        }
    }

    public class Multiply : Expression
    {
        private Expression m_left;
        private Expression m_right;
        public Multiply(Expression left, Expression right)
        {
            m_left = left;
            m_right = right;
        }
        public int Interpret()
        {
            return m_left.Interpret() * m_right.Interpret();
        }
    }

    public class Divide : Expression
    {
        private Expression m_left;
        private Expression m_right;
        public Divide(Expression left, Expression right)
        {
            m_left = left;
            m_right = right;
        }
        public int Interpret()
        {
            return m_left.Interpret() / m_right.Interpret();
        }
    }

    public class Number : Expression
    {
        private int m_number;
        public Number(int number)
        {
            m_number = number;
        }

        public int Interpret()
        {
            return m_number;
        }
    }

    public class Util
    {
        public static bool IsOperator(string str)
        {
            if (str.Equals("+") || str.Equals("-") || str.Equals("*") || str.Equals("/"))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static Expression GetOperator(string str, Expression left, Expression right)
        {
            switch (str)
            {
                case "+": return new Add(left, right);
                case "-": return new Substract(left, right);
                case "*": return new Multiply(left, right);
                case "/": return new Divide(left, right);
            }
            return null;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string textToInterpret = "7 3 -";
            var tokens = textToInterpret.Split(' ');
            Stack<Expression> stack = new Stack<Expression>();
            foreach (var c in tokens)
            {
                if (Util.IsOperator(c))
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var expression = Util.GetOperator(c, left, right);
                    int result = expression.Interpret();
                    stack.Push(new Number(result));
                }
                else
                {
                    stack.Push(new Number(Int32.Parse(c)));
                }
            }
            Console.WriteLine($"{textToInterpret} = {stack.Pop().Interpret()}");
            Console.ReadKey();
        }
    }
}
