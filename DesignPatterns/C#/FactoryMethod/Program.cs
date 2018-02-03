using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FactoryMethod
{
    //---------- Interfaces & abstract classes ---------------
    public interface IDocumentTypes
    {
    }
    public abstract class DocumentGenerator
    {
        public abstract IDocumentTypes FactoryMethod();

        public void NewDocument()
        {

        }

        public void PrintDocument()
        {
        }
    }

    //---------- Concrete documents ---------------
    public class HtmlDoc : IDocumentTypes
    {

    }
    public class XmlDoc : IDocumentTypes
    {

    }
    public class TextDoc : IDocumentTypes
    {

    }
    //---------- Concrete document generators ---------------
    public class HtmlGenerator: DocumentGenerator
    {
        public override IDocumentTypes FactoryMethod()
        {
            return new HtmlDoc();
        }
    }

    public class XmlGenerator : DocumentGenerator
    {
        public override IDocumentTypes FactoryMethod()
        {
            return new XmlDoc();
        }
    }

    public class TextGenerator : DocumentGenerator
    {
        public override IDocumentTypes FactoryMethod()
        {
            return new TextDoc();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
