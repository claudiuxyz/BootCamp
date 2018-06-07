using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public interface Colleague
    {
        void SendMessage(string text, string nick="room");
        void Join(Mediator chatRoom);
        void Notify(string text, string sender);
        string Nick { set; get; }
    }

    public class ChatUser : Colleague
    {
        private Mediator m_chatRoom;
        public  string Nick { set; get; }
        public ChatUser(string nick)
        {
            Nick = nick;
        }
        public void SendMessage(string text, string nick="room")
        {
            m_chatRoom.Mediate(text, nick, this);
        }

        public void Join(Mediator chatRoom)
        {
            m_chatRoom = chatRoom;
            m_chatRoom.Register(this);
        }

        public void Notify(string text, string sender)
        {
            Console.WriteLine($"{Nick} got a message from {sender}: {text}");
        }
    }

    public interface Mediator
    {
        void Mediate(string text, string nick, Colleague colleague);
        void Register(Colleague colleague);

    }

    public class ChatRoom : Mediator
    {
        private List<Colleague> m_list = new List<Colleague>();

        public void Mediate(string text, string nick, Colleague colleague)
        {
            if (nick == "room")
            {
                foreach (var c in m_list)
                {
                    if (c.Nick != colleague.Nick)
                    {
                        c.Notify(text, colleague.Nick);
                    }
                }
            }
            else
            {
                foreach (var c in m_list)
                {
                    if (c.Nick == nick)
                    {
                        c.Notify(text, colleague.Nick);
                    }
                }
            }

        }

        public void Register(Colleague colleague)
        {
            m_list.Add(colleague);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var chatRoom = new ChatRoom();
            var user1 = new ChatUser("Ale");
            var user2 = new ChatUser("Clau");
            var user3 = new ChatUser("DalaiLama");
            var user4 = new ChatUser("Bono");
            var user5 = new ChatUser("DarthVader");

            user1.Join(chatRoom);
            user2.Join(chatRoom);
            user3.Join(chatRoom);
            user4.Join(chatRoom);
            user5.Join(chatRoom);

            user1.SendMessage("Hello World!");
            user5.SendMessage("ASL PLS", "Ale");
            user1.SendMessage("Go to the dark side, dude!", "DarthVader");
            user3.SendMessage("AUM");
            Console.ReadKey();
        }
    }
}
