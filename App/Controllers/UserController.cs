using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Datas;
using Domain;
using Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.Services;
using Microsoft.Extensions.Options;
using App.Helpers;

namespace App.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(IOptions<AzureStorageConfig> config)
        {
            userService = new UserService(config.Value);
        }

        [HttpPost("/login")]
        public async Task<ObjectResult> Login(UserLoginData userLogin)
        {
            try
            {
                var userData = await userService.Login(userLogin);

                return Ok(userData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost("create-and-login")]
        public async Task<ObjectResult> SaveAndLogin(NewUserData newUser)
        {
            try
            {
                await userService.Save(newUser);
                var userData = await userService.Login(newUser.ToLoginData());

                return Ok(userData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
