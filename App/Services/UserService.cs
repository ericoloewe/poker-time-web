using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using App.Datas;
using App.Helpers;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace App.Services
{
    public interface IUserService
    {
        Task SaveAsync(NewUserData newUser);
        Task<string> LoginAsync(UserLoginData userLogin);
        Task<User> AuthenticateAsync(string email, string password);
        User GetLoggedUser();
        UserData GetLoggedUserData();
        User GetUserByAuthToken(string authToker);
    }

    public class UserService : IUserService
    {
        // TODO: improve that
        public static IDictionary<string, User> AuthTokens { get; private set; } = new Dictionary<string, User>();
        public static string AUTH_COOKIE_NAME = "Authorization";
        private const string CONTAINER_NAME = "users";
        private IUserRepository userRepository;
        private ICloudStorageService cloudStorageService;
        private IHttpContextAccessor httpContextAccessor;

        public UserService(IUserRepository userRepository, ICloudStorageService cloudStorageService, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepository = userRepository;
            this.cloudStorageService = cloudStorageService;
            this.httpContextAccessor = httpContextAccessor;
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

        public async Task<string> LoginAsync(UserLoginData userLogin)
        {
            var user = await AuthenticateAsync(userLogin.Email, userLogin.Password);
            var userAuthToken = CriptoHelper.encrypt($"{user.Email}:{user.Password}");

            AuthTokens[userAuthToken] = user;

            return userAuthToken;
        }

        public User GetLoggedUser()
        {
            var cookie = this.httpContextAccessor.HttpContext.Request.Cookies[AUTH_COOKIE_NAME];

            return GetUserByAuthToken(cookie);
        }

        public UserData GetLoggedUserData()
        {
            var user = GetLoggedUser();

            return new UserData
            {
                Email = user.Email,
                Image = user.Image.Url,
                Name = user.Name,
            };
        }

        public User GetUserByAuthToken(string authToken)
        {
            return AuthTokens[authToken];
        }
    }
}
