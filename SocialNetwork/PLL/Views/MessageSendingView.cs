namespace SocialNetwork.PLL.Views
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SocialNetwork.BLL.Exceptions;
    using SocialNetwork.BLL.Models;
    using SocialNetwork.BLL.Services;
    using SocialNetwork.PLL.Helpers;

    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;

        public MessageSendingView(MessageService ms, UserService us)
        {
            messageService = ms;
            userService = us;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.WriteLine("input email of receipent:");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("input message (not more than 5000 symbols");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);

                SuccessMessage.Show("message successefully sent!");

                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("user not found!");
            }
            catch(ArgumentNullException)
            {
                AlertMessage.Show("not correct data (symbols more than 5000)");
            }
            catch (Exception)
            {
                AlertMessage.Show("some error aquired during sending a message!");
            }
        }
    }
}
