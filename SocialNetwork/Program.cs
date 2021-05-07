namespace SocialNetwork
{
    using SocialNetwork.BLL.Exceptions;
    using SocialNetwork.BLL.Models;
    using SocialNetwork.BLL.Services;
    using SocialNetwork.PLL.Views;
    using System;

    class Program
    {
        static MessageService messageService;
        static UserService userService;
        public static MainView mainView;
        public static RegistrationView registationView;
        public static AuthentificationView authentificationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            userService = new UserService();
            messageService = new MessageService();

            mainView = new MainView();
            registationView = new RegistrationView(userService);
            authentificationView = new AuthentificationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();

            while (true)
            {
                mainView.Show();
            }
 
        }
    }
}