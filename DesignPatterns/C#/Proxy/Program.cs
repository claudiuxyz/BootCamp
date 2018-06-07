using System;
using System.Collections.Generic;


namespace Proxy
{
    public interface IBankService //Subject
    {
        void GiveMoney(int amount);
    }

    public class INGBankService : IBankService // Real subject
    {
        private Dictionary<string, int> clientsData = new Dictionary<string, int>()
        {
            {"ah2606", 1000000 },
            {"cb0407", 12312897}
        };

        private string m_currentClient;

        public INGBankService(string clientId)
        {
            m_currentClient = clientId;
        }

        public void GiveMoney(int amount)
        {
            if (amount <= clientsData[m_currentClient])
            {
                Console.WriteLine($"{amount} Euro was withdrawn from your account");
                clientsData[m_currentClient] = clientsData[m_currentClient] - amount;
                Console.WriteLine($"=> {clientsData[m_currentClient]} Euro left");
            }
        }
    }

    public class ATMService : IBankService // Proxy
    {
        private Dictionary<string, int> authData = new Dictionary<string, int>()
        {
            {"ah2606", 8080 },
            {"cb0407", 9696}
        };

        private INGBankService m_bank;
        private Card m_currentCard;
        private bool m_isAuthorized = false;

        public ATMService(Card card)
        {
            m_currentCard = card;
            Console.WriteLine($"Hello {card.Name}");
            Console.Write("Enter PIN and press ENTER: ");
            ConsoleKeyInfo key;
            string pass="";
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);

            m_isAuthorized = Convert.ToInt32(pass) == authData[card.ClientId];
            Console.WriteLine("");
        }

        public void GiveMoney(int amount)
        {
            if (m_isAuthorized)
            {
                m_bank = new INGBankService(m_currentCard.ClientId);
                m_bank.GiveMoney(amount);
            }
            else
            {
                Console.WriteLine("Wrong PIN!");
            }
        }
    }

    public class Card
    {
        public string Name { get; private set; }
        public string ClientId { get; private set; }
        public int PIN { get; private set; }
        public Card(string name, string clientId, int pin)
        {
            Name = name;
            ClientId = clientId;
            PIN = pin;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var visaCard = new Card("Ale H", "ah2606", 8080);
            var atm = new ATMService(visaCard);
            atm.GiveMoney(1000);
            Console.ReadKey();
        }
    }
}
