using System;


namespace Bridge
{
    public interface ITheme
    {
        void Render(string applicationType);
    }

    public class DarkTheme : ITheme
    {
        public void Render(string applicationType)
        {
            Console.WriteLine($"{applicationType} on dark theme");
        }
    }

    public class LightTheme : ITheme
    {
        public void Render(string applicationType)
        {
            Console.WriteLine($"{applicationType} on light theme");
        }
    }

    public abstract class WebApplication
    {
        protected ITheme m_theme;
        protected string m_aplicationType;
        public WebApplication(ITheme theme)
        {
            m_theme = theme;
        }
        public void RenderPages()
        {
            m_theme.Render(m_aplicationType);
        }
    }

    public class Blog : WebApplication
    {
        public Blog(ITheme theme): base(theme)
        {
            m_aplicationType = "Blog";
        }
    }

    public class News : WebApplication
    {
        public News(ITheme theme) : base(theme)
        {
            m_aplicationType = "News";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var darkBlog = new Blog(new DarkTheme());
            darkBlog.RenderPages();

            var lightNews = new News(new LightTheme());
            lightNews.RenderPages();
            Console.ReadKey();
        }
    }
}
