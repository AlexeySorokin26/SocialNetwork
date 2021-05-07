namespace SocialNetwork.PLL.Views
{
    using System;
    using System.Linq;
    using SocialNetwork.BLL.Models;
    using SocialNetwork.BLL.Services;

    public class UserMenuView
    {
        UserService userService;

        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("incoming messages :{0}", user.IncomingMessages.Count());
                Console.WriteLine("outgoing messages :{0}", user.OutgoingMessages.Count());

                Console.WriteLine("Show info about my profile type 1");
                Console.WriteLine("Correct my profile type 2");
                Console.WriteLine("Add friends type 3");
                Console.WriteLine("Write a message type 4");
                Console.WriteLine("Show incoming messages type 5");
                Console.WriteLine("Show outgoing messages type 6");
                Console.WriteLine("To exit type 7");

                string keyValue = Console.ReadLine();

                if (keyValue == "7") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }

                    case "2":
                        {
                            Program.userDataUpdateView.Show(user);
                            break;
                        }

                    case "4":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }

                    case "5":
                        {
                            Program.userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }

                    case "6":
                        {
                            Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }
                }
            }
        }
    }
}
