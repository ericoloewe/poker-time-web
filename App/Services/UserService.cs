using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using App.Helpers;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace App.Services
{
    public interface IUserService
    {
        Task SaveAsync(NewUserData newUser);
        Task<UserData> LoginAsync(UserLoginData userLogin);
        Task<User> AuthenticateAsync(string email, string password);
    }

    public class UserService : IUserService
    {
        private const string CONTAINER_NAME = "users";
        private IUserRepository userRepository = new UserRepository();
        private CloudStorageService cloudStorageService;
        private AzureStorageConfig azureStorageConfigs;

        public UserService() { }

        public UserService(AzureStorageConfig azureStorageConfigs)
        {
            cloudStorageService = new CloudStorageService(azureStorageConfigs);
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var userPassword = CriptoHelper.encrypt(password);
            var user = await userRepository.FindByEmailAndPassword(email, userPassword);

            if (user == null)
            {
                throw new ArgumentException("There is no user with email and password");
            }

            return user;
        }

        public async Task SaveAsync(NewUserData newUser)
        {
            var url = await cloudStorageService.SaveFile(newUser.Image, CONTAINER_NAME);

            await userRepository.SaveAsync(new User
            {
                Email = newUser.Email,
                Image = new Image(url),
                Name = newUser.Name,
                Password = CriptoHelper.encrypt(newUser.Password),
            });
        }

        public async Task<UserData> LoginAsync(UserLoginData userLogin)
        {
            var user = await AuthenticateAsync(userLogin.Email, userLogin.Password);

            return new UserData
            {
                Email = user.Email,
                Image = user.Image.Url,
                Name = user.Name,
            };
        }
    }
}
