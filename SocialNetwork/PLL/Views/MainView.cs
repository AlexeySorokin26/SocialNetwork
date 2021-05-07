namespace SocialNetwork.PLL.Views
{
    using System;

    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Enter your profile (type 1)");
            Console.WriteLine("Register (type 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.authentificationView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.registationView.Show();
                        break;
                    }
            }
        }
    }
}
