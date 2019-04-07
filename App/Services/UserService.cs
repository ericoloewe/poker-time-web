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
    public class UserService
    {
        private const string CONTAINER_NAME = "users";
        private IUserRepository userRepository = new UserRepository();
        private CloudStorageService cloudStorageService;
        private AzureStorageConfig azureStorageConfigs;

        public UserService(AzureStorageConfig azureStorageConfigs)
        {
            cloudStorageService = new CloudStorageService(azureStorageConfigs);
        }

        public async Task Save(NewUserData newUser)
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

        public async Task<UserData> Login(UserLoginData userLogin)
        {
            var user = await userRepository.FindByEmailAndPassword(userLogin.Email, CriptoHelper.encrypt(userLogin.Password));

            if (user == null)
            {
                throw new ArgumentException("There is no user with email and password");
            }

            return new UserData
            {
                Email = user.Email,
                Image = user.Image.Url,
                Name = user.Name,
            };
        }
    }
}
