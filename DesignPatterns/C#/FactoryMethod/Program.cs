using System;

namespace FactoryMethod
{
    //---------- Abstract classes ---------------
    public abstract class DocumentType
    {
        public abstract void SaveInfo(string info);
        public abstract string GetDocType();
        public string GetContent()
        {
            return m_info;
        }
        protected string m_info;
    }

    public abstract class DocumentGenerator
    {
        public abstract DocumentType FactoryMethod();

        public void NewDocument(string textToEmbed)
        {
            m_document = FactoryMethod();
            m_document.SaveInfo(textToEmbed);
        }

        public void PrintDocument()
        {
            Console.WriteLine("\n*********************");
            Console.WriteLine(string.Format("      {0} DOC", m_document.GetDocType()));
            Console.WriteLine("*********************");
            Console.WriteLine(m_document.GetContent());
        }

        private DocumentType m_document;
    }

    //---------- Concrete document types ---------------
    public class HtmlDoc : DocumentType
    {
        public override void SaveInfo(string info)
        {
            m_info = string.Format("<html>\n\t<head>HTML doc</head>\n\t<body>\n\t\t{0}\n\t</body>\n</html>", info);
        }
        public override string GetDocType()
        {
            return "HTML";
        }
    }
    public class XmlDoc : DocumentType
    {
        public override void SaveInfo(string info)
        {
            m_info = string.Format("<xml>\n\t<text>{0}</text>\n</xml>", info);
        }

        public override string GetDocType()
        {
            return "XML";
        }
    }
    public class TextDoc : DocumentType
    {
        public override void SaveInfo(string info)
        {
            m_info = info;
        }

        public override string GetDocType()
        {
            return "TEXT";
        }
    }
    //---------- Concrete document generators ---------------
    public class HtmlGenerator: DocumentGenerator
    {
        public override DocumentType FactoryMethod()
        {
            return new HtmlDoc();
        }
    }

    public class XmlGenerator : DocumentGenerator
    {
        public override DocumentType FactoryMethod()
        {
            return new XmlDoc();
        }
    }

    public class TextGenerator : DocumentGenerator
    {
        public override DocumentType FactoryMethod()
        {
            return new TextDoc();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DocumentGenerator[] doxList = {
                new XmlGenerator(),
                new HtmlGenerator(),
                new TextGenerator()
            };
          
            Console.Write("Enter text to embed in document: ");
            string textToEmbed = Console.ReadLine();
            foreach (var doc in doxList)
            {
                doc.NewDocument(textToEmbed);
                doc.PrintDocument();
            }
            Console.ReadKey();
        }
    }

}
