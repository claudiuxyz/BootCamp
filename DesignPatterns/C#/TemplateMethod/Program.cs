using System;

namespace TemplateMethod
{
    public abstract class Document
    {
        public void Print() //Template method
        {
            PrintHeader();
            PrintBody();
            PrintFooter();
        }
        public abstract void PrintHeader();
        public abstract void PrintBody();
        public abstract void PrintFooter();
    }

    public class XMLDocument : Document
    {
        public override void PrintHeader()
        {
            Console.WriteLine("<?xml version=\"1.0\" encoding=\"UTF - 8\" standalone=\"no\" ?>");
        }

        public override void PrintBody()
        {
            Console.WriteLine(@"
    < note >
        < to > Tove </ to >
        < from > Jani </ from >
        < heading > Reminder </ heading >
        < body > Don't forget me this weekend!</body>
    </ note >");
        }

        public override void PrintFooter()
        {
            Console.WriteLine(@"
    < footer >
        < p > Posted by: Hege Refsnes</ p >
        < p > Contact information: < a href = 'mailto:Tove@niceserver.com' >
        tove@niceserver.com </ a >.</ p >
    </ footer >");
        }
    }

    public class HTMLDocument:Document
    {
        public override void PrintHeader()
        {
            Console.WriteLine(@"
<!DOCTYPE html>
<html>");
        }

        public override void PrintBody()
        {
            Console.WriteLine(@"
    <body>
        <h1>My First Heading</h1>
        <p>My first paragraph.</p>
    </body>");
        }

        public override void PrintFooter()
        {
            Console.WriteLine("</html>");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var doc in new Document[] { new XMLDocument(), new HTMLDocument() })
            {
                doc.Print();
            }
            Console.ReadKey();
        }
    }
}
