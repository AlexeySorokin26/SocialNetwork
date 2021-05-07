namespace SocialNetwork.PLL.Views
{
    using System;
    using SocialNetwork.BLL.Exceptions;
    using SocialNetwork.BLL.Models;
    using SocialNetwork.BLL.Services;
    using SocialNetwork.PLL.Helpers;

    public class AuthentificationView
    {
        UserService userService;

        public AuthentificationView(UserService us)
        {
            userService = us;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Input you email:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Input you password:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = this.userService.Authenticate(authenticationData);

                SuccessMessage.Show("Successful login into the social network!");
                SuccessMessage.Show("Welcome " + user.FirstName);

                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException)
            {
                AlertMessage.Show("password wrong!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("User not found!");
            }
                
        }
    }
}
