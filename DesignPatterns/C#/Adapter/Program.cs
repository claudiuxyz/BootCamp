using System;

namespace Adapter
{
    class Program
    {

        public class RomanianPlugConnector
        {
            public virtual void GiveElectricity()
            {
                Console.WriteLine("Tzzzzzzzzz");
            }
        }

        public class RomanianSocket
        {
            public void PlugIn(RomanianPlugConnector connector)
            {
                connector.GiveElectricity();
            }
        }

        public class UKPlugConnector
        {
            public virtual void ProvideElectricity()
            {
                Console.WriteLine("TheTzzzzzzzzz");
            }
        }

        //--------- Adapter -----------------
        public class UKToRomanianPlugConnector: RomanianPlugConnector
        {
            private UKPlugConnector m_connector;
            public UKToRomanianPlugConnector(UKPlugConnector connector)
            {
                m_connector = connector;
            }

            public override void GiveElectricity()
            {
                m_connector.ProvideElectricity();
            }

        }
        static void Main(string[] args)
        {
            UKPlugConnector ukConnector = new UKPlugConnector();
            RomanianSocket roSocket = new RomanianSocket();
            roSocket.PlugIn(new UKToRomanianPlugConnector(ukConnector));
            Console.ReadKey();
        }
    }
}
