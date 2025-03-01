namespace Structural
{
    class Bridge
    {
        public interface IWebPage
        {
            void Display();
        }

        public class About : IWebPage
        {
            private ITheme _theme;
            public About(ITheme theme)
            {
                _theme = theme;
            }
            public void Display()
            {
                Console.WriteLine("About page in " + _theme.GetColor());
            }
        }

        public class Careers : IWebPage
        {
            private ITheme _theme;
            public Careers(ITheme theme)
            {
                _theme = theme;
            }
            public void Display()
            {
                Console.WriteLine("Careers page in " + _theme.GetColor());
            }
        }

        public interface ITheme
        {
            string GetColor();
        }

        public class DarkTheme : ITheme
        {
            public string GetColor()
            {
                return "Dark Black";
            }
        }

        public class LightTheme : ITheme
        {
            public string GetColor()
            {
                return "Light White";
            }
        }

        public static void DemonstrateBridge()
        {
            Console.WriteLine("开始演示桥接模式：\n");
            ITheme darkTheme = new DarkTheme();
            IWebPage about = new About(darkTheme);
            about.Display();

            ITheme lightTheme = new LightTheme();
            IWebPage careers = new Careers(lightTheme);
            careers.Display();
        }
    }
}
