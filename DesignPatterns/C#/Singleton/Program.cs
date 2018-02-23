using System;

namespace Singleton
{
    //-------- Singleton -------- 
    public class TextDecorator
    {
        public static TextDecorator Instance() //Singleton
        {
            if (m_textDecorator == null) {
                m_textDecorator = new TextDecorator();
            }
            return m_textDecorator;
        }

        public string UnderlineText(string text, char ctype='*')
        {
            return $"{text}\n{new String(ctype,text.Length)}";
        }

        public string BoxInText(string text, char ctype = '*')
        {
            return $"{new String(ctype, text.Length+4)}\n{ctype} {text} {ctype}\n{new String(ctype, text.Length+4)}";
        }

        public string FlankText(string text, char ctype = '*')
        {
            return $"{new String(ctype, 5)} {text} {new String(ctype, 5)}";
        }

        public string ListItemText(string text, char ctype = '*')
        {
            return $"{ctype} {text}";
        }

        private TextDecorator() { } // <= Important

        private static TextDecorator m_textDecorator;
    }

    //-------- Some classes -------- 
    class UsageDefault
    {
        public void Print()
        {
            Console.WriteLine(TextDecorator.Instance().UnderlineText("First and last name"));
            Console.WriteLine(TextDecorator.Instance().ListItemText("Element 1"));
            Console.WriteLine(TextDecorator.Instance().ListItemText("Element 2"));
            Console.WriteLine(TextDecorator.Instance().ListItemText("Element 3"));
            Console.WriteLine(TextDecorator.Instance().FlankText("END"));
        }
    }

    class UsageHashTag
    {
        public void Print()
        {
            Console.WriteLine(TextDecorator.Instance().BoxInText("Example: other char", '#'));
        }
    }
    
    //-------- Driver app -------- 

    class Program
    {
        static void Main(string[] args)
        {
            UsageDefault uDefault = new UsageDefault();
            uDefault.Print();
            UsageHashTag uHashTag = new UsageHashTag();
            uHashTag.Print();
            Console.ReadKey();
        }
    }
}
