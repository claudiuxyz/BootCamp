using System;

namespace Decorator
{
    //-------- Component --------------
    public interface EmailBody //Component
    {
        void LoadBody();
    }

    public class Email : EmailBody // Concrete Component
    {
        public void LoadBody()
        {
            Console.WriteLine("Main email body");
        }
    }

    //-------- Decorators --------------

    public abstract class EmailDecorator : EmailBody // Base Decorator
    {
        public EmailDecorator(EmailBody emailBody)
        {
            m_emailBody = emailBody;
        }
        public abstract void LoadBody();

        protected EmailBody m_emailBody;
    }

    public class ChristmasDecorator : EmailDecorator
    {
        public ChristmasDecorator(EmailBody emailBody): base(emailBody) { }

        public override void LoadBody()
        {
            Console.WriteLine("Christmas content");
            m_emailBody.LoadBody();
        }
    }

    public class NewYearDecorator : EmailDecorator
    {
        public NewYearDecorator(EmailBody emailBody) : base(emailBody) { }

        public override void LoadBody()
        {
            Console.WriteLine("New Year content");
            m_emailBody.LoadBody();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var email = new Email();
            var xmasEmail = new ChristmasDecorator(email);
            var bothHolidaysEmail = new NewYearDecorator(xmasEmail);

            bothHolidaysEmail.LoadBody();
            Console.ReadKey();
        }
    }
}
