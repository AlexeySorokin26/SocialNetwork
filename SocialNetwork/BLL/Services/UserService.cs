﻿namespace SocialNetwork.BLL.Services
{
    using System;
    using SocialNetwork.BLL.Models;
    using SocialNetwork.DAL.Repositories;
    using SocialNetwork.DAL.Entities;
    using System.ComponentModel.DataAnnotations;
    
    public class UserService
    {
        IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {
            // check data if they are correct
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();
            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();
            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            // create new entity
            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            // save a new entity in db
            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();
        }
    }
}
