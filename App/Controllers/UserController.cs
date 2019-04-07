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
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet()]
        public async Task<ActionResult> GetLoggedUser()
        {
            try
            {
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserLoginData userLogin)
        {
            try
            {
                var userData = await userService.LoginAsync(userLogin);

                return Ok(userData);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = "true" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost("create-and-login")]
        public async Task<ActionResult> SaveAndLogin(NewUserData newUser)
        {
            try
            {
                await userService.SaveAsync(newUser);
                var userData = await userService.LoginAsync(newUser.ToLoginData());

                return Ok(userData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
