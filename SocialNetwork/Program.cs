namespace SocialNetwork
{
    using SocialNetwork.BLL.Models;
    using SocialNetwork.BLL.Services;
    using System;

    class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to the social network!");

            while (true)
            {
                Console.WriteLine("For regestration input your name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Lastname:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Password:");
                string password = Console.ReadLine();

                Console.WriteLine("email:");
                string email = Console.ReadLine();


                UserRegistrationData userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };
                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Registration successful!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Please input correct data");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("It was an error during registration");
                }
            }
        }
    }
}
