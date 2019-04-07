using System;
using Microsoft.AspNetCore.Http;

namespace App.Datas
{
    public class UserData
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UserLoginData
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class NewUserData
    {
        public IFormFile Image { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        internal UserLoginData ToLoginData()
        {
            return new UserLoginData
            {
                Email = this.Email,
                Password = this.Password,
            };
        }
    }
}
